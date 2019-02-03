namespace VoiceRecognition
{
    partial class VoiceForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoiceForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verboseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInfoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseAudioDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Voice Recognition";
            this.notifyIcon.Visible = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseAudioDevice,
            this.verboseToolStripMenuItem,
            this.showInfoMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(188, 92);
            // 
            // verboseToolStripMenuItem
            // 
            this.verboseToolStripMenuItem.Name = "verboseToolStripMenuItem";
            this.verboseToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.verboseToolStripMenuItem.Text = "Verbose";
            this.verboseToolStripMenuItem.Click += new System.EventHandler(this.verboseToolStripMenuItem_Click);
            // 
            // showInfoMenuItem
            // 
            this.showInfoMenuItem.Name = "showInfoMenuItem";
            this.showInfoMenuItem.Size = new System.Drawing.Size(187, 22);
            this.showInfoMenuItem.Text = "Show Info";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // chooseAudioDevice
            // 
            this.chooseAudioDevice.Name = "chooseAudioDevice";
            this.chooseAudioDevice.Size = new System.Drawing.Size(187, 22);
            this.chooseAudioDevice.Text = "Choose Audio Device";
            // 
            // VoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 0);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "VoiceForm";
            this.ShowInTaskbar = false;
            this.Text = "VoiceForm";
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verboseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showInfoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseAudioDevice;
    }
}