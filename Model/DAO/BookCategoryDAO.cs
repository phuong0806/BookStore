using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class BookCategoryDAO
    {
        BookStoreDbContext db = null;

        public BookCategoryDAO()
        {
            db = new BookStoreDbContext();
        }

        public List<BookCategory> getListCategory()
        {
            var result = db.BookCategories.Where(x => x.Status == true).ToList();
            return result;
        }
    }
}
