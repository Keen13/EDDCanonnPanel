
namespace DemoUserControl
{ 
    partial class CanonnControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnMaxEvents = new System.Windows.Forms.Button();
            this.btnGetEvents = new System.Windows.Forms.Button();
            this.btnSendEvents = new System.Windows.Forms.Button();
            this.tbToEntryId = new System.Windows.Forms.TextBox();
            this.tbFromEntryId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 899);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(2141, 634);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 172);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 102;
            this.dataGridView1.Size = new System.Drawing.Size(2141, 727);
            this.dataGridView1.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.MinimumWidth = 12;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.FillWeight = 50F;
            this.Column2.HeaderText = "Column2";
            this.Column2.MinimumWidth = 12;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Column3";
            this.Column3.MinimumWidth = 12;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Column4";
            this.Column4.MinimumWidth = 12;
            this.Column4.Name = "Column4";
            // 
            // btnMaxEvents
            // 
            this.btnMaxEvents.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnMaxEvents.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnMaxEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaxEvents.ForeColor = System.Drawing.SystemColors.Control;
            this.btnMaxEvents.Location = new System.Drawing.Point(923, 7);
            this.btnMaxEvents.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnMaxEvents.Name = "btnMaxEvents";
            this.btnMaxEvents.Size = new System.Drawing.Size(272, 52);
            this.btnMaxEvents.TabIndex = 0;
            this.btnMaxEvents.Text = "Max event #";
            this.btnMaxEvents.UseVisualStyleBackColor = false;
            this.btnMaxEvents.Click += new System.EventHandler(this.btnMaxEvents_Click);
            // 
            // btnGetEvents
            // 
            this.btnGetEvents.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnGetEvents.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnGetEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetEvents.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGetEvents.Location = new System.Drawing.Point(1211, 7);
            this.btnGetEvents.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnGetEvents.Name = "btnGetEvents";
            this.btnGetEvents.Size = new System.Drawing.Size(276, 52);
            this.btnGetEvents.TabIndex = 0;
            this.btnGetEvents.Text = "RequestHistory";
            this.btnGetEvents.UseVisualStyleBackColor = false;
            this.btnGetEvents.Click += new System.EventHandler(this.btnGetEvents_Click);
            // 
            // btnSendEvents
            // 
            this.btnSendEvents.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSendEvents.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnSendEvents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendEvents.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSendEvents.Location = new System.Drawing.Point(1503, 7);
            this.btnSendEvents.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnSendEvents.Name = "btnSendEvents";
            this.btnSendEvents.Size = new System.Drawing.Size(272, 52);
            this.btnSendEvents.TabIndex = 0;
            this.btnSendEvents.Text = "Send Entries";
            this.btnSendEvents.UseVisualStyleBackColor = false;
            this.btnSendEvents.Click += new System.EventHandler(this.btnSendEvents_Click);
            // 
            // tbToEntryId
            // 
            this.tbToEntryId.Location = new System.Drawing.Point(1611, 67);
            this.tbToEntryId.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbToEntryId.Name = "tbToEntryId";
            this.tbToEntryId.Size = new System.Drawing.Size(164, 38);
            this.tbToEntryId.TabIndex = 3;
            // 
            // tbFromEntryId
            // 
            this.tbFromEntryId.Location = new System.Drawing.Point(1308, 73);
            this.tbFromEntryId.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tbFromEntryId.Name = "tbFromEntryId";
            this.tbFromEntryId.Size = new System.Drawing.Size(179, 38);
            this.tbFromEntryId.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1194, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "From";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1503, 73);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 32);
            this.label3.TabIndex = 6;
            this.label3.Text = "To";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbFromEntryId);
            this.panel1.Controls.Add(this.tbToEntryId);
            this.panel1.Controls.Add(this.btnSendEvents);
            this.panel1.Controls.Add(this.btnGetEvents);
            this.panel1.Controls.Add(this.btnMaxEvents);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2141, 172);
            this.panel1.TabIndex = 1;
            // 
            // DemonstrationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "DemonstrationUserControl";
            this.Size = new System.Drawing.Size(2141, 1533);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button btnMaxEvents;
        private System.Windows.Forms.Button btnGetEvents;
        private System.Windows.Forms.Button btnSendEvents;
        private System.Windows.Forms.TextBox tbToEntryId;
        private System.Windows.Forms.TextBox tbFromEntryId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
    }
}
