using System.Collections;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace Account
{
    public class MailSender : MonoBehaviour
    {
        private const string ToEmail = "bolodem3rda@gmail.com";
        //private const string MyEmail = "joao.santos@hivolve.com";
        private const string MyEmail = "info@hivolve.com";
        #region password
        private const string MyPassword = "9bc(*Z%@#ZYR";
        #endregion

        //private void Start()
        //{
        //    var data = new LoginData()
        //    {
        //        email = ToEmail,
        //        password = "123123"
        //    };
        //    StartCoroutine(SendResetPasswordEmail(data));
        //}

        public IEnumerator SendResetPasswordEmail(LoginData data)
        {
            // Send email
            var mail = new MailMessage();
            mail.From = new MailAddress(MyEmail);
            mail.To.Add(data.email);
            mail.Subject = "Fricon Europe AR - Reset Password";
            mail.Body = GetMessageBody(data.password);

            Debug.Log("Connecting to SMTP server");
            var smtpServer = new SmtpClient("mail.hivolve.com")
            {
                UseDefaultCredentials = false,
                Port = 8889,
                Credentials = new NetworkCredential(MyEmail, MyPassword) as ICredentialsByHost, 
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            ServicePointManager.ServerCertificateValidationCallback =
                delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                { return true; };
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            
            Debug.Log("Sending message");

            smtpServer.Send(mail);

            yield return null;
        }

        public string GetMessageBody(string newPassword)
        {
            return "Your new password is " + newPassword;
        }
    }
}