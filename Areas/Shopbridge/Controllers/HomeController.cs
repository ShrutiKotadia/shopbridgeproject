using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBridgeDAL.Inventory.Models;
using ShopBridgeLibrary.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ThinkBridgeSoft.Areas.Shopbridge
{
    public class HomeController : Controller
    {
        ShopBridgeDbContext moDBContext;
        IWebHostEnvironment moIWebHostEnvironment;
        public HomeController(ShopBridgeDbContext foDBContext, IWebHostEnvironment foIWebHostEnvironment)
        {
            moDBContext = foDBContext;
            moIWebHostEnvironment = foIWebHostEnvironment;
        }

        // GET: HomeController
        // Get List of the Inventory Items
        public ActionResult Index(int id)
        {
            InventoryDBLayer loDb = new InventoryDBLayer(moDBContext);
            List<Inventory> loResult = new List<Inventory>();
            loResult = loDb.getInventory(id);
            getInventoryList lolist = new getInventoryList();
            lolist.loInventry = loResult;
            return View("~/Areas/Shopbridge/Views/Index.cshtml", lolist);
        }

        // Uploads the file to the local folder
        public static async Task<string> UploadedFileAsync(IFormFile foImage, IWebHostEnvironment foIWebHostEnvironment)
        {
            string lsdocUniqueName = null;
            string lsFilePath = null;
            if (foImage != null)
            {
                string lsGuid = Guid.NewGuid().ToString("N");
                var stExtension = System.IO.Path.GetExtension(foImage.FileName);
                lsdocUniqueName = lsGuid.ToLower() + System.IO.Path.GetExtension(foImage.FileName);
                string fsuploadfolder = Path.Combine(foIWebHostEnvironment.WebRootPath, GetFolderPath.loRootPath);
                lsFilePath = Path.Combine(fsuploadfolder, lsdocUniqueName);
                if (!Directory.Exists(fsuploadfolder))
                {
                    Directory.CreateDirectory(fsuploadfolder);
                }
                using (FileStream fs = new FileStream(lsFilePath, FileMode.Create))
                {
                    await foImage.CopyToAsync(fs);
                    fs.Dispose();
                }
            }

            return lsdocUniqueName;
        }

        [HttpPost]
        // Adds the inventory in DB
        public async Task<ActionResult> Save(Inventory foRequest)
        {
            InventoryDBLayer loDb = new InventoryDBLayer(moDBContext);
            int liSuccess = 0;
            string lsuniqueFileName = await UploadedFileAsync(foRequest.ProdImage, moIWebHostEnvironment);
            loDb.saveInventory(foRequest.inId, foRequest.Name, foRequest.Description, foRequest.Price, lsuniqueFileName, out liSuccess);
            TempData["successMessage"] = "Record Saved";
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]

        // Deletes the Inventory from DB
        public ActionResult Delete(int id)
        {
            InventoryDBLayer loDb = new InventoryDBLayer(moDBContext);
            int liSuccess = 0;
            loDb.deleteInventory(id, out liSuccess);
            if (liSuccess == 1)
            {
                return Json(new { success = true, message = "Inventory deleted", id = id });
            }
            {
                return Json(new { success = false, message = "Error encountered", id = id });
            }
        }
    }
}
