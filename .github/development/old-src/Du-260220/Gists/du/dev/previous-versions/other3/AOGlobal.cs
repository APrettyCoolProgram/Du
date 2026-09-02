/* A class for AO.cs that holds global variables.
 * v00.54.04.161220
 * http://aprettycoolprogram.com/ao
 */

/* This class contains various global variables that are used througout AO, and any applications that use AO.
 *
 *     PreviousFormName: The name of the form that passed to another form. Used in situation where you are
 *                       closing form A, opening form B, but want to open form A again when closing form B.
 */

using System.Windows.Forms;

namespace AO
{
    public static class AOGlobal
    {
        /* General global variables for AO. */
        private static Form _previousFormName;

        /* General global variables for AO. */

        public static Form PreviousFormName
        {
            get { return _previousFormName; }
            set { _previousFormName = value; }
        }
    }
}