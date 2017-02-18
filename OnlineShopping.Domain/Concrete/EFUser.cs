using OnlineShopping.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShopping.Domain.Entities;

namespace OnlineShopping.Domain.Concrete
{
    public class EFUser : IUser
    {
        private readonly EFDbContext context = new EFDbContext();
        public IEnumerable<User> Users
        {
            get { return context.Users; }
        }



        public void SaveUser(User user)
        {
            if (user.UserId == 0)
            {
                context.Users.Add(user);
            }
            else
            {

                User dbEntry = context.Users.Find(user.UserId); 

                dbEntry.Username = user.Username;
                dbEntry.Password = user.Password;

            }
            context.SaveChanges();
        }

        public User DeleteUser(int userId)
        {
            User dbEntry = context.Users.Find(userId);
            if (dbEntry != null)
            {
                context.Users.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
