using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL.Casting
{
    public class UserCast
    {
        public static GmailEntities db = new GmailEntities();
        public static User_DTO getUser_DTO(DAL.User user)
        {
            User_DTO newUserDTO = new User_DTO();
            newUserDTO.id = user.id;
            newUserDTO.mail = user.mail;
            newUserDTO.password = user.password;
            newUserDTO.overide = user.overide;
            newUserDTO.attachment = user.attachment;
            List<string> newConcatList = new List<string>();
            newConcatList.AddRange(db.Contacts.Where(i => i.userId == user.id).Select(i=>i.mailContact));
            newUserDTO.contact_list = newConcatList;
            return newUserDTO;
        }
        public static DAL.User getUser_Dal(User_DTO user)
        {
            DAL.User newUserDAL = new DAL.User();
            newUserDAL.id = user.id;
            newUserDAL.mail = user.mail;
            newUserDAL.password = user.password;
            newUserDAL.overide = user.overide;
            newUserDAL.attachment = user.attachment;
            if (user.contact_list != null)
            {
                foreach (var item in user.contact_list)
                {
                    DAL.Contact c = new DAL.Contact();
                    c.userId = user.id;
                    c.mailContact = item;
                    db.Contacts.Add(c);
                }
            }
            return newUserDAL;
        }
    }
}
