/* A class for AO.cs that does various things with message forms.
 * v00.53.04.161220
 * http://aprettycoolprogram.com/ao
 */

/* This class is not yet fucntional */

using System.Windows.Forms;

namespace AO
{
    public partial class AOFormMessage : Form
    {
        //private string _message;

        //public string Message
        //{
        //    get { return _message; }
        //    set { _message = value; }
        //}

        /// <summary>
        /// Initializes a new instance of the <see cref="AOFormMessage"/> class.
        /// </summary>
        /// <remarks>
        /// Not yet functional.
        /// </remarks>
        public AOFormMessage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Displays the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <remarks>
        /// Not yet functional.
        /// </remarks>
/        public void DisplayMessage(string message)
        {
            lblMessage.Text = message;
        }
    }
}