namespace ProcessKillerApp
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            notifyIcon1 = new NotifyIcon(components);
            txtProcessName = new TextBox();
            btnKillProcess = new Button();
            label1 = new Label();
            btnSaveProcess = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            выходToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
            resources.ApplyResources(notifyIcon1, "notifyIcon1");
            // 
            // txtProcessName
            // 
            txtProcessName.BackColor = Color.FromArgb(19, 19, 19);
            resources.ApplyResources(txtProcessName, "txtProcessName");
            txtProcessName.ForeColor = Color.White;
            txtProcessName.Name = "txtProcessName";
            // 
            // btnKillProcess
            // 
            btnKillProcess.BackColor = Color.FromArgb(19, 19, 9);
            btnKillProcess.FlatAppearance.BorderColor = Color.Yellow;
            btnKillProcess.FlatAppearance.BorderSize = 2;
            btnKillProcess.FlatAppearance.MouseDownBackColor = Color.Yellow;
            btnKillProcess.FlatAppearance.MouseOverBackColor = Color.Yellow;
            resources.ApplyResources(btnKillProcess, "btnKillProcess");
            btnKillProcess.ForeColor = SystemColors.ButtonHighlight;
            btnKillProcess.Name = "btnKillProcess";
            btnKillProcess.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Name = "label1";
            // 
            // btnSaveProcess
            // 
            btnSaveProcess.BackColor = Color.FromArgb(19, 19, 9);
            btnSaveProcess.FlatAppearance.BorderColor = Color.Red;
            btnSaveProcess.FlatAppearance.BorderSize = 2;
            btnSaveProcess.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 0, 0);
            btnSaveProcess.FlatAppearance.MouseOverBackColor = Color.Maroon;
            resources.ApplyResources(btnSaveProcess, "btnSaveProcess");
            btnSaveProcess.ForeColor = SystemColors.ButtonHighlight;
            btnSaveProcess.Name = "btnSaveProcess";
            btnSaveProcess.UseVisualStyleBackColor = false;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { выходToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(contextMenuStrip1, "contextMenuStrip1");
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            resources.ApplyResources(выходToolStripMenuItem, "выходToolStripMenuItem");
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(21, 21, 21);
            Controls.Add(btnSaveProcess);
            Controls.Add(label1);
            Controls.Add(btnKillProcess);
            Controls.Add(txtProcessName);
            Name = "MainForm";
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NotifyIcon notifyIcon1;
        private TextBox txtProcessName;
        private Button btnKillProcess;
        private Label label1;
        private Button btnSaveProcess;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem выходToolStripMenuItem;
    }
}