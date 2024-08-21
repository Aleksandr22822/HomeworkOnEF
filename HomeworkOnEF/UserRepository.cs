using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOnEF
{
    internal class UserRepository
    {
        internal List<User> SelectAllUsers(AppContext appContext)
        {
            return appContext.Users.ToList();
        }
    }
}
