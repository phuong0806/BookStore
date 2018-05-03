using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace Common
{
    public class ImageHelper 
    {
        public List<ImageViewModel> loadListImage()
        {
            string[] filesindirectory = Directory.GetFiles(System.Web.HttpContext.Current.Server.MapPath("~/Assets/admin/img/upload"));
            List<ImageViewModel> images = new List<ImageViewModel>();
            foreach (string item in filesindirectory)
            {
                string path = String.Format("/Assets/admin/img/upload/{0}", System.IO.Path.GetFileName(item));
                string name = System.IO.Path.GetFileName(item);
                images.Add(new ImageViewModel(name, path));
            }

            return images;
        }

        public string saveImage(HttpPostedFileBase file)
        {
            var path = "";
            var fileName = Path.GetFileName(file.FileName);
            var dir = "/Assets/admin/img/upload/";
            if (file.ContentLength > 0)
            {
                if (Path.GetExtension(file.FileName).ToLower() == ".jpg" || Path.GetExtension(file.FileName).ToLower() == ".jpeg" || Path.GetExtension(file.FileName).ToLower() == ".png")
                {
                    path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~" + dir), fileName);
                    if (!System.IO.File.Exists(path))
                    {
                        file.SaveAs(path);
                    }
                    return dir + fileName;
                }
            }
            return "";
        }

        public List<ImageViewModel> DeleteImageByfilename(string filename)
        {
            string filepath = System.Web.HttpContext.Current.Server.MapPath("~" + filename);
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);
            }
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();

            return loadListImage();
        }
    }
}
