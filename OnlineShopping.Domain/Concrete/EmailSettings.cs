using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "foggysteam@hotmail.com";
        public string MailFromAddress = "foggysteam@hotmail.com";
        public bool UseSsl = true;
        public string Username = "foggysteam@hotmail.com";
        public string Password = "PASSWORD";
        public string ServerName = "smtp.live.com";
        public int ServerPort = 587;
    }
}
