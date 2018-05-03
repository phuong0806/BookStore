using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class BookCatalogDAO
    {
        BookStoreDbContext db = null;

        public BookCatalogDAO() {
            db = new BookStoreDbContext();
        }

        public List<BookCatalog> getListBookCatalog()
        {
            var result = db.BookCatalogs.Where(catalog => catalog.Status == true).ToList();
            return result;
        }
    }
}
