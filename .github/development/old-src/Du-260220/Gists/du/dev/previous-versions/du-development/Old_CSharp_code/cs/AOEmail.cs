/* A class for AO.cs that does various things with email.
 * v00.53.03.161219
 * http://aprettycoolprogram.com/ao
 */

using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net.Mime;

namespace AO
{
    public class AOEmail
    {
        /// <summary>
        /// Builds the email package.
        /// </summary>
        /// <param name="fromAccountAddress"> From account address.                     </param>
        /// <param name="fromAccountUser">    From account user.                        </param>
        /// <param name="fromAccountPass">    From account pass.                        </param>
        /// <param name="subject">            The subject.                              </param>
        /// <param name="body">               The body.                                 </param>
        /// <param name="host">               The host.                                 </param>
        /// <param name="smptPort">           The SMPT port.                            </param>
        /// <param name="SSLRequired">        if set to <c> true </c> [SSL required].   </param>
        /// <returns></returns>
        /// <remarks>
        /// None.
        /// </remarks>
        public static Dictionary<string, string> BuildPackage(string fromAccountAddress, string fromAccountUser, string fromAccountPass, string subject, string body, string host, int smptPort, bool SSLRequired)
        {
            var emailPackage = new Dictionary<string, string>();

            emailPackage.Add("emailAccountFrom", fromAccountAddress);
            emailPackage.Add("emailSubject", subject);
            emailPackage.Add("emailBody", body);
            emailPackage.Add("emailHost", host);
            emailPackage.Add("emailPort", smptPort.ToString());
            emailPackage.Add("emailAccountUsername", fromAccountUser);
            emailPackage.Add("emailAccountPassword", fromAccountPass);
            emailPackage.Add("emailRequireSSL", SSLRequired.ToString());

            return emailPackage;
        }

        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="toAddresses">To addresses.</param>
        /// <param name="attachments">The attachments.</param>
        /// <param name="emailPackage">The email package.</param>
        /// <remarks>
        /// [1] Set the "From" address, loop through the list of "To" addresses, and create the email subject and body.
        ///     If the attachments list isn't empty, loop through that and add any attachments. Then build the SMTP
        ///     info, and send the message.After the message is sent, manually clear out the attchments and make sure
        ///     they are disposed of properly.
        /// [T] Add "using" to this so things are disposed of properly.
        /// </remarks>
        public static void SendEmail(List<string> toAddresses, List<string> attachments, Dictionary<string, string> emailPackage)
        {
            MailMessage emailMessage = new MailMessage();

            emailMessage.From = new MailAddress(emailPackage["emailFrom"]);                                             // [1]

            foreach (var item in toAddresses)
            {
                emailMessage.To.Add(item);
            }

            emailMessage.Subject = emailPackage["emailSubject"];
            emailMessage.Body = emailPackage["emailBody"];

            if (attachments != null)
            {
                foreach (var attachment in attachments)
                {
                    Attachment attachedFile = new Attachment(attachment, MediaTypeNames.Application.Octet);
                    emailMessage.Attachments.Add(attachedFile);
                }
            }

            SmtpClient smtp = new SmtpClient();
            smtp.Host = emailPackage["emailHost"];
            smtp.Port = Convert.ToInt32(emailPackage["emailPort"]);
            smtp.Credentials = new System.Net.NetworkCredential(emailPackage["emailUsername"], emailPackage["emailPassword"]);
            smtp.EnableSsl = Convert.ToBoolean(emailPackage["emailRequireSSL"]);

            smtp.Send(emailMessage);

            if (emailMessage.Attachments != null)
            {
                foreach (var attachment in emailMessage.Attachments)
                {
                    attachment.Dispose();
                }
                emailMessage.Attachments.Dispose();
                toAddresses.Clear();
            }
        }
    }
}