/*
 * Based on CSharp User Panel DLL example by EDDiscovery development team
 * https://github.com/EDDiscovery/EDDiscoveryAdditionalDLLs/tree/master/ExampleAddInDLL
 * Copyright © 2022 - 2022 EDDiscovery development team
 *
 * Integration with Canonn based on code from EDDCanonn
 * https://github.com/canonn-science/EDDCanonn/tree/main
 * 
 * Idea and implementation - Keen13 @ github.com
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this
 * file except in compliance with the License. You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software distributed under
 * the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF
 * ANY KIND, either express or implied. See the License for the specific language
 * governing permissions and limitations under the License.
 */

using QuickJSON;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EDDDLLInterfaces.EDDDLLIF;
using static System.Net.Mime.MediaTypeNames;

namespace DemoUserControl
{
    public partial class CanonnControl : UserControl, IEDDPanelExtension
    {
        private EDDPanelCallbacks PanelCallBack;
        private EDDDLLInterfaces.EDDDLLIF.EDDCallBacks DLLCallBack;

        public CanonnControl()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Inherit;      // prevent double resizing
        }

        public bool SupportTransparency => true;

         public bool DefaultTransparent => false;

        Color FromJson(JToken color) { return Color.FromArgb(color["A"].Int(), color["R"].Int(), color["G"].Int(), color["B"].Int()); }

        public void Initialise(EDDPanelCallbacks callbacks, int displayid, string themeasjson, string configuration)
        {
            CheckCanonnWhitelist();

            DLLCallBack = CSharpDLLPanel2.CSharpDLLPanelEDDClass.DLLCallBack;       // grab the DLL call back
            this.PanelCallBack = callbacks;

            ThemeChanged(themeasjson);

            dataGridView1.Rows.Add(new string[] { "Event grid", "1-1", "1-2" ,"1-3"});
            richTextBox1.AppendText("New Panel init\r\n");                        
            DLLCallBack.WriteToLogHighlight("Demo DLL Initialised");
        }
        
        public void SetTransparency(bool ison, Color curcol)
        {
            richTextBox1.AppendText($"Set Transparency {ison}\r\n");
            this.BackColor = panel1.BackColor = curcol;
            PanelCallBack.DGVTransparent(dataGridView1, ison, curcol);
        }

        public void LoadLayout()
        {
            richTextBox1.AppendText("load layout\r\n");
            PanelCallBack.SetControlText("Ext Panel!");
            PanelCallBack.LoadGridLayout(dataGridView1);
        }

        public void InitialDisplay()
        {
            richTextBox1.AppendText("init display\r\n");
        }

        public bool AllowClose()
        {
            return true;
        }

        public void Closing()
        {
            richTextBox1.AppendText($"close panel {PanelCallBack.IsClosed()}\r\n");
            PanelCallBack.SaveGridLayout(dataGridView1);
        }

        void IEDDPanelExtension.CursorChanged(JournalEntry je)          // called when the history cursor changes.. tells you where the user is looking at
        {
            richTextBox1.AppendText($"Cursor changed to {je.name}\r\n");
        }

        public string HelpKeyOrAddress()
        {
            return @"http:\\news.bbc.co.uk";
        }

        public void ControlTextVisibleChange(bool on)
        {
            richTextBox1.AppendText($"Control text visibility to {on}\r\n");
        }

        public void HistoryChange(int count, string commander, bool beta, bool legacy)
        {
            richTextBox1.AppendText($"History change {count} {commander} {beta} {legacy}\r\n");
            dataGridView1.Rows.Clear();

            for( int i = 5; i > 0; i-- )    // demo - load last 5 HEs
            {
                if ( DLLCallBack.RequestHistory(count-i,false,out JournalEntry je) )
                { 
                    dataGridView1.Rows.Add(new string[] { je.utctime, je.name, je.info, je.detailedinfo });
                }
                else
                    break;
            }

            var target = DLLCallBack.GetTarget();
            if (target != null)
                richTextBox1.AppendText($"Target is {target}\r\n");
            else
                richTextBox1.AppendText($"No Target\r\n");

            DLLCallBack.WriteToLog("Demo DLL User Control History Changed");
        }

        public void NewUnfilteredJournal(JournalEntry je)
        {
            richTextBox1.AppendText($"New unfiltered JE {je.json} \r\n");
        }

        public void NewFilteredJournal(JournalEntry je)
        {
            richTextBox1.AppendText($"New filtered JE {je.json}\r\n");
            dataGridView1.Rows.Add(new string[] { je.utctime, je.name, je.info, je.detailedinfo });
        }

        public void NewUIEvent(string jsonui)
        {
            var j = jsonui.JSONParse();
            string ev = j["EventTypeID"].Str();
            richTextBox1.AppendText($"New UI Event {ev}\r\n");
            dataGridView1.Rows.Add(new string[] { "UI", ev, jsonui, "" });
        }

        public void NewTarget(Tuple<string, double, double, double> target)
        {
            if (target != null)
                richTextBox1.AppendText($"New target {target.Item1} {target.Item2} {target.Item3} {target.Item4}\r\n");
            else
                richTextBox1.AppendText($"Target removed\r\n");
        }

        public void ScreenShotCaptured(string file, Size s)
        {
            richTextBox1.AppendText($"Screenshot {file} {s}\r\n");
        }

        public void ThemeChanged(string themeasjson)
        {
            // theme variables can be found in ExtendedControls - theme

            JObject theme = themeasjson.JSONParse().Object();
            Color butbordercolor = FromJson(theme["ButtonBorderColor"]);
            Color butforecolor = FromJson(theme["ButtonTextColor"]);
            Color butbackcolor = FromJson(theme["ButtonBackColor"]);
            Color textbordercolor = FromJson(theme["TextBlockBorderColor"]);
            Color textforecolor = FromJson(theme["TextBlockColor"]);
            Color textbackcolor = FromJson(theme["TextBackColor"]);

            richTextBox1.BackColor = textbackcolor;
            richTextBox1.ForeColor = textforecolor;
            richTextBox1.BorderStyle = BorderStyle.FixedSingle;

            Font fnt = new Font(theme["Font"].Str(), theme["FontSize"].Float());
            richTextBox1.Font = fnt;

            Color formbackcolor = FromJson(theme["Form"]);

            PanelCallBack.DGVTransparent(dataGridView1, false, formbackcolor); // presuming its not transparent.. would need to make this more clever by saving Settransparent state
        }

        public void DataResult(string data)
        {
            richTextBox1.AppendText($"System {data}\r\n");
            richTextBox1.ScrollToCaret();
        }

        public void TransparencyModeChanged(bool on)
        {
            richTextBox1.AppendText($"Transparent mode {on}\r\n");
        }

        // ----------------------------------------------------------------------------------------------------------------------------------------------------------------- //
        private void btnMaxEvents_Click(object sender, EventArgs e)
        {

            var maxIndex = FindMaxEntryIndex();
            tbToEntryId.Text = maxIndex.ToString();
            Log($"Last Entry: #{maxIndex}");

            int FindMaxEntryIndex()
            {
                var lastMin = 0;
                var lastMax = int.MaxValue;
                var currentIndex = 1;
                while (true)
                {

                    if (currentIndex == lastMin)
                    {
                        break;
                    }

                    if (currentIndex == lastMax)
                    {
                        currentIndex--;
                        break;
                    }

                    if (IsIndexLessOrEqualToMax(currentIndex))
                    {
                        lastMin = currentIndex;
                        currentIndex += (lastMax - currentIndex) / 2;
                    }
                    else
                    {
                        lastMax = currentIndex;
                        currentIndex -= (currentIndex - lastMin) / 2; ;
                    }
                }

                return currentIndex;
            }

            bool IsIndexLessOrEqualToMax(int idx)
            {
                return DLLCallBack.RequestHistory(idx, false, out JournalEntry _);
            }
        }

        private void btnGetEvents_Click(object sender, EventArgs e)
        {
            JournalEntry entry;
            int.TryParse(tbFromEntryId.Text, out int fromEntryId);
            int.TryParse(tbToEntryId.Text, out int toEntryId);
            var count = 0;

            for (var entryId = fromEntryId; entryId <= toEntryId; entryId++)
            {
                if (entryId % 1000 == 0)
                {
                    Log($"Processing entry {entryId}");
                }

                bool hasEntry = DLLCallBack.RequestHistory(entryId, false, out entry);
                string type = entry.eventid;
                switch (type)
                {
                    case "CodexEntry":
                    case "ScanOrganic":
                        count++;                        
                        var text = hasEntry ? $"{entry.json}{Environment.NewLine}" : $"No entry #{entryId}";
                        Log(text);
                        break;
                }
            }

            Log($"Total {count} entries to send{Environment.NewLine}");
        }

        private void btnSendEvents_Click(object sender, EventArgs e)
        {
            JournalEntry entry;
            int.TryParse(tbFromEntryId.Text, out int fromEntryId);
            int.TryParse(tbToEntryId.Text, out int toEntryId);
            Log($"Sending entries synchronously from #{fromEntryId} to {toEntryId}");

            for (var entryId = fromEntryId; entryId <= toEntryId; entryId++)
            {
                bool hasEntry = DLLCallBack.RequestHistory(entryId, false, out entry);
                if (!hasEntry)
                {
                    continue;
                }

                string type = entry.eventid;
                bool result;
                switch (type)
                {
                    case "CodexEntry":
                        result = LogCodexEntry(entry);
                        if (result)
                        {
                            LogEntrySendingOK(entryId, entry);
                        }
                        else
                        {
                            LogEntrySendingNOK(entryId, entry);
                        }
                        break;
                    case "ScanOrganic":
                        result = LogScanOrganic(entry);
                        if (result)
                        {
                            LogEntrySendingOK(entryId, entry);
                        }
                        else
                        {
                            LogEntrySendingNOK(entryId, entry);
                        }
                        break;
                }
            }

            Log($"Done sending{Environment.NewLine}");

            void LogEntrySendingOK(int _entryId, JournalEntry journalEntry)
            {
                var timestamp = GetTimestamp(journalEntry);
                Log($"Sent entry #{_entryId} ({timestamp:d})");
            }

            void LogEntrySendingNOK(int _entryId, JournalEntry journalEntry)
            {
                var timestamp = GetTimestamp(journalEntry);
                Log($"Failed to send entry #{_entryId} ({timestamp:d})");
            }

            DateTime GetTimestamp(JournalEntry journalEntry)
            {
                JToken o = JToken.Parse(journalEntry.json);
                var timestampString = o["timestamp"].ToString().Trim('"');
                return DateTime.Parse(timestampString);
            }
        }

        // NB! Copy from Canonn DLL
        bool LogCodexEntry(EDDDLLInterfaces.EDDDLLIF.JournalEntry entry)
        {
            if (!m_whitelist_initialized || !m_whitelist.Contains("CodexEntry")) return false;

            JToken o = JToken.Parse(entry.json);

            JObject e = new JObject();
            JObject game_state = new JObject();
            JObject raw_events = new JObject();
            e["gameState"] = game_state;

            // Mandatories
            game_state["systemName"] = o["System"];
            game_state["systemAddress"] = o["SystemAddress"];
            game_state["systemCoordinates"] = JArray.FromObject(new double[] { entry.x, entry.y, entry.z });
            game_state["clientVersion"] = "EDDCanonn v1.1.1";
            game_state["latitude"] = o["Latitude"];
            game_state["longitude"] = o["Longitude"];
            game_state["platform"] = "PC";
            game_state["bodyName"] = entry.whereami;
            if (m_temperature >= 0) game_state["temperature"] = m_temperature;

#if STAGING
            game_state["isBeta"] = true;
            e["cmdrName"] = "TEST";
#else
            game_state["isBeta"] = false;
            e["cmdrName"] = entry.cmdrname;
#endif

            // #todo?
            //e["gameSystem"].bodyId = "#todo";

            e["rawEvents"] = JArray.Parse("[" + entry.json + "]");

            string result = "[" + e.ToString() + "]";

            // #todo handle response
            StringContent content = new StringContent(result, Encoding.UTF8, "application/json");
#if !NO_NETWORK
            try
            {
                HttpResponseMessage response = m_client.PostAsync("https://us-central1-canonn-api-236217.cloudfunctions.net/postEvent", content).Result;
                var code = response.StatusCode == HttpStatusCode.OK;
                if (!code)
                {
                    Log(response.ToString());
                }

                return code;
            }
            catch (Exception)
            {
                return false;
            }
#endif
        }

        // NB! Copy from Canonn DLL
        bool LogScanOrganic(EDDDLLInterfaces.EDDDLLIF.JournalEntry entry)
        {
            if (!m_whitelist_initialized || !m_whitelist.Contains("ScanOrganic")) return false;

            JToken o = JToken.Parse(entry.json);

            JObject e = new JObject();
            JObject game_state = new JObject();
            JObject raw_events = new JObject();
            e["gameState"] = game_state;

            // Mandatories
            game_state["systemName"] = entry.systemname;
            game_state["systemAddress"] = o["SystemAddress"];
            game_state["systemCoordinates"] = JArray.FromObject(new double[] { entry.x, entry.y, entry.z });
            game_state["clientVersion"] = "EDDCanonn v1.1.1";
            game_state["bodyName"] = entry.whereami;
            game_state["bodyId"] = o["Body"];
            game_state["platform"] = "PC";
            game_state["odyssey"] = true;
            if (m_temperature >= 0) game_state["temperature"] = m_temperature;

#if STAGING
            game_state["isBeta"] = true;
            e["cmdrName"] = "TEST";
#else
            game_state["isBeta"] = false;
            e["cmdrName"] = entry.cmdrname;
#endif

            // #todo?
            //game_state["latitude"] = "#todo";
            //game_state["longitude"] = "#todo";

            e["rawEvents"] = JArray.Parse("[" + entry.json + "]");

            string result = "[" + e.ToString() + "]";

            // #todo handle response
            StringContent content = new StringContent(result, Encoding.UTF8, "application/json");
#if !NO_NETWORK
            try
            {
                HttpResponseMessage response = m_client.PostAsync("https://us-central1-canonn-api-236217.cloudfunctions.net/postEvent", content).Result;                
                var code = response.StatusCode == HttpStatusCode.OK;
                if (!code)
                {
                    Log(response.ToString());
                }

                return code;
            }
            catch (Exception)
            {
                return false;
            }
#endif
        }

        // NB! Copy from Canonn DLL
        private void CheckCanonnWhitelist()
        {
            // Check whitelist
            Task.Run(() =>
            {
                try
                {
                    HttpWebRequest request = WebRequest.Create("https://us-central1-canonn-api-236217.cloudfunctions.net/postEventWhitelist") as HttpWebRequest;
                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    string body = reader.ReadToEnd();
                    JArray whitelist = JArray.Parse(body);
                    foreach (JObject l in whitelist)
                    {
                        var definition = l["definition"];
                        if (definition == null) continue;

                        var e = definition["event"];
                        if (e == null) continue;

                        m_whitelist.Add((string)e);
                    }

                    m_whitelist_initialized = true;
                }
                catch (Exception)
                {
                    return;
                }
            });
        }

        void Log(string text)
        {
            richTextBox1.AppendText(text);
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.ScrollToCaret();
        }

        // NB! Copy from Canonn DLL
        HashSet<string> m_whitelist = new HashSet<string>();
        HttpClient m_client = new HttpClient();
        double m_temperature = -1;
        // Whitelist is not multithread-safe, so we defer any use of the whitelist to after it's fully initialized
        bool m_whitelist_initialized = false;
    }
}

