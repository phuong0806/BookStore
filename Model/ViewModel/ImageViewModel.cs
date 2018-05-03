namespace Model.ViewModel
{
    public class ImageViewModel
    {
        public string name { get; set; }
        public string path { get; set; }

        public ImageViewModel(string name, string path)
        {
            this.name = name;
            this.path = path;
        }
    }
}