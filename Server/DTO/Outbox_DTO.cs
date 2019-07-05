using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DTO
{
    public class Outbox_DTO
    {
        public string Id { get; set; }
        public string From { get; set; }
        public List<string> To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<Attachment_DTO> Attachment { get; set; }
        public int Status { get; set; }
        public Outbox_DTO(string from, /*List<*/string/*>*/ to, string subject,string body,/*List<*/Attachment_DTO/*>*/ attachment,int status)
        {
            To = new List<string>();
            Attachment = new List<Attachment_DTO>();
            From = from;
            To.Add(to);
            Subject = subject;
            Body = body;
            Attachment.Add(attachment);
            Status = status;
        }
    }
}
