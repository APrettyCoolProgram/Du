/* A class for AO.cs that does various things with settings.
 * v00.53.04.161220
 * http://aprettycoolprogram.com/ao
 */

/* This class is not yet fucntional */

using System;
using System.Windows.Forms;

namespace AO
{
    public partial class AOFormSettings : Form
    {
        /* Entry point */
        public AOFormSettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btnExitSettings control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <remarks>
        /// Work in progress.
        /// </remarks>
        private void btnExitSettings_Click(object sender, EventArgs e)
        {
            ExitSettings();
        }

        /// <summary>
        /// Exits the settings.
        /// </summary>
        /// <remarks>
        /// Work in progress.
        /// </remarks>
        private void ExitSettings()
        {
            //if (!Convert.ToBoolean(AOGlobal.PreviousFormName == null))
            //{
            //    AOForm.DisposeShow(this, AOGlobal.PreviousFormName);
            //}
        }

        /// <summary>
        /// Handles the Click event of the btnSaveSettings control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <remarks>
        /// Work in progress.
        /// </remarks>
        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        /// <summary>
        /// Saves the settings.
        /// </summary>
        /// <remarks>
        /// Work in progress.
        /// </remarks>
        public static void SaveSettings()
        {
            //var toSave = new Dictionary<string, string>(); // Placeholder for JACK settings.

            ////toSave["enableDarkMode"] = cbxEnableDarkMode.Checked.ToString();
            ////toSave["enableDirectoryCheck"] = cbxEnableDirectoryChecks.Checked.ToString();
            ////toSave["enableAutoUpdate"] = cbxEnableAutoUpdate.Checked.ToString();
            ////toSave["enableSillyMode"] = cbxEnableSillyMode.Checked.ToString();
            //// Write settings to file
            //AODictionary.ToFile("settings.jack", toSave);
            //// Close this form, show JACK form

            //// Hide this form, show the main JACK form.
            //if (!Convert.ToBoolean(GlobalVar.PreviousFormName == null))
            //{
            //    AOForm.DisposeShow(this, GlobalVar.PreviousFormName);
            //}
        }
    }
}