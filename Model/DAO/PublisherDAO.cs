using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class PublisherDAO
    {
        BookStoreDbContext db = null;

        public PublisherDAO()
        {
            db = new BookStoreDbContext();
        }

        public List<Publisher> getListPublisher()
        {
            var result = db.Publishers.Where(x => x.Status == true).ToList();
            return result;
        }
    }
}
