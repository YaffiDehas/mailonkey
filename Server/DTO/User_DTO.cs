using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class User_DTO
    {
        public int id { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public bool attachment { get; set; }
        public bool? overide { get; set; }
        public string preference { get; set; }
        public List<string> contact_list { get; set; }
    }
}
