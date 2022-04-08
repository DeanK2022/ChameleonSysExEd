
namespace ChameleonSysExEd
{
    partial class ExportMIDIForm
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
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblMIDIPort = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSend = new System.Windows.Forms.Label();
            this.lbExportDeviceName = new System.Windows.Forms.Label();
            this.lbSentStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(59, 141);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "&Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(221, 141);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(140, 141);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "&Stop";
            this.btnStop.UseVisualStyleBackColor = true;
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
            this.label1.Location = new System.Drawing.Point(59, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Get your MIDI devices ready and press Export";
            // 
            // lblSend
            // 
            this.lblSend.AutoSize = true;
            this.lblSend.Location = new System.Drawing.Point(59, 50);
            this.lblSend.Name = "lblSend";
            this.lblSend.Size = new System.Drawing.Size(32, 13);
            this.lblSend.TabIndex = 5;
            this.lblSend.Text = "Sent:";
            // 
            // lbExportDeviceName
            // 
            this.lbExportDeviceName.AutoSize = true;
            this.lbExportDeviceName.Location = new System.Drawing.Point(120, 14);
            this.lbExportDeviceName.Name = "lbExportDeviceName";
            this.lbExportDeviceName.Size = new System.Drawing.Size(35, 13);
            this.lbExportDeviceName.TabIndex = 6;
            this.lbExportDeviceName.Text = "label2";
            // 
            // lbSentStatus
            // 
            this.lbSentStatus.AutoSize = true;
            this.lbSentStatus.Location = new System.Drawing.Point(120, 50);
            this.lbSentStatus.Name = "lbSentStatus";
            this.lbSentStatus.Size = new System.Drawing.Size(35, 13);
            this.lbSentStatus.TabIndex = 7;
            this.lbSentStatus.Text = "label2";
            // 
            // ExportMIDIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 178);
            this.Controls.Add(this.lbSentStatus);
            this.Controls.Add(this.lbExportDeviceName);
            this.Controls.Add(this.lblSend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMIDIPort);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportMIDIForm";
            this.Text = "Export Sysex Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblMIDIPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSend;
        private System.Windows.Forms.Label lbExportDeviceName;
        private System.Windows.Forms.Label lbSentStatus;
    }
}