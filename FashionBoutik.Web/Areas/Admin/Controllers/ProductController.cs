using System;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
//using Microsoft.ApplicationServer.Caching;
using FashionBoutik.DomainServices;
using FashionBoutik.Models;
using FashionBoutik.Controllers;

namespace FashionBoutik.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : BaseController
    {
        private readonly IProductManager _productManager;
        //private readonly CachedProductManager _cachManager;

        private readonly IMemoryCache _cache;
        private readonly IHttpContextAccessor _context; //TODO: can be used instead of MemoryCache

        public ProductController(IProductManager productManager, IMemoryCache cache, 
            IHttpContextAccessor context) : base(productManager)
        {
            _productManager = productManager;  //_cachManager = cachManager;
            _cache = cache;

            _context = context;// to get _context.Session or _context.Items
        }

        /*[HttpPost]
        public ActionResult Search(FormCollection collection)
        {
            // Get the form data
            string viewString = collection["view"];
            string returnUrl = collection["returnUrl"];
            string keywordString = collection["txtSearch"];
            string sort_field = collection["selectSortField"];
            string sort_order = collection["selectSortOrder"];
            string page_size = collection["selectPageSize"];
            string redirectUrl = "~/admin_products?kw=" + Server.UrlEncode(keywordString) + "&sf=" + sort_field + "&so=" + sort_order + "&pz=" + page_size;

            // Check if we should search among accessories
            if (viewString == "accessories")
            {
                string mainProductId = collection["hiddenMainProductId"];
                redirectUrl = "~/admin_products/accessories/" + mainProductId + "?returnUrl=" + Server.UrlEncode(returnUrl) + "&kw=" + Server.UrlEncode(keywordString);
            }
            else if (viewString == "bundles")
            {
                string mainProductId = collection["hiddenMainProductId"];
                redirectUrl = "~/admin_products/bundle_structure/" + mainProductId + "?returnUrl=" + Server.UrlEncode(returnUrl) + "&kw=" + Server.UrlEncode(keywordString);
            }

            // Return the url with search parameters
            return Redirect(redirectUrl);
        }*/

        // Get the list of products
        #region UI View actions


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var viewModel = await _productManager.GetAllProducts(); //?.MapTo<BrandViewModel>()
            //ViewBag.AllPartners = (await _productGroupingProvider.GetAllPartners()).ToList();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            //Prepare a new brand
            var model = new ProductModel();

            //TODO: from _cahedController

            //model.AllColors = AllColors;
            //model.AllSizes = AllSizes;
            //model.AllBrands = AllBrands;
            //model.AllCategories = AllCategories;

            return PartialView(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                model.PricePerUnit.PriceDate = DateTime.Now;
                //model.PricePerUnit.Name = string.Format("Price{0}_On_{1}", model.Name, DateTime.Now );
                if (_cache.Get<List<BinaryObjectModel>>("TempProductAttachments") != null)
                {
                    model.Attachments = _cache.Get<List<BinaryObjectModel>>("TempProductAttachments");
                }

                var isSaved = await _productManager.SaveProduct(model);
                if (isSaved)
                {
                    _cache.Set<List<BinaryObjectModel>>("TempProductAttachments", null);

                    return RedirectToAction("List");
                }
            }
            return View(model); //TODO: view with validation errors
        }

        [HttpGet]
        //[Route("{id}/edit")]//[Route("~/api/category/{id}/edit")] - to rewrite path
        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = await _productManager.GetProductById(id);
            return PartialView(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                if (_cache.Get<List<BinaryObjectModel>>("TempProductAttachments") != null)
                {
                    model.Attachments = _cache.Get<List<BinaryObjectModel>>("TempProductAttachments");
                }

                var isSaved = await _productManager.SaveProduct(model);
                if (isSaved)
                {
                    //Cleaning up attached files
                    _cache.Set<List<BinaryObjectModel>>("TempProductAttachments", null);

                    return RedirectToAction("List");
                }
            }
            return PartialView(model); //TODO: view with validation errors
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                var model = await _productManager.GetProductById(id);
                return PartialView("ConfirmDelete", model);
            }

            AddError("Cannot delete empty product");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(ProductModel model)
        {
            if (model != null)
            {
                var result = await _productManager.DeleteProduct(model.Id);
                if (result)
                {
                    return RedirectToAction("List");
                }
            }
            AddError("Cannot delete empty product.");
            return View();
        }

        #endregion


        #region Helper methods

        #region Attachments methods: add\remove\view\download images


        /// <summary>
        /// Attach image to the product (in binary format). 
        /// TODO: Azure Blob or Cloud Storage
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UploadAttachedFiles(int productId)
        {
            var tempProductAttachments = _cache.Get<List<BinaryObjectModel>>("TempProductAttachments") ?? new List<BinaryObjectModel>();
            //HttpContext.Session.GetObject<List<BinaryObjectModel>>("TempProductAttachments");
            var product = productId > 0 ? await _productManager.GetProductById(productId) : null;

            tempProductAttachments = tempProductAttachments ?? (product == null
                       ? product?.Attachments.ToList()
                       : new List<BinaryObjectModel>());

            if (Request.Form.Files.Count > 0)
            {
                foreach (var file in Request.Form.Files)
                {
                    using (var ms = new MemoryStream())
                    {
                        using (var stream = file.OpenReadStream())
                        {
                            await stream.CopyToAsync(ms);
                        }

                        string fullFileName = file.FileName;
                        string name = fullFileName.Split('.')[0];
                        string ext = fullFileName.Split('.')[1];

                        //Check if file with such name already exists
                        var existingFileWithName = tempProductAttachments?.OrderBy(a => a.Name).LastOrDefault(f => f.Name.StartsWith(name));
                        if (existingFileWithName != null)
                        {
                            //var errorMsg = "The file with the same name exists";
                            //return Json(new AjaxResponse() {Error = new ErrorInfo(errorMsg), Success = false});

                            var existingNamesCount = tempProductAttachments.Count(f => f.Name.StartsWith(name));
                            if (existingFileWithName.Name.Contains("(" + existingNamesCount + ")"))
                                existingNamesCount = existingNamesCount + 1;

                            //Generate new name
                            fullFileName = name + "(" + existingNamesCount + ")." + ext;

                            //bool existName = product.Attachments.Any(f => f.Name.Equals(fullFileName));
                        }

                        var binary = new BinaryObjectModel();// Session.CurrentTenantId, ms.ToArray());
                        binary.Name = fullFileName;
                        binary.ContentType = file.ContentType; //MimeTypeNames.ApplicationPdf;
                        binary.Bytes = ms.ToArray();
                        //binary.Product = product;
                        //binary.ProductId = productId; //update info about related project
                        //var fileBytesModel = binary.MapTo<BinaryObjectModel>();
                        tempProductAttachments.Add(binary);

                        //AND finally - save to cash
                        _cache.Set("TempProductAttachments", tempProductAttachments);
                        //HttpContext.Session.SetObject<List<BinaryObjectModel>>("TempProductAttachments", TempProductAttachments);
                        //TempData["TempProductAttachments"] = TempProductAttachments;
                        //_distributedCache.SetObject("TempProductAttachments", TempProductAttachments);

                        //Log 
                        //var record = new UserActivityLog()
                        //{
                        //    EntityId = productId.ToString(),
                        //    EntityName = typeof(Product).Name,
                        //    ActivityType = UserActivityLogDefaultTypes.Products.FileAttachmentAdded,
                        //    CustomData = "Attachments",
                        //    Message = $"Attached a new file '{fullFileName}'"
                        //};
                        //_userActivityLogManager.Create(record);
                    }
                }
            }

            //return await AttachmentsList(ProductId);
            return Json(true);
        }

        /// <summary>
        /// Remove assocciated attached file from Product
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteAttachedFile(int productId, long fileId)
        {
            var product = await _productManager.GetProductById(productId);
            var attachement = product.Attachments.FirstOrDefault(att => att.Id.Equals(fileId));

            if (attachement != null)
            {
                bool isAttachmentRemoved = product.Attachments.Remove(attachement);
                await _productManager.SaveProduct(product);

                if (isAttachmentRemoved)
                {
                    //var record = new UserActivityLog()
                    //{
                    //    EntityId = productId.ToString(),
                    //    EntityName = typeof(Product).Name,
                    //    ActivityType = UserActivityLogDefaultTypes.Products.Product_FileAttachmentRemoved,
                    //    CustomData = "Attachments",
                    //    Message = $"File '{attachement.Name}' has been removed"
                    //};
                    //_userActivityLogManager.Create(record);
                }
            }
            return Json(true);//Json(new AjaxResponse(true));
        }

        /// <summary>
        /// Returns image from bytes array (saved in DB) 
        /// to be dispalyed in <img src="<img src="@Url.Action("RenderImage", new { productId = Model.ProductId, fileId = @fileId})" />"
        /// TODO: can be used HtmlHelper.GetImageSource(imageBytes)
        /// https://stackoverflow.com/questions/17952514/mvc-how-to-display-a-byte-array-image-from-model
        /// OR
        /// <img src="@String.Format("data:image/jpg;base64,{0}", Model.ImageBytes)" />
        /// </summary>
        /// <param name="productId">product with image\s</param>
        /// <returns></returns>
        //[HttpGet]
        //public async Task<ActionResult> RenderImage(int productId, long fileId)
        //{
        //    var product = await _productManager.GetProductById(productId);
        //    var attachement = product.Attachments.FirstOrDefault(att => att.Id.Equals(fileId));

        //    if (attachement == null)
        //        return null;

        //    string fileType = System.Net.Mime.MediaTypeNames.Image.Gif;// or "image/png"

        //    return File(attachement.Bytes, fileType);
        //}

        /// <summary>
        /// Return attached file from binary stream into PDF format 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="fileId">Guid of the file</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ViewAttachedFile(int productId, long fileId)
        {
            var product = await _productManager.GetProductById(productId);
            var attachement = product.Attachments.FirstOrDefault(att => att.Id.Equals(fileId));

            if (attachement == null)
                return null;

            //"Content-Disposition" - to view file in BROWSER
            Response.Headers.Add("Content-Disposition", "inline; filename=" + attachement.Name);
            return File(attachement.Bytes, attachement.ContentType);
        }

        [HttpGet]
        public async Task<IActionResult> DownloadAttachedFile(int productId, long fileId)
        {
            var product = await _productManager.GetProductById(productId);
            var attachement = product.Attachments.FirstOrDefault(att => att.Id.Equals(fileId));

            if (attachement == null)
                return null;

            //var filePath = Path.Combine(EnvironmentConfig.TempFileFolder, attachement.Name);
            //System.IO.File.WriteAllBytes(filePath, attachement.Bytes);
            //var result = File(filePath, MimeTypeNames.ApplicationPdf, attachement.Name);
            //MimeTypeNames.ApplicationOctetStream
            var fileType = System.Net.Mime.MediaTypeNames.Image.Gif;// Application.Octet;
            var result = new FileContentResult(attachement.Bytes, fileType) { FileDownloadName = attachement.Name };

            //Log 
            //var record = new UserActivityLog()
            //{
            //    EntityId = ProductId.ToString(),
            //    EntityName = typeof(Product).Name,
            //    ActivityType = UserActivityLogDefaultTypes.Products.FileAttachmentDownload,
            //    CustomData = "Attachments",
            //    Message = $"File '{attachement.Name}' had been downloaded",
            //};
            //_userActivityLogManager.Create(record);
            return result;
        }

        /// <summary>
        /// Returns updated list of all attached images to the Product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<IActionResult> AttachmentsList(int productId)
        {
            var model = await _productManager.GetProductById(productId);
            //var attachedFiles = product.Attachments.MapTo<BinaryObjectDto>();

            return PartialView("_ProductImageAttachmentsList", model);
        }

        #endregion

        #endregion
    }
}