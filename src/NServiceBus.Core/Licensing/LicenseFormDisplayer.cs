namespace NServiceBus
{
    using System;
    using System.Threading;
    using System.Windows.Forms;
    using Licensing;
    using Particular.Licensing;

    static class LicenseFormDisplayer
    {
        public static License PromptUserForLicense(License currentLicense)
        {
            SynchronizationContext synchronizationContext = null;
            try
            {
                synchronizationContext = SynchronizationContext.Current;
                using (var form = new LicenseExpiredForm())
                {
                    form.CurrentLicense = currentLicense;
                    form.ShowDialog();
                    if (form.ResultingLicenseText == null)
                    {
                        return null;
                    }

                    new RegistryLicenseStore()
                        .StoreLicense(form.ResultingLicenseText);

                    return LicenseDeserializer.Deserialize(form.ResultingLicenseText);
                }
            }
            finally
            {
                SynchronizationContext.SetSynchronizationContext(synchronizationContext);
            }
        }

        public static void PromptUserForFirstTimeUse()
        {
            SynchronizationContext synchronizationContext = null;
            try
            {
                synchronizationContext = SynchronizationContext.Current;
                using (var form = new BeginTrialForm())
                {
                    form.WindowState = FormWindowState.Minimized;
                    form.Shown += delegate (object sender, EventArgs e) {
                        ((Form)sender).WindowState = FormWindowState.Normal;
                        ((Form)sender).StartPosition = FormStartPosition.CenterScreen;
                    };
                    form.ShowDialog();
                }
            }
            finally
            {
                SynchronizationContext.SetSynchronizationContext(synchronizationContext);
            }
        }
    }
}