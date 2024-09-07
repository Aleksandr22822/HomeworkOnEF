using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkOnEF
{
    internal class BookRepository
    {
        internal List<Book> SelectAllBooks(AppContext appContext)
        {
            return appContext.Books.ToList();
        }

        internal Book SelectBookOnId(AppContext appContext, int idBook)
        {
            return appContext.Books.FirstOrDefault(book => book.Id == idBook);
        }

        internal bool AddInTableBooksNewBook(AppContext appContext, Book book)
        {
            bool result;
            appContext.Books.Add(book);
            appContext.SaveChanges();
            return result = true;
        }
        internal bool RemoveOnTableBooksBook(AppContext appContext, Book book)
        {
            bool result;
            appContext.Books.Remove(book);
            appContext.SaveChanges();
            return result = true;
        }
        internal bool UpdateUserDataOnTableBooks(AppContext appContext, int idBook)
        {
            bool result = true;
            var BookForUpdate = appContext.Books.FirstOrDefault(book => book.Id == idBook);
            BookForUpdate.Data = int.Parse(Console.ReadLine());
            appContext.SaveChanges();
            return result = true;
        }

        internal List<Book> SelectBookOnGenreAndData(AppContext appContext)
        {
            Console.WriteLine("Введите жанр книги");
            string genre = Console.ReadLine();

            bool result = true;
            int data1 = 0;
            while (result)
            {
                Console.WriteLine("Введите год, после которого вышла книга в формате ****");
                result = !Int32.TryParse(Console.ReadLine(), out data1);
            }

            result = true;
            int data2 = 0;
            while (result)
            {
                Console.WriteLine("Введите год, до которого вышла книга в формате ****");
                result = !Int32.TryParse(Console.ReadLine(), out data2);
            }

            var querySelectBookOnGenreAndData = appContext.Books.Where(b => b.Genre == genre).Where(b => b.Data > data1).
                Where(b => b.Data < data2).ToList();
            Console.WriteLine($"Книги жанра {genre}, изданные между {data1} и {data2} годами");
            foreach (var book in querySelectBookOnGenreAndData)
            {
                Console.WriteLine($"Название книги: {book.Title}, Автор книги: {book.Author}");
            }
            return querySelectBookOnGenreAndData;
        }

        internal List<Book> SelectBookOnAuthor(AppContext appContext)
        {
            Console.WriteLine("Введите автора книги");
            string author = Console.ReadLine();

            var querySelectBookOnAuthor = appContext.Books.Where(b => b.Author == author).ToList();
            Console.WriteLine($"Найдены следующие книги за авторством {author}:");
            foreach (var book in querySelectBookOnAuthor)
            {
                Console.WriteLine(book.Title);
            }
            return querySelectBookOnAuthor;
        }

        internal List<Book> SelectBookOnGenre(AppContext appContext)
        {
            Console.WriteLine("Введите жанр книги");
            string genre = Console.ReadLine();

            var querySelectBookOnGenre = appContext.Books.Where(b => b.Genre == genre).ToList();
            Console.WriteLine($"Книги жанра {genre}");
            foreach (var book in querySelectBookOnGenre)
            {
                Console.WriteLine(book.Title);
            }
            return querySelectBookOnGenre;
        }

        internal bool CheckingAvailabilityBookOnAuthorAndTitle(AppContext appContext)
        {
            Console.WriteLine("Введите автора книги");
            string author = Console.ReadLine();
            Console.WriteLine("Введите название книги");
            string title = Console.ReadLine();
            var queryCheckAvailabilityBookOnAuthorAndTitle = appContext.Books.
                Where(b => b.Author == author).Where(b => b.Title == title).ToList();
            bool result = false;
            if (queryCheckAvailabilityBookOnAuthorAndTitle == null)
            {
                Console.WriteLine("Таких книг в библиотеке нет");
            }
            else
            {
                result = true;
                foreach (var book in queryCheckAvailabilityBookOnAuthorAndTitle)
                { Console.WriteLine(book.Title); }
            }
            return result;
        }

        internal bool CheckAvailableBook(AppContext appContext)
        {
            bool result = false;
            Console.WriteLine("Чтобы узнать свободна ли книга введите ее название");
            string title = Console.ReadLine();
            var QueryCheckAvailableBook = appContext.Books.Where(b => b.Title == title).ToList();
            if (QueryCheckAvailableBook.Count == 0)
            {
                Console.WriteLine($"Книги с названием {title} нет в библиотеке");
            }
            else if (QueryCheckAvailableBook[0].UserId == null) 
            { 
              Console.WriteLine("Такая книга есть, и она свободна");
            }

            else 
            {
                result = true;
                Console.WriteLine("Данная книга занята");  
            }
            return !result;
        }
        internal int GetBookNoAvailableCount(AppContext appContext) 
        {
            Console.WriteLine("Следующие книги на руках");
            var QueryBookNoAvailable = appContext.Books.Where(b => b.UserId != null).ToList();
            foreach (var book in  QueryBookNoAvailable)
            {
             Console.WriteLine(book.Title);
            }
            Console.WriteLine($"Всего книг на руках: {QueryBookNoAvailable.Count}");
            int CountBook = QueryBookNoAvailable.Count;   
            return CountBook;
        }

        internal Book GetlatestPublishedBook(AppContext appContext)
        {
            var QuerylatestPublishedBook = appContext.Books.OrderByDescending(b => b.Data).First();

            Console.WriteLine(QuerylatestPublishedBook.Title);
            return QuerylatestPublishedBook;
        }

        internal List<Book> GetListBookOrderByByTitle(AppContext appContext)
        {
            var QueryListBookOrderByByTitle = appContext.Books.OrderBy(b => b.Title).ToList();

            foreach (var book in QueryListBookOrderByByTitle)
            { 
            Console.WriteLine($"{book.Title}"); 
            }
            return QueryListBookOrderByByTitle;
        }

        internal List<Book> GetListBookOrderByByDescendingData(AppContext appContext)
        {
            var QueryListBookOrderByByDescendingData = appContext.Books.OrderByDescending(b => b.Data).ToList();

            foreach (var book in QueryListBookOrderByByDescendingData)
            {
                Console.WriteLine($"{book.Title}  {book.Data}");
            }
            return QueryListBookOrderByByDescendingData;
        }

    }
}

