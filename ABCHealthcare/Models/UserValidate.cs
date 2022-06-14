using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;

namespace ABCHealthcare.Models
{
    public class UserValidate
    {
        //This method is used to check the user credentials
        public static bool LoginAsync(string username, string password)
        {
            List<User> users = new List<User>();
            using (ABCHealthDBContext db = new ABCHealthDBContext())
            {
                return db.Users.Any(user => user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password == password);

            }
        }
        //This method is used to return the User Details
        public static User GetUserDetails(string username, string password)
        {
            List<User> users = new List<User>();
            using (ABCHealthDBContext db = new ABCHealthDBContext())
            {
                return db.Users.FirstOrDefault(user => user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password == password);

            }
        }
    }
}