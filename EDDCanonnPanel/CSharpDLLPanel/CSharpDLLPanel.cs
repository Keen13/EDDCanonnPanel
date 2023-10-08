using System.Drawing;

namespace CSharpDLLPanel2
{
    public class CSharpDLLPanelEDDClass
    {
        // make sure panel unique id and winref name is based on a producer-panel naming system to make it unique
        private const string UniqueId = "CSharpDLLPanel-" + Title;
        private const string Title = "Canonn";
        private const string Description = "Send data to Canonn";

        public static EDDDLLInterfaces.EDDDLLIF.EDDCallBacks DLLCallBack;

        public CSharpDLLPanelEDDClass()
        {
            System.Diagnostics.Debug.WriteLine("CSharpDLLPanel2 Made DLL instance");
        }

        public string EDDInitialise(string vstr, string dllfolder, EDDDLLInterfaces.EDDDLLIF.EDDCallBacks cb)
        {
            DLLCallBack = cb;
            System.Diagnostics.Debug.WriteLine("CSharpDLLPanel2 Init func " + vstr + " " + dllfolder);
            if ( cb.ver>=3 && cb.AddPanel != null)
            {

                var icon = new Bitmap(1, 1); // Dummy icon
                cb.AddPanel(UniqueId, typeof(DemoUserControl.CanonnControl), Title, UniqueId, Description, icon);
            }
            return "1.0.0.0";
        }

        public void EDDTerminate()
        {
            System.Diagnostics.Debug.WriteLine("CSharpDLLPanel Unload");
        }

        public void EDDDataResult(object requesttag, object usertag, string data)
        {
            DemoUserControl.CanonnControl uc = usertag as DemoUserControl.CanonnControl;
            uc.DataResult(data);
        }
    }
}
