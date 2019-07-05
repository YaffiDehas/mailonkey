using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using BLL;

namespace API.Controllers
{
    [RoutePrefix("API/Mail")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MailController : ApiController
    {
        // GET: Mail
        [Route("DownLoad")]
        [HttpGet]
        public IHttpActionResult DownLoad(/*string mail, string password*/)
        {
            BLL.Dowonload.DownLoad("yufi7370@gmail.com","cgzr,vao");
            return Ok();
        }
        [Route("SendMail")]
        [HttpGet]
        public IHttpActionResult SendMail(/*List<DTO.Outbox_DTO> list*/)
        {
            BLL.SendMail.sendMail();
            return Ok();

        }
        [Route("Register")]
        [HttpGet]
        public IHttpActionResult Register()
        {
          var j= BLL.Files.h();
            return Ok();

        }
        [Route("ListContactOnRegister")]
        [HttpGet]
        public IHttpActionResult ListContactOnRegister()
        {
            BLL.Dowonload.ListContactOnRegister("qsrh6523@gmail.com", "mailonkey");
            return Ok();
        }
    }
    }
