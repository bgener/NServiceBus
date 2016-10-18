namespace NServiceBus.Licensing
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using Janitor;
    

    [SkipWeaving]
    partial class BeginTrialForm : Form
    {
        public BeginTrialForm()
        {
            InitializeComponent();
        }
    
        private void docsHomeLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://docs.particular.net/");
        }

        private void nsbLicensinglinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://particular.net/licensing/");
        }
        
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
