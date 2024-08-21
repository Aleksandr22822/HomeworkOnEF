namespace HomeworkOnEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppContext appContext = new AppContext();
            UserRepository userRepository = new UserRepository();
            List <User> users = userRepository.SelectAllUsers(appContext);
            foreach (User user in users) { Console.WriteLine(user); }
        }
    }
}
