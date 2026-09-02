#region PROJECT_HEADER
//   PROJECT: myAvatool
//   VERSION: 0.12.0-alpha
//     BUILD: 180227
//   AUTHORS: development@aprettycoolprogram.com
// COPYRIGHT: 2017 A Pretty Cool Program
//   LICENSE: Apache License, Version 2.0 [http://www.apache.org/licenses/LICENSE-2.0]
// MORE INFO: http://aprettycoolprogram.com/myAvatool
#endregion

#region CLASS_DESCRIPTION
// Does things with email.
#endregion

// v0.10.0-alpha

using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace Du
{
    public class DuMail
    {
        /// <summary>Build an email package.</summary>
        /// <returns>An email package.</returns>
        /// <remarks>Contains all of the necessary data to send an email message</remarks>
        /// <build>180225</build>
        public static Dictionary<string,string> BuildPackage()
        {
            var wrkDictionary = new Dictionary<string,string>();

            return wrkDictionary;
        }

        /// <summary>Sends an email.</summary>
        /// <param name="emailPackage">Contains all of the email data.</param>
        /// <remarks>Send an email. An emailPackage is required, and is generally created by using
        /// DuEmail.BuildPackage().</remarks>
        /// <build>180225</build>
        public static void Send(Dictionary<string, string> emailPackage)
        {
            var message = new MailMessage
            {
                From    = new MailAddress(emailPackage["fromAddress"]),
                Subject = emailPackage["messageSubject"],
                Body    = emailPackage["messageBody"]
            };

            // Seprate each To address at comma characters, and add to the mail message.
            foreach (var item in emailPackage["toAddresses"].Split(','))
            {
                message.To.Add(item);
            }

            // Setup new SMTP object.
            var smtp = new SmtpClient
            {
                Host        = emailPackage["smtpHost"],
                Port        = Convert.ToInt32(emailPackage["smtpPort"]),
                Credentials = new System.Net.NetworkCredential(emailPackage["emailUsername"], emailPackage["emailPassword"]),
                EnableSsl   = Convert.ToBoolean(emailPackage["sslEnabled"])
            };

            // Send message
            smtp.Send(message);
        }
    }
}