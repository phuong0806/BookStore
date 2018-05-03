using Model.EF;
using System.Collections.Generic;
using System.Linq;

namespace Model.DAO
{
    public class Author_Book_DAO
    {
        private BookStoreDbContext db = null;

        public Author_Book_DAO()
        {
            db = new BookStoreDbContext();
        }

        public int insertAuthorBook(Book book, int[] Authors)
        {
            List<Author> listAuthor = new List<Author>();
            foreach (var item in Authors)
            {
                listAuthor.Add(db.Authors.FirstOrDefault(x => x.ID == item));
            }

            foreach (var item in listAuthor)
            {
                book.Authors.Add(item);
            }
            db.Books.Add(book);
            db.SaveChanges();

            return book.ID;
        }

       public bool deleteBookInAuthorBook(Book book)
       {
                foreach (var item in book.Authors)
                {
                    var author = db.Authors.FirstOrDefault(x => x.ID == item.ID);
                    book.Authors.Remove(author);
                }
                return true;
       }
    }
}