using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml.Linq;

namespace BLL
{

    public class Files
    {
         public static void changeappConfig(/*string mail,string pasward*/)
        {
            string path = "Y:/group 2 תשעט/קציר שרי/Server/BLL/System_file/ConsoleApp2.exe.config";
            XDocument doc = XDocument.Load(path);
            var el = doc.Descendants("appSettings").FirstOrDefault();
            el.Elements("add").FirstOrDefault(e => e.Attribute("key").Value == "UserLoginName").Attribute("value").Value = "aaaaaaaaaaaaaa";
            el.Save(path);
        }
        //מה התפקיד של כל פרמטר כאן
        private async Task<System.IO.Stream> Upload(string actionUrl, string paramString, Stream paramFileStream, byte[] paramFileBytes)
        {
            HttpContent stringContent = new StringContent(paramString);
            HttpContent fileStreamContent = new StreamContent(paramFileStream);
            HttpContent bytesContent = new ByteArrayContent(paramFileBytes);
            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(stringContent, "param1", "param1");
                formData.Add(fileStreamContent, "file1", "file1");
                formData.Add(bytesContent, "file2", "file2");
                var response = await client.PostAsync(actionUrl, formData);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                return await response.Content.ReadAsStreamAsync();
            }
        }
        //example 2
        //הורדת לתוך נתיב יחסי איך אני איך אפשר 
        //אית מוציאים מתוך שורת ה-URL
        public static byte[] h()
        {
            using (WebClient client = new WebClient())
            {
                // client.UploadFile(address, filePath);}
                var n = client.DownloadData(@"Y:\group 2 תשעט\קציר שרי\Server\BLL\System_file\ConsoleApp2.exe");
                return n;
            }
        }
    }
}
