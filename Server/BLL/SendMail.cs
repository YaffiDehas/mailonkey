using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Search;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
  public  class SendMail
    {
        private static MimeKit.MimeMessage ConvertToMimeMessage(Outbox_DTO message)
        {
            MimeMessage m = new MimeMessage();
            m.To.AddRange(message.To.Select(mm => new MailboxAddress(mm)));
            m.Subject = message.Subject;
            m.Sender = new MailboxAddress(message.From);
            //m.Body = new TextPart(message.Body);
            var builder = new BodyBuilder { TextBody = message.Body };
            var attachment = new MimePart()
            {
                Content = new MimeContent(new MemoryStream(message.Attachment[0].fileBytes), ContentEncoding.Default),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = message.Attachment[0].FileName
            };
            builder.Attachments.Add(attachment);
            m.Body = builder.ToMessageBody();

            return m;
        }
        public static void sendMail(/*List<Outbox_DTO> messages*/)
        {
            //message.From.Add(new MailboxAddress("Joey Tribbiani", "noreply@localhost.com"));
            //message.To.Add(new MailboxAddress("Mrs. Chanandler Bong", "mymail@gmail.com"));
            //message.Subject = "How you doin'?";
            //message.Body = new TextPart("plain") { Text = @"Hey" };
            using (var client = new SmtpClient())
            {
                //imap.gmail.com", 993
                client.Connect("smtp.gmail.com", 587);
                //foreach (var message in messages)
                //{
                ////Note: only needed if the SMTP server requires authentication
                client.Authenticate("qsrh6523@gmail.com", "mailonkey");
                client.Send(ConvertToMimeMessage(create()));
                client.Disconnect(true);
                //}

            }
        }
        public static Outbox_DTO create()
        {
            FileStream stream = File.OpenRead(@"Y:\group 2 תשעט\קציר שרי\Server\DTO\TRY.txt");
            byte[] fileBytes = new byte[stream.Length];
            ////לכתוב לקובץ מצורף בינארי 
            stream.Read(fileBytes, 0, fileBytes.Length);
            stream.Close();
            ////Begins the process of writing the byte array back to a file

            //using (Stream file = File.OpenWrite(@"c:\path\to\your\file\here.txt"))
            //{
            //    file.Write(fileBytes, 0, fileBytes.Length);
            //}
            List<Outbox_DTO> li = new List<Outbox_DTO>();
            li.Add(new Outbox_DTO
                ("qsrh6523@gmail.com", "ruthi0533150414@gmail.com", "this is the SUBJECT",
                "this is the BODY", new Attachment_DTO(fileBytes, stream.Name), 1));
            return li[0];
        }
    }
}
