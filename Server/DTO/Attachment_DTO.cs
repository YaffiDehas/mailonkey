using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public  class Attachment_DTO
    {
        public byte[] fileBytes;
        public string FileName;

        public Attachment_DTO(byte[] fileBytes, string FileName)
        {
            this.fileBytes = fileBytes;
            this.FileName = FileName;
        }
    }
}
