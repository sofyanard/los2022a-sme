using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace SME
{
    public class myMail
    {
        public myMail()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void SendMail(string messageMail, string toMail, string ccMail, string bccMail, string subjMail, Attachment Data)
        {
            MailMessage Mail = new MailMessage();
            List<string> LtoMail = toMail.Split(',').ToList<string>();

            for (int i = 0; i < LtoMail.Count; i++)
            {
                Mail.To.Add(LtoMail[i].ToString());
            }

            if (ccMail.Trim() != "")
            {
                List<string> LccMail = ccMail.Trim().Split(',').ToList<string>();
                for (int i = 0; i < LccMail.Count; i++)
                {
                    Mail.CC.Add(LccMail[i].ToString().Trim());
                }
            }

            if (bccMail.Trim() != "")
            {
                List<string> LbccMail = bccMail.Trim().Split(',').ToList<string>();
                for (int i = 0; i < LbccMail.Count; i++)
                {
                    Mail.Bcc.Add(LbccMail[i].ToString().Trim());
                }
            }

            if (Data != null)
            {
                Mail.Attachments.Add(Data);
            }

            Mail.Subject = subjMail;
            Mail.Body = messageMail;
            Mail.BodyEncoding = System.Text.Encoding.ASCII;
            Mail.Priority = MailPriority.High;

            SmtpClient smtp = new SmtpClient();
            smtp.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtp.Send(Mail);
            Mail.Attachments.Dispose();
        }
    }
}