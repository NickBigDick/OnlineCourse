using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class UserResultStorage
    {
        public User User { get; }
        public List<string> Results { get; set; }
        public UserResultStorage(User user)
        {
            User = user;
            Results = new List<string>();
        }
    }
}
