using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace mdpost.Utils
{
    public static class ConfigUtils
    {
        public static Models.ConfigModel ReadConfig()
        {
            string path = System.IO.Path.Combine(System.IO.Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString(), "vconfig.json");
            if (System.IO.File.Exists(path))
            {
                string content = System.IO.File.ReadAllText(path);
                var model = JsonConvert.DeserializeObject<Models.ConfigModel>(content);
                if (model.AppUrls == null || model.AppUrls.Length == 0)
                    model.AppUrls = new string[] { "http://mdpost.mdpost:5030" };
                if (string.IsNullOrEmpty(model.AppName))
                    model.AppName = "MdPost";
                return model;
            }
            else
            {
                return CreateDefaultConfig(path);
            }
        }

        private static Models.ConfigModel CreateDefaultConfig(string path)
        {
            var model = new Models.ConfigModel();
            model.AppUrls = new string[] { "http://mdpost.mdpost:5030" };
            model.AppName = "MdPost";
            model.MenuItems = new List<(string text, string link)>() { new("Home", "/"), new("GitHub", "//github.com/mdpost") };
            using (System.IO.StreamWriter sw = new(path, false))
            {
                sw.Write(JsonConvert.SerializeObject(model));
            }
            return model;
        }
    }
}
