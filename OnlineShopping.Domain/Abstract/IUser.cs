using OnlineShopping.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Domain.Abstract
{
    public interface IUser
    {
        IEnumerable<User> Users { get; }

        void SaveUser(User user);
        User DeleteUser(int userId);
    }
}
