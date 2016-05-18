using System;
using System.IO;
using TestFileBrowser.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestFileBrowser.Controllers
{
    public class FilesController : ApiController
    {
        public FilesController()
        {

        }
        public HttpResponseMessage GetPCDrives()
        {
            DriversList _drvList = new DriversList();
            DriversList.Files_temp.Clear();
            DriversList.GetDrives();
            return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, new {_drvList});
        }

        [HttpGet]
        public HttpResponseMessage GetFile([FromUri]string root)
        {
            
            FileBrowse _fileBrowse = new FileBrowse();
            _fileBrowse.GetFilesinRoot(root);

            FilesCounter fc = new FilesCounter();

            return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, new {_fileBrowse,fc });
        }
    }
}
