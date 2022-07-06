using mdpost.Models;

namespace mdpost.Utils
{
    public static class StringUtil
    {
        public static string TitleFromFilename(string path)
        {
            string filename = path.Substring(2).Replace("posts/", "").Replace(".md", "");
            string[] filenameArr = filename.Split('/');
            filename = filenameArr[filenameArr.Length - 1];
            filename = filename[0].ToString().ToUpper() + filename.Substring(1);
            filename = filename.Replace('_', ' ');
            return filename;
        }
        
        public static string BreadcrumbsHTMLFromFilename(string path)
        {
            string filename = path.Substring(2).Replace("posts/", "").Replace(".md", "");
            filename = filename.Replace('_', ' ');
            string[] filenameArr = filename.Split('/');
            BreadcrumbItem[] breadcrumbs = new BreadcrumbItem[filenameArr.Length];
            
            string url = "";
            for (int i = 0; i < filenameArr.Length; i++)
            {
                
                url += "/" + filenameArr[i];
                
                string title = filenameArr[i];
                title = title[0].ToString().ToUpper() + title.Substring(1);
                
                breadcrumbs[i] = new BreadcrumbItem(url, title);
            }
            string bc = "<p><a href=\"/\"> Home</a>  /  ";
            foreach (var crumb in breadcrumbs)
            {
                bc += $"<a href=\"{crumb.Url}\">{crumb.Text}</a>  /  ";
            }
            bc += "</p>";
            return bc;
        }
        
    }
}
