﻿using System;
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
            DriversList.Root_tree.Clear();
            DriversList.GetDrives();
            return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, new {_drvList});
        }

        [HttpGet]
        public HttpResponseMessage GetFile([FromUri]string root)
        {
            
            FileBrowse _fileBrowse = new FileBrowse();
            _fileBrowse.GetFilesinRoot(root);

            FilesCounter fc = new FilesCounter();
            if (_fileBrowse.IsDirectory(_fileBrowse.Path_dir, root))
                return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, new { _fileBrowse, fc });
            else
                return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, new { _fileBrowse.IsFolder });
        }
    }
}
