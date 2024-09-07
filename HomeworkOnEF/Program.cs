using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HomeworkOnEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (AppContext appContext = new AppContext())
            {
                var user1 = new User {Name = "Сашка", Email = "Sasha@yandex.ru", Role = "Работяга с завода" };
                var user2 = new User {Name = "Ефрентий", Email = "Efruhca@yandex.ru", Role = "Священик" };
                var user3 = new User {Name = "Махмуд", Email = "Babah.com", Role = "Подрывник-любитель" };

                appContext.Users.AddRange(user1,user2, user3);
               

                var book1 = new Book {Title = "Станки завода", Data = 1992, Author = "Стонкович А.А.", Genre = "Техника"};
                var book2 = new Book {Title = "Богословник", Data = 998, Author = "Отцы наши", Genre = "Богословие"};
                var book3 = new Book {Title = "Рецепт динамита в Майнкрафт", Data = 2012, Author = "Неизвестый", Genre = "Наука" };
                appContext.Books.AddRange(book1, book2, book3);
                

                book1.user = user1;
               

                book2.user = user2;
                

                book3.user = user3;
               

                appContext.SaveChanges();

                BookRepository bookRepository = new BookRepository();
                bookRepository.GetListBookOrderByByDescendingData(appContext);
            }
        }
    }
}
