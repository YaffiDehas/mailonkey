using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class User
    {
        public static GmailEntities db = new GmailEntities();

        //הרשמה-בלי בדיקות ולידציה הכנסת משתמש חדש
        public static bool Register(DAL.User user)
        {
            var a = db.Users.Where(u=>u.mail==user.mail).FirstOrDefault();
            if (a != null)
                return false;
            db.Users.Add(user);
            db.SaveChanges();
            return true;
        }
        //כניסת משתמש -לצורך עדכון /שינוי פרטיו
        //מקבלת שם משתמש-מייל 
        public static DAL.User Login(string mail_account, String password)
        {

            return db.Users.Where(u => u.mail == mail_account).FirstOrDefault();
        }
        public static bool Update(DAL.User update_user)
        {

            DAL.User old_user = db.Users.Where(u => u.mail == update_user.mail).FirstOrDefault();
            old_user= update_user;
            db.SaveChanges();
            return true;
        }

    }
}
