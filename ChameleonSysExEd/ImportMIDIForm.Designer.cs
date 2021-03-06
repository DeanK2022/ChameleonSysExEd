
namespace ChameleonSysExEd
{
    partial class ImportMIDIForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnImport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblMIDIPort = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSend = new System.Windows.Forms.Label();
            this.lbImportDeviceName = new System.Windows.Forms.Label();
            this.lbReceived = new System.Windows.Forms.Label();
            this.cbAddToCurrent = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(59, 141);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "&Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(221, 141);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(140, 141);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "&Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblMIDIPort
            // 
            this.lblMIDIPort.AutoSize = true;
            this.lblMIDIPort.Location = new System.Drawing.Point(59, 14);
            this.lblMIDIPort.Name = "lblMIDIPort";
            this.lblMIDIPort.Size = new System.Drawing.Size(55, 13);
            this.lblMIDIPort.TabIndex = 3;
            this.lblMIDIPort.Text = "MIDI Port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Get your MIDI devices ready and press Import";
            // 
            // lblSend
            // 
            this.lblSend.AutoSize = true;
            this.lblSend.Location = new System.Drawing.Point(59, 44);
            this.lblSend.Name = "lblSend";
            this.lblSend.Size = new System.Drawing.Size(56, 13);
            this.lblSend.TabIndex = 5;
            this.lblSend.Text = "Received:";
            // 
            // lbImportDeviceName
            // 
            this.lbImportDeviceName.AutoSize = true;
            this.lbImportDeviceName.Location = new System.Drawing.Point(120, 14);
            this.lbImportDeviceName.Name = "lbImportDeviceName";
            this.lbImportDeviceName.Size = new System.Drawing.Size(33, 13);
            this.lbImportDeviceName.TabIndex = 7;
            this.lbImportDeviceName.Text = "None";
            // 
            // lbReceived
            // 
            this.lbReceived.AutoSize = true;
            this.lbReceived.Location = new System.Drawing.Point(121, 44);
            this.lbReceived.Name = "lbReceived";
            this.lbReceived.Size = new System.Drawing.Size(13, 13);
            this.lbReceived.TabIndex = 8;
            this.lbReceived.Text = "0";
            // 
            // cbAddToCurrent
            // 
            this.cbAddToCurrent.AutoSize = true;
            this.cbAddToCurrent.Enabled = false;
            this.cbAddToCurrent.Location = new System.Drawing.Point(78, 105);
            this.cbAddToCurrent.Name = "cbAddToCurrent";
            this.cbAddToCurrent.Size = new System.Drawing.Size(125, 17);
            this.cbAddToCurrent.TabIndex = 9;
            this.cbAddToCurrent.Text = "Add to current SysEx";
            this.cbAddToCurrent.UseVisualStyleBackColor = true;
            // 
            // ImportMIDIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 178);
            this.Controls.Add(this.cbAddToCurrent);
            this.Controls.Add(this.lbReceived);
            this.Controls.Add(this.lbImportDeviceName);
            this.Controls.Add(this.lblSend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMIDIPort);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnImport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportMIDIForm";
            this.Text = "Import Sysex Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblMIDIPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSend;
        private System.Windows.Forms.Label lbImportDeviceName;
        private System.Windows.Forms.Label lbReceived;
        private System.Windows.Forms.CheckBox cbAddToCurrent;
    }
}