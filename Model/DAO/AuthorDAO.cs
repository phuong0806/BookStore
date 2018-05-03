using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class AuthorDAO
    {
        BookStoreDbContext db = null;

        public AuthorDAO()
        {
            db = new BookStoreDbContext();
        }

        public List<Author> getListAuthor()
        {
            var result = db.Authors.Where(x => x.Status == true).ToList();
            return result;
        }
    }
}
