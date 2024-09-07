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

        internal User SelectUserOnId(AppContext appContext, int idUser)
        {
            return appContext.Users.FirstOrDefault(user => user.Id == idUser);
        }

        internal bool AddInTableUsersNewUser(AppContext appContext, User user)
        {
            bool result;
            appContext.Users.Add(user);
            appContext.SaveChanges();
            return result = true;


        }
        internal bool RemoveOnTableUsersUser(AppContext appContext, User user)
        {
            bool result;
            appContext.Users.Remove(user);
            appContext.SaveChanges();
            return result = true;
        }
        internal bool UpdateUserNameOnTableUsers(AppContext appContext, int idUser)
        {
            bool result;
            var UserForUpdate = appContext.Users.FirstOrDefault(user => user.Id == idUser);
            UserForUpdate.Name = Console.ReadLine();
            appContext.SaveChanges();
            return result = true;
        }
    }

}
