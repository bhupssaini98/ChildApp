using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using API.Models;
using System.Web;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System;
using Newtonsoft.Json;
using API.Shared;


namespace WebApplication1.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api")]
    public class CommanController : ApiController
    {
        DAL objDal = new DAL();

        [Route("GetGender")]
        [HttpGet]
        public IEnumerable<SelectList> GetGender()
        {
            IEnumerable<SelectList> gender = objDal.GetGender();
            return gender;
        }

        [Route("AddEditChildData")]
        [HttpPost]
        public ResponseMessage AddEditChildData(Childdetails child)
        {
            ResponseMessage result = new ResponseMessage();
            result = objDal.AddEditChildData(child);
            return result;
        }
        [Route("DeleteChildData")]
        [HttpPost]
        public ResponseMessage DeleteChildData(ItemList item)
        {
            
            ResponseMessage delresult = new ResponseMessage();
            delresult = objDal.DeleteChildData(item);
            return delresult;
        }
        [Route("GetChilds")]
        [HttpPost]
        public IEnumerable<Childdetails> GetChilds(RequestParams request)
        {
            IEnumerable<Childdetails> childdetails = objDal.GetChilddetails(request);
            return childdetails;
        }
        [Route("GetOneChildData")]
        [HttpPost]
        public Childdetails GetOneChildData(ItemList request)
        {
            Childdetails childdetails = objDal.GetSingleChilddetails(request);
            return childdetails;
        }
        
        [Route("Search")]
        [HttpGet]
        public SearchFilter GetSearchFilter()
        {
            SearchFilter search = objDal.GetSearchFilter();
            return search;
        }

   
       [HttpPost]
       [Route("upload")]
       public IHttpActionResult upload()
        {
            
            MyResponse status = new MyResponse();
            try
                {
               
                 var filesReadToProvider = Request.Content.ReadAsMultipartAsync();
                var httpRequest = HttpContext.Current.Request;
                var model = httpRequest.Form["model"];

                ItemList item = JsonConvert.DeserializeObject<ItemList>(model);

                List<ChildDocument> document = new List<ChildDocument>();
                foreach (var streamContent in filesReadToProvider.Result.Contents)
                {
                    
                    var fileBytes = streamContent.ReadAsByteArrayAsync();
                    string base64String=  Convert.ToBase64String(fileBytes.Result);
                    //file.ChildId = filesReadToProvider.Id;
                    //file.FileSize = fileBytes.Result.Length;
                    //file.Document = base64String;
                    document.Add(new ChildDocument { ChildId = item.ChildID, FileSize = fileBytes.Result.Length, Document = base64String});

                }
               objDal.UpdateChild(document);
            
                status.Status = true;
                    status.Message = "File uploaded successfully";
                    return Ok(status);
           
            }
                catch (System.Exception ex)
                {
                    return Json("Upload Failed: " + ex.Message);
                }
            
        }
        //[Route("InsertUpdateChild")]
        //[HttpPost]
        //public List<ChildDocument> UpdateChild()
        //{
        //    var httpRequest = HttpContext.Current.Request;
        //    var model = httpRequest.Form["model"];
        //    Childdetails child = JsonConvert.DeserializeObject<Childdetails>(model);
        //    string filePath = string.Empty;
        //    List<ChildDocument> document = new List<ChildDocument>();
        //    if (httpRequest.Files.Count > 0)
        //    {

        //        foreach (string file in httpRequest.Files)
        //        {
        //            var postedFile = httpRequest.Files[file];
        //            string File_Name = Common.GetFileName(postedFile.FileName);
        //            filePath = HttpContext.Current.Server.MapPath("~/UploadFile/" + File_Name);
        //            postedFile.SaveAs(filePath);
        //            document.Add(new ChildDocument {DocumentPath = File_Name, DocumentFileName = postedFile.FileName });
                  

        //        }
        //    }
        //    document = objDal.UpdateChild(child, document);
        //    return document;
        //}


    }
}
