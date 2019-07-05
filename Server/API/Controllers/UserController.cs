using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using BLL;
using System.Web.Http;
using DTO;
using System.Web.Http.Cors;
using System.Net.Http;
using System.IO;
using System.Net.Http.Headers;

namespace GUI.Controllers
{
    [RoutePrefix("API/User")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        [Route("Login")]
        [HttpGet]
        public IHttpActionResult Login(string mail, string password)
        {
            User_DTO userDTO = BLL.Casting.UserCast.getUser_DTO(new DAL.User(BLL.User.Login(mail, password)));
            return Ok(userDTO);

        }
        [Route("Register")]
        [HttpPost]
        public IHttpActionResult Register(User_DTO user)
        {

            return Ok(BLL.User.Register(BLL.Casting.UserCast.getUser_Dal(user)));

        }

        [Route("UpDate")]
        [HttpPost]
        public IHttpActionResult UpDate(User_DTO user)
        {
            BLL.User.Update(BLL.Casting.UserCast.getUser_Dal(user));
            return Ok();
        }
        //    public HttpResponseMessage Post(string version, string environment,
        //string filetype)
        //    {
        //        var path = @"Y:\group 2 תשעט\קציר שרי\Server\BLL\System_file\ConsoleApp2.exe";
        //        HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
        //        var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
        //        result.Content = new StreamContent(stream);
        //        result.Content.Headers.ContentType =
        //            new MediaTypeHeaderValue("application/octet-stream");
        //        return result;
        //    }
        [Route("downlaodExe")]
        [HttpGet]
        public  string f()
        {
            string path = @"Y:\group 2 תשעט\קציר שרי\Server\BLL\System_file\ConsoleApp2.exe";
            byte[] bufferArray = File.ReadAllBytes(path);
            string base64EncodedString = Convert.ToBase64String(bufferArray);
                bufferArray = Convert.FromBase64String(base64EncodedString);
            //File.WriteAllBytes(@"Y:\group 2 תשעט\קציר שרי\Server\BLL\System_file\ConsoleApp2.exe", bufferArray);
            return base64EncodedString;

        }
        //public HttpResponseMessage Generate()
        //{
        //    var stream = new MemoryStream();
        //    // processing the stream.

        //    var result = new HttpResponseMessage(HttpStatusCode.OK)
        //    {
        //        Content = new ByteArrayContent(stream.ToArray())
        //    };
        //    result.Content.Headers.ContentDisposition =
        //        new ContentDispositionHeaderValue("attachment")
        //        {
        //            FileName = @"Y:\group 2 תשעט\קציר שרי\Server\BLL\System_file\ConsoleApp2.exe"
        //        };
        //    result.Content.Headers.ContentType =
        //        new MediaTypeHeaderValue("application/octet-stream");

        //    return result;
        //}
        [Route("downloadProgram")]
        [HttpGet]      
        public HttpResponseMessage Generate()
        {
            using (var webClient = new System.Net.WebClient())
            {
                byte[] data = webClient.DownloadData(@"Y:\group 2 תשעט\קציר שרי\Server\BLL\System_file\ConsoleApp2.exe");
                var ms = new System.IO.MemoryStream(data);

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(ms.ToArray())
            };
            result.Content.Headers.ContentDisposition =
                new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = "test.txt"
                };
            result.Content.Headers.ContentType =
                new MediaTypeHeaderValue("application/octet-stream");

            return result;
            }
        }

        [Route("changeappConfig")]
        [HttpGet]
        public IHttpActionResult changeappConfig()
        {
            BLL.Files.changeappConfig();
            return Ok();
        }
        public byte[] h()
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