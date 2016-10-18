namespace NServiceBus.Licensing
{
    partial class BeginTrialForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BeginTrialForm));
            this.headerPanel = new System.Windows.Forms.Panel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.docsHomeLinkLabel = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.instructionsText = new System.Windows.Forms.RichTextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.trialInfoLabel = new System.Windows.Forms.RichTextBox();
            this.nsbLicensinglinkLabel = new System.Windows.Forms.LinkLabel();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.Black;
            this.headerPanel.Controls.Add(this.logoPictureBox);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(4);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(772, 111);
            this.headerPanel.TabIndex = 1;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = global::NServiceBus.Properties.Resources.logo;
            this.logoPictureBox.InitialImage = null;
            this.logoPictureBox.Location = new System.Drawing.Point(57, 15);
            this.logoPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(286, 65);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.logoPictureBox.TabIndex = 0;
            this.logoPictureBox.TabStop = false;
            // 
            // docsHomeLinkLabel
            // 
            this.docsHomeLinkLabel.AutoSize = true;
            this.docsHomeLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.docsHomeLinkLabel.ForeColor = System.Drawing.Color.Blue;
            this.docsHomeLinkLabel.Location = new System.Drawing.Point(162, 218);
            this.docsHomeLinkLabel.Name = "docsHomeLinkLabel";
            this.docsHomeLinkLabel.Size = new System.Drawing.Size(306, 25);
            this.docsHomeLinkLabel.TabIndex = 21;
            this.docsHomeLinkLabel.TabStop = true;
            this.docsHomeLinkLabel.Text = "Getting Started With NServiceBus";
            this.docsHomeLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.docsHomeLinkLabel_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NServiceBus.Properties.Resources.devPortal;
            this.pictureBox1.Location = new System.Drawing.Point(42, 154);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // instructionsText
            // 
            this.instructionsText.BackColor = System.Drawing.Color.White;
            this.instructionsText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.instructionsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionsText.ForeColor = System.Drawing.Color.Black;
            this.instructionsText.Location = new System.Drawing.Point(163, 167);
            this.instructionsText.Margin = new System.Windows.Forms.Padding(4);
            this.instructionsText.Name = "instructionsText";
            this.instructionsText.ReadOnly = true;
            this.instructionsText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.instructionsText.Size = new System.Drawing.Size(489, 68);
            this.instructionsText.TabIndex = 19;
            this.instructionsText.TabStop = false;
            this.instructionsText.Text = "Get started using NServiceBus. Learn how to configure your endpoints, select your" +
    " transport and send messages.";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(338, 354);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(99, 30);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // trialInfoLabel
            // 
            this.trialInfoLabel.BackColor = System.Drawing.Color.White;
            this.trialInfoLabel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trialInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trialInfoLabel.ForeColor = System.Drawing.Color.Black;
            this.trialInfoLabel.Location = new System.Drawing.Point(41, 283);
            this.trialInfoLabel.Margin = new System.Windows.Forms.Padding(4);
            this.trialInfoLabel.Name = "trialInfoLabel";
            this.trialInfoLabel.ReadOnly = true;
            this.trialInfoLabel.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.trialInfoLabel.Size = new System.Drawing.Size(691, 54);
            this.trialInfoLabel.TabIndex = 26;
            this.trialInfoLabel.TabStop = false;
            this.trialInfoLabel.Text = "Your 14 day free trial starts today. You can extend your license for an additiona" +
    "l 30 days for free when the trial period is over. For more details:";
            // 
            // nsbLicensinglinkLabel
            // 
            this.nsbLicensinglinkLabel.AutoSize = true;
            this.nsbLicensinglinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nsbLicensinglinkLabel.ForeColor = System.Drawing.Color.Blue;
            this.nsbLicensinglinkLabel.Location = new System.Drawing.Point(358, 303);
            this.nsbLicensinglinkLabel.Name = "nsbLicensinglinkLabel";
            this.nsbLicensinglinkLabel.Size = new System.Drawing.Size(188, 20);
            this.nsbLicensinglinkLabel.TabIndex = 27;
            this.nsbLicensinglinkLabel.TabStop = true;
            this.nsbLicensinglinkLabel.Text = "NServiceBus Licensing.";
            this.nsbLicensinglinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.nsbLicensinglinkLabel_LinkClicked);
            // 
            // BeginTrialForm
            // 
            this.AcceptButton = this.buttonClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(772, 396);
            this.Controls.Add(this.nsbLicensinglinkLabel);
            this.Controls.Add(this.trialInfoLabel);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.docsHomeLinkLabel);
            this.Controls.Add(this.instructionsText);
            this.Controls.Add(this.headerPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BeginTrialForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Get started with NServiceBus NuGet package";
            this.TopMost = true;
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.LinkLabel docsHomeLinkLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox instructionsText;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.RichTextBox trialInfoLabel;
        private System.Windows.Forms.LinkLabel nsbLicensinglinkLabel;
    }
}