/* A class for AO.cs that does various things with winforms.
 * v00.53.04.161120
 * http://aprettycoolprogram.com/ao
 */

using System.Drawing;
using System.Windows.Forms;

namespace AO
{
    public class AOForm
    {
        /// <summary>
        /// Disposes a form, then show another form.
        /// </summary>
        /// <param name="disposeThis">The dispose this.</param>
        /// <param name="showThis">The show this.</param>
        /// <remarks>
        /// None.
        /// </remarks>
        public static void DisposeShow(Form disposeThis, Form showThis)
        {
            disposeThis.Dispose();
            showThis.Show();
        }

        /// <summary>
        /// Hides a form, then show another form.
        /// </summary>
        /// <param name="hideThis">The hide this.</param>
        /// <param name="showThis">The show this.</param>
        /// <remarks>
        /// [T] Combine w/below?
        /// </remarks>
        public static void HideShow(Form hideThis, Form showThis)
        {
            hideThis.Hide();
            showThis.Show();
        }

        /// <summary>
        /// Hides a form, then show a dialog.
        /// </summary>
        /// <param name="hideThis">The hide this.</param>
        /// <param name="showThis">The show this.</param>
        /// <remarks>
        /// [T] Combine w/above?
        /// </remarks>
        public static void HideShowDialog(Form hideThis, Form showThis)
        {
            hideThis.Hide();
            showThis.ShowDialog();
        }

        /// <summary>
        /// Apply a color scheme to a form.
        /// </summary>
        /// <param name="formName">Name of the form.</param>
        /// <param name="bgColor">Color of the bg.</param>
        /// <param name="fgColor">Color of the fg.</param>
        /// <remarks>
        /// None.
        /// </remarks>
        public static void Paint(Form formName, string bgColor, string fgColor)
        {
            formName.BackColor = Color.FromName(bgColor);
            formName.ForeColor = Color.FromName(fgColor);
        }
    }
}