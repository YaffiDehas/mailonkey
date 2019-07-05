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
    public class Dowonload
    {
        public static GmailEntities db = new GmailEntities();
        public static List<Inbox_DTO> DownLoad(string mail, string passward)
        {
            DAL.User user = new DAL.User();
            user = db.Users.Where(u => u.mail == mail).FirstOrDefault();
            using (var client = new ImapClient())
            {
                List<Inbox_DTO> mailMessages = new List<Inbox_DTO>();
                client.Connect("imap.gmail.com", 993, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(mail, passward);
                client.Inbox.Open(FolderAccess.ReadWrite);
                var uids = client.Inbox.Search(SearchQuery.HasGMailLabel("unread"));
                var messages = client.Inbox.Fetch(uids, MessageSummaryItems.BodyStructure | MessageSummaryItems.UniqueId | MessageSummaryItems.Full);
                foreach (var messag in messages)
                {
                    int count = 1;
                    var message = client.Inbox.GetMessage(messag.UniqueId);
                    //מעונין באנשי קשר מועדפים
                    if (user.preference == 1)
                    {
                        if (user.Contacts.First(i => i.mailContact == message.From.ToString()) == null)
                            continue;
                    }
                    else
                    {
                        //מעונין באנשי קשר דחויים
                        if (user.preference == 2)
                        {
                            if (user.Contacts.First(i => i.mailContact == message.From.ToString()) != null)
                                continue;
                        }
                    }

                    Inbox_DTO current_mail = new Inbox_DTO();
                    current_mail.Id = (int)messag.UniqueId.Id;
                    current_mail.From = message.From.ToString();
                    current_mail.To = message.To.ToString();
                    current_mail.Subject = message.Subject.ToString();
                    current_mail.Body = message.Body.ToString();
                    var text = message.TextBody;
                    if (user.attachment)
                    {
                        foreach (var attachment in messag.Attachments)
                        {
                            var mime = (MimePart)client.Inbox.GetBodyPart(messag.UniqueId, attachment);
                            var fileName = mime.FileName;
                            if (string.IsNullOrEmpty(fileName))
                                fileName = string.Format("unnamed-{0}", count++);
                            current_mail.Attachment.Add(fileName);
                            using (var stream = File.Create(fileName))
                                mime.Content.DecodeTo(stream);
                        }
                    }
                    //לסמן מייל כנקרא 
                    client.Inbox.AddFlags(uids, MessageFlags.Seen, true);
                    mailMessages.Add(current_mail);
                }
                client.Disconnect(true);
                return mailMessages;
            }
        }
        public static HashSet<string> ListContactOnRegister(string mail, string passward)
        {
            HashSet<string> contactList = new HashSet<string>();
            using (var client = new ImapClient())
            {
                client.Connect("imap.gmail.com", 993, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(mail, passward);
                client.Inbox.Open(FolderAccess.ReadWrite);
                var uids = client.Inbox.Search(SearchQuery.HasGMailLabel("all"));
                var messages = client.Inbox.Fetch(uids, MessageSummaryItems.BodyStructure | MessageSummaryItems.UniqueId | MessageSummaryItems.Full);
                foreach (var messag in messages)
                {
                    var message = client.Inbox.GetMessage(messag.UniqueId);
                    contactList.Add(message.From.ToString());

                }
                client.Disconnect(true);
                return contactList;

            }

        }
        public static HashSet<string> UpdateListContact(string mail, string passward, HashSet<string> contactList)
        {
            using (var client = new ImapClient())
            {
                client.Connect("imap.gmail.com", 993, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(mail, passward);
                client.Inbox.Open(FolderAccess.ReadWrite);
                var uids = client.Inbox.Search(SearchQuery.HasGMailLabel("unread"));
                var messages = client.Inbox.Fetch(uids, MessageSummaryItems.BodyStructure | MessageSummaryItems.UniqueId | MessageSummaryItems.Full);
                foreach (var messag in messages)
                {
                    var message = client.Inbox.GetMessage(messag.UniqueId);
                    contactList.Add(message.Sender.Address.ToString());

                }
                client.Disconnect(true);
                return contactList;


            }
        }
    }
    //private static MimeMessage ConvertToMimeMessage(Outbox_DTO message)
    //{
    //    MimeMessage m = new MimeMessage();
    //    m.To.AddRange(message.To.Select(mm => new MailboxAddress(mm)));
    //    m.Subject = message.Subject;
    //    m.Sender = new MailboxAddress(message.From);
    //    //m.Body = new TextPart(message.Body);
    //    var builder = new BodyBuilder { TextBody = message.Body };
    //    var attachment = new MimePart()
    //    {
    //        Content = new MimeContent(new MemoryStream(message.Attachment[0].fileBytes), ContentEncoding.Default),
    //        ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
    //        ContentTransferEncoding = ContentEncoding.Base64,
    //        FileName = message.Attachment[0].FileName
    //    };
    //    builder.Attachments.Add(attachment);
    //    m.Body = builder.ToMessageBody();

    //    return m;
    //}
    //public static void SendMail(/*List<Outbox_DTO> messages*/)
    //{
    //    //message.From.Add(new MailboxAddress("Joey Tribbiani", "noreply@localhost.com"));
    //    //message.To.Add(new MailboxAddress("Mrs. Chanandler Bong", "mymail@gmail.com"));
    //    //message.Subject = "How you doin'?";
    //    //message.Body = new TextPart("plain") { Text = @"Hey" };
    //    using (var client = new SmtpClient())
    //    {
    //        //imap.gmail.com", 993
    //        client.Connect("smtp.gmail.com", 587);
    //        //foreach (var message in messages)
    //        //{
    //        ////Note: only needed if the SMTP server requires authentication
    //        client.Authenticate("qsrh6523@gmail.com", "mailonkey");
    //        client.Send(ConvertToMimeMessage(create()));
    //        client.Disconnect(true);
    //        //}

    //    }
    //}
    //public static Outbox_DTO create()
    //{
    //    FileStream stream = File.OpenRead(@"Y:\group 2 תשעט\קציר שרי\Server\DTO\TRY.txt");
    //    byte[] fileBytes = new byte[stream.Length];
    //    ////לכתוב לקובץ מצורף בינארי 
    //    stream.Read(fileBytes, 0, fileBytes.Length);
    //    stream.Close();
    //    ////Begins the process of writing the byte array back to a file

    //    //using (Stream file = File.OpenWrite(@"c:\path\to\your\file\here.txt"))
    //    //{
    //    //    file.Write(fileBytes, 0, fileBytes.Length);
    //    //}
    //    List<Outbox_DTO> li = new List<Outbox_DTO>();
    //    li.Add(new Outbox_DTO
    //        ("qsrh6523@gmail.com", "ruthi0533150414@gmail.com", "this is the SUBJECT",
    //        "this is the BODY", new Attachment_DTO(fileBytes, stream.Name), 1));
    //    return li[0];
    //}

}


