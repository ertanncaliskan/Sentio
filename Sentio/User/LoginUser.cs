using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentio.User
{
    public class LoginUser
    {
        public long Id { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public bool IsOnline { get; set; }
    }
}
