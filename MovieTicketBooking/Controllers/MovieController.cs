using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace MovieTicketBooking.Controllers
{
   
    public class MovieController : Controller
    {
        // GET: Movie
        [HandleError]
        public ActionResult Index()
        {
            return View();
        }
        [HandleError]
        public ActionResult Action()
        {
            return View();
        }
        [HandleError]
        public ActionResult Comedy()
        {
            return View();
        }
        [HandleError]
        public ActionResult Horror()
        {
            return View();
        }
        [HandleError]
        public ActionResult Adventure()
        {
            return View();
        }
        [HandleError]
        public ActionResult Family()
        {
            return View();
        }
        [HandleError]
        private static CloudBlobContainer GetCloudBlobContainer()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                    CloudConfigurationManager.GetSetting("AzureStorageConnectionString-1"));
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("minecontainer");
            return container;
        }
        [HandleError]
        public ActionResult CreateBlobContainer()
        {
            // The code in this section goes here.

            return View();
        }
        CloudBlobContainer container = GetCloudBlobContainer();
    }
}