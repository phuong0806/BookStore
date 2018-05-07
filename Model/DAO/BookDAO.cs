using Model.EF;
using Model.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Model.DAO
{
    public class BookDAO
    {
        BookStoreDbContext db = null;

        public BookDAO()
        {
            db = new BookStoreDbContext();
        }

        public int insertBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return book.ID;
        }

        public List<BookViewModel> getListBooks(int top)
        {
            var result = (from book in db.Books.ToList()
                          join publisher in db.Publishers on book.PublisherID equals publisher.ID
                          join category in db.BookCategories on book.CategoryID equals category.ID
                          join catalog in db.BookCatalogs on category.catalogID equals catalog.ID
                          where book.Status == true
                          select new BookViewModel()
                          {
                              ID = book.ID,
                              Name = book.Name,
                              Authors = getAuthorOfBookById(book.ID),
                              Alias = book.Alias,
                              Price = book.Price,
                              Quanlity = book.Quanlity,
                              ViewCount = book.ViewCount,
                              Status = book.Status,
                              Image = book.Image,
                              MoreImages = book.MoreImages,
                              PublicationDate = book.PublicationDate,
                              BookCover = book.BookCover,
                              Catalog = catalog.Name,
                              Category = category.ID,
                              Publibsher = publisher.ID,
                          }).Take(top).ToList();
            return result;
        }

        public string getAuthorOfBookById(int BookID)
        {
            var data = (from book in db.Books
                          from author in book.Authors
                          join author_book in db.Books on book.ID equals author_book.ID
                          where book.ID == BookID
                          select new BookViewModel()
                          {
                              Name = author.Name,
                          }).ToList();
            string result = "";
            int i = 0;
            foreach (var item in data)
            {
                i++;
                if (data.Count == i)
                {
                    result += item.Name;
                    return result;
                }
                result += item.Name + ",";
            }
            return result;
        }

        public bool deleteBook(int id)
        {
            try
            {
                var book = db.Books.Find(id);
                if (new Author_Book_DAO().deleteBookInAuthorBook(book))
                {
                    db.Books.Remove(book);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        public int countBook()
        {
            return db.Books.Where(x => x.Status == true).Count();
        }

        public Book getBookById(int id)
        {
            return db.Books.Find(id);
        }

        public bool checkAliasExist(string Alias)
        {
            if (db.Books.Any(x => x.Alias == Alias))
            {
                return true;
            }
            return false;
        }

        public bool UpdateBookDAO(int id, BookViewModel bookView)
        {
            try
            {
                Book book = new Book();
                book = db.Books.Where(x => x.ID == id).FirstOrDefault();

                List<int> list = new List<int>();

                foreach (var item in book.Authors.ToList())
                {
                    book.Authors.Remove(item);
                }

                foreach (var item in bookView.SelectedValuesAuthor)
                {
                    list.Add(item);
                }

                foreach (var item in list)
                {
                    book.Authors.Add(db.Authors.FirstOrDefault(x => x.ID == item));
                }
              
                book.Name = bookView.Name;
                book.Alias = bookView.Alias;
                book.CategoryID = bookView.Category;
                book.Content = bookView.Content;
                book.Price = bookView.Price;
                book.BookCover = bookView.BookCover;
                book.NumberPages = bookView.NumberPages;
                book.PublisherID = bookView.Publibsher;
                book.PublicationDate = bookView.PublicationDate;
                book.Size = bookView.Size;
                book.Quanlity = bookView.Quanlity;
                book.Image = bookView.Image;
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                string x = ex.GetType().Name;
                return false;
            }

        }

        public bool checkName(string name)
        {
            if (db.Books.Any(x => x.Name == name))
            {
                return true;
            }
            return false;
        }

        public List<BookViewModel> GetBook()
        {
            DateTime a = DateTime.Now;
            int month=a.Month;

            var listBook = (from book in db.Books
                            from author in book.Authors
                            join author_book in db.Books on book.ID equals author_book.ID
                            where book.Status==true && book.PublicationDate.Value.Month==month
                            select new BookViewModel()
                            {
                                Authors = author.Name,
                                Name = book.Name,
                                Image = book.Image,
                                Price = book.Price,
                                PublicationDate = book.PublicationDate

                            }).ToList();
            return listBook;
            //return db.Books.Where(x => x.Status == true).ToList();
        }

        public List<BookViewModel> GetBookPre()
        {
            DateTime a = DateTime.Now;
            int month = a.Month-1;

            var listBook = (from book in db.Books
                            from author in book.Authors
                            join author_book in db.Books on book.ID equals author_book.ID
                            where book.Status == true && book.PublicationDate.Value.Month == month
                            select new BookViewModel()
                            {
                                Authors = author.Name,
                                Name = book.Name,
                                Image = book.Image,
                                Price = book.Price,
                                PublicationDate = book.PublicationDate

                            }).ToList();
            return listBook;
        }

        public List<BookViewModel> GetBookByAliasCategory(string Alias)
        {
            var ctlg = db.BookCategories.Where(x => x.Alias == Alias).FirstOrDefault();
            var listBook = (from book in db.Books
                            from author in book.Authors
                            join author_book in db.Books on book.ID equals author_book.ID
                            where book.Status == true && book.CategoryID == ctlg.ID
                            select new BookViewModel()
                            {
                                Authors = author.Name,
                                Name = book.Name,
                                Image = book.Image,
                                Price = book.Price,
                                Alias = book.Alias

                            }).ToList();
            return listBook;
        }
        public List<BookViewModel> GetNewBook()
        {
            DateTime a = DateTime.Now;
            int month = a.Month;

            var listBook = (from book in db.Books
                            from author in book.Authors
                            join author_book in db.Books on book.ID equals author_book.ID
                            where book.Status == true && book.PublicationDate.Value.Month == month
                            select new BookViewModel()
                            {
                                Authors = author.Name,
                                Name = book.Name,
                                Image = book.Image,
                                Price = book.Price,
                                Alias = book.Alias

                            }).ToList();
            return listBook;
        }
    }
}
