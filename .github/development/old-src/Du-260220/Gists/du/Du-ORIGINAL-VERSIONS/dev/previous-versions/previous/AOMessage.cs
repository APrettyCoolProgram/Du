/* A class for AO.cs that alert the user in a variey of ways.
 * v00.52.03.161113
 * http://aprettycoolprogram.com/ao
 */

using System.Net;
using System.Windows.Forms;

namespace AO
{
    public class AOMessage
    {
        public static void DownloadProgressBar(object sender, DownloadProgressChangeDeventArgs e, Control controlName)
        {
            //controlName.Value = e.ProgressPercentage;

            //controlName = e.ProgressPercentage;
        }

        public static DialogResult MessageWithResult(string message, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(message, caption, buttons, icon);
            //return result;

        }

        public static void JustMessage(string message)
        {
            MessageBox.Show(message);
        }


    }
}
