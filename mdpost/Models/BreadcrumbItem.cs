namespace mdpost.Models
{
    public class BreadcrumbItem
    {
        public string Url { get; set; }
        public string Text { get; set; }

        public BreadcrumbItem(string url, string text)
        {
            Url = url;
            Text = text;
        }

    }
}
