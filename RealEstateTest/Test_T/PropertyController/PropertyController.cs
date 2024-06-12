using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Core;
using RealEstate.Data;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Xml;
using System.Security.Claims;
using Microsoft.Extensions.Configuration.UserSecrets;
using static System.Net.Mime.MediaTypeNames;
using RealEstateData;




namespace RealEstateWibsite.PropertyController
{
    public class PropertyController : Controller
    {
        private readonly IDataHelper<RealEstateProperty> data;
        private readonly IDataHelper<offertype> offerType;
        private readonly IDataHelper<propertytype> propertytype;
        private readonly IDataHelper<propertystatus> propertystatus;
        private readonly IWebHostEnvironment webHost;
        private readonly IAuthorizationService authorizationService;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
         DBData dB;
        private readonly IDataHelper<furnishedstatus> furnishedstatus;
        private readonly IDataHelper<Bedrooms> bedrooms;
        private readonly IDataHelper<Bathrooms> bathrooms;
        private readonly IDataHelper<Balconys> balconys;
        private readonly IDataHelper<SavedProp> savedprop;
        private int pageItem;
        private Task<AuthorizationResult> result;
        private string UserId;
        private SavedProp SavedProp;
        private RealEstateProperty real;


        public PropertyController(IDataHelper<RealEstateProperty> data, IDataHelper<offertype> OfferType
            , IDataHelper<propertytype> Propertytype, IDataHelper<propertystatus> Propertystatus,
            IDataHelper<furnishedstatus> Furnishedstatus, IDataHelper<Bedrooms> bedrooms,
            IDataHelper<Bathrooms> bathrooms, IDataHelper<Balconys> balconys,
            IDataHelper<SavedProp> savedprop,
            IWebHostEnvironment webHost, IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,DBData dB)
        {
            this.data = data;
            offerType = OfferType;
            propertytype = Propertytype;
            propertystatus = Propertystatus;
            this.webHost = webHost;
            this.authorizationService = authorizationService;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.dB = dB;
            furnishedstatus = Furnishedstatus;
            this.bedrooms = bedrooms;
            this.bathrooms = bathrooms;
            this.balconys = balconys;
            this.savedprop = savedprop;
            pageItem = 4 * 3;
        }

        
        public IActionResult GerneralIndex(int?id)
        {

            if (id == 0 || id == null)
            {
                dB = new DBData();

                var saleProperties = data.GetData().ToList();
                return View(saleProperties.Take(pageItem));
            }
            else
            {
                dB = new DBData();
                var saleProperties = data.GetData().ToList();
                return View(saleProperties.Where(x => x.Id > id).Take(pageItem));
            }
        }

        public async Task<IActionResult> MyPosts(int? id)
        {

            await SetUser();
          
            if (signInManager.IsSignedIn(User))
            {
                if (id == 0 || id == null)
                {
                    return View(data.GetDataByUserId(UserId).Take(pageItem));
                }
                else
                {
                    var getdata = data.GetDataByUserId(UserId).Where(x => x.Id > id);
                    return View(getdata.Take(   pageItem));
                }
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }

        }




        public ActionResult BuyingIndex(int? id)
        {
            if (id == 0 || id == null)
            {
                dB = new DBData();

                var saleProperties = data.GetData().Where(property => property.OffertypeLiist == "sale").ToList();
                return View(saleProperties.Take(pageItem));
            }
            else
            {
                dB = new DBData();

                var saleProperties = data.GetData().Where(property => property.OffertypeLiist == "sale").ToList();
                return View(saleProperties.Where(x => x.Id > id).Take(pageItem));
            }

        }
        public async Task<ActionResult> SavedProperty(int? id)
        {
            await SetUser();
            if (id == 0 || id == null)
            {
                dB = new DBData();

                var savedProperties = savedprop.GetData().Where(x=>x.IsSaved&&x.UserId==UserId);
                return View(savedProperties.Take(pageItem));
            }
            else
            {
                dB = new DBData();

                var savedProperties = savedprop.GetData().Where(x => x.IsSaved && x.UserId == UserId);
                return View(savedProperties.Where(x => x.Id > id).Take(pageItem));
            }

        }


        public ActionResult RentingIndex(int? id)
        {

            if (id == 0 || id == null)
            {
                dB = new DBData();

                var rentProperties = data.GetData().Where(property => property.OffertypeLiist == "rent").ToList();
                return View(rentProperties.Take(pageItem));
            }
            else
            {
                dB = new DBData();

                var rentProperties = data.GetData().Where(property => property.OffertypeLiist == "rent").ToList();
                return View(rentProperties.Where(x => x.Id > id).Take(pageItem));
            }

        }



        [AllowAnonymous]
        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {

            return View(data.Find(id));

        }

        [Authorize]
        [HttpPost("ToggleStatus")]
        public async Task <IActionResult> ToggleStatus(int id, string userId, bool isSave)
        {
            try
            {
                await SetUser();
                UserId = userId;
                // Assuming savedprop is an instance of SavedPropEntity
                // Use the TogglePostStatus method from SavedPropEntity
                savedprop.TogglePostStatus(userId, id, isSave);

                string message = isSave ? "Property saved successfully" : "Property unsaved successfully";
                return Ok(new { message = message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error toggling property status: " + ex.Message });
            }
        }

        [Authorize]
        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RealEstatePropertyViewModel use, string OffertypeLiist)
        {
            try
            {
                int counter = 0;

                // Get the currently logged-in user
                var user = await userManager.GetUserAsync(User);

                // Use the user's Id and UserName
                var realEstate = new RealEstateProperty
                {
                    Id = use.Id,
                    UserId = user.Id,
                    UserName = user.UserName,
                    propertyname = use.propertyname,
                    propertyprice = use.propertyprice,
                    depositamount = use.depositamount,
                    propertyaddress = use.propertyaddress,
                    OffertypeLiist = use.OffertypeLiist,
                    PropertytypeList = use.PropertytypeList,
                    PropertystatusList = use.PropertystatusList,
                    FurnishedstatusList = use.FurnishedstatusList,
                    bedroomsList = use.bedroomsList,
                    bathroomsList = use.bathroomsList,
                    balconysList = use.balconysList,

                    OffertypeId = offerType.GetData().Where(x => x.Offertype == use.OffertypeLiist).Select(x => x.id).FirstOrDefault(),
                    Offertype = use.Offertype,

                    PropertytypeId = propertytype.GetData().Where(x => x.Propertytype == use.PropertytypeList).Select(x => x.id).FirstOrDefault(),
                    Propertytype = use.Propertytype,

                    PropertystatusId = propertystatus.GetData().Where(x => x.Propertystatus == use.PropertystatusList).Select(x => x.id).FirstOrDefault(),
                    Propertystatus = use.Propertystatus,

                    FurnishedstatusId = furnishedstatus.GetData().Where(x => x.Furnishedstatus == use.FurnishedstatusList).Select(x => x.id).FirstOrDefault(),
                    Furnishedstatus = use.Furnishedstatus,

                    bedroomsId = bedrooms.GetData().Where(x => x.bedrooms == use.bedroomsList).Select(x => x.id).FirstOrDefault(),
                    bedrooms = use.bedrooms,

                    bathroomsId = bathrooms.GetData().Where(x => x.bathrooms == use.bathroomsList).Select(x => x.id).FirstOrDefault(),
                    bathrooms = use.bathrooms,

                    balconysId = balconys.GetData().Where(x => x.balconys == use.balconysList).Select(x => x.id).FirstOrDefault(),
                    balconys = use.balconys,

                    carpetarea = use.carpetarea ?? "",
                    propertyage = use.propertyage ?? "",
                    totalfloors = use.totalfloors ?? "",
                    floorroom = use.floorroom ?? "",
                    propertydescription = use.propertydescription ?? "",

                    ImageUrl1 = UploadFile(use.File1, "uploads"),
                    ImageUrl2 = UploadFile(use.File2, "uploads"),
                    ImageUrl3 = UploadFile(use.File3, "uploads"),
                    ImageUrl4 = UploadFile(use.File4, "uploads"),
                    ImageUrl5 = UploadFile(use.File5, "uploads"),

                    AddedDate = DateTime.Now,
                    IsSaved=use.IsSaved
                    
                  
                };

                // Increment the counter for each uploaded image
                if (!string.IsNullOrEmpty(realEstate.ImageUrl1))
                    counter++;
                if (!string.IsNullOrEmpty(realEstate.ImageUrl2))
                    counter++;
                if (!string.IsNullOrEmpty(realEstate.ImageUrl3))
                    counter++;
                if (!string.IsNullOrEmpty(realEstate.ImageUrl4))
                    counter++;
                if (!string.IsNullOrEmpty(realEstate.ImageUrl5))
                    counter++;

                // Set the total number of uploaded images
                realEstate.ImagesCounts = counter;

                // Add the real estate property to the data repository
                data.Add(realEstate);

                // Redirect based on offer type
                if (!string.IsNullOrEmpty(OffertypeLiist))
                {
                    if (OffertypeLiist == "sale")
                    {
                        return RedirectToAction("BuyingIndex", "Property");
                    }
                    else if (OffertypeLiist == "rent")
                    {
                        return RedirectToAction("RentingIndex", "Property");
                    }
                }

                // Default redirect
                return RedirectToAction("BuyingIndex", "Property");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return View(); // Consider returning an error view or message
            }
        }

        // GET: HomeController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var test = data.Find(id);
            RealEstatePropertyViewModel realEstate = new RealEstatePropertyViewModel
            {
                   // Get the currently logged-in user
              
                 Id =test.Id,
                propertyname = test.propertyname,
                propertyprice = test.propertyprice,
                depositamount = test.depositamount,
                propertyaddress = test.propertyaddress,
                OffertypeLiist = test.OffertypeLiist,
                PropertytypeList = test.PropertytypeList,
                PropertystatusList = test.PropertystatusList,
                FurnishedstatusList = test.FurnishedstatusList,
                bedroomsList = test.bedroomsList,
                bathroomsList = test.bathroomsList,
                balconysList = test.balconysList,

                OffertypeId = offerType.GetData().Where(x => x.Offertype == test.OffertypeLiist).Select(x => x.id).FirstOrDefault(),
                Offertype = test.Offertype,

                PropertytypeId = propertytype.GetData().Where(x => x.Propertytype == test.PropertytypeList).Select(x => x.id).FirstOrDefault(),
                Propertytype = test.Propertytype,

                PropertystatusId = propertystatus.GetData().Where(x => x.Propertystatus == test.PropertystatusList).Select(x => x.id).FirstOrDefault(),
                Propertystatus = test.Propertystatus,

                FurnishedstatusId = furnishedstatus.GetData().Where(x => x.Furnishedstatus == test.FurnishedstatusList).Select(x => x.id).FirstOrDefault(),
                Furnishedstatus = test.Furnishedstatus,

                bedroomsId = bedrooms.GetData().Where(x => x.bedrooms == test.bedroomsList).Select(x => x.id).FirstOrDefault(),
                bedrooms = test.bedrooms,

                bathroomsId = bathrooms.GetData().Where(x => x.bathrooms == test.bathroomsList).Select(x => x.id).FirstOrDefault(),
                bathrooms = test.bathrooms,

                balconysId = balconys.GetData().Where(x => x.balconys == test.balconysList).Select(x => x.id).FirstOrDefault(),
                balconys = test.balconys,

                carpetarea = test.carpetarea,
                propertyage = test.propertyage,
                totalfloors = test.totalfloors,
                floorroom = test.floorroom,
                propertydescription = test.propertydescription,



            };
            return View(realEstate);
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, RealEstatePropertyViewModel use, string OffertypeList)
        {
            try
            {
                var user = await userManager.GetUserAsync(User);

                // Retrieve existing property from the database
                var existingProperty = data.Find(id);

                // Map the changes from the view model
                existingProperty.propertyname = use.propertyname;
                existingProperty.propertyprice = use.propertyprice;
                existingProperty.depositamount = use.depositamount;
                existingProperty.propertyaddress = use.propertyaddress;
                existingProperty.OffertypeLiist = use.OffertypeLiist; // Corrected property name
                existingProperty.PropertytypeList = use.PropertytypeList;
                existingProperty.PropertystatusList = use.PropertystatusList;
                existingProperty.FurnishedstatusList = use.FurnishedstatusList;
                existingProperty.bedroomsList = use.bedroomsList;
                existingProperty.bathroomsList = use.bathroomsList;
                existingProperty.balconysList = use.balconysList;

                existingProperty.OffertypeId = offerType.GetData().FirstOrDefault(x => x.Offertype == use.OffertypeLiist)?.id ?? 0;
                existingProperty.PropertytypeId = propertytype.GetData().FirstOrDefault(x => x.Propertytype == use.PropertytypeList)?.id ?? 0;
                existingProperty.PropertystatusId = propertystatus.GetData().FirstOrDefault(x => x.Propertystatus == use.PropertystatusList)?.id ?? 0;
                existingProperty.FurnishedstatusId = furnishedstatus.GetData().FirstOrDefault(x => x.Furnishedstatus == use.FurnishedstatusList)?.id ?? 0;
                existingProperty.bedroomsId = bedrooms.GetData().FirstOrDefault(x => x.bedrooms == use.bedroomsList)?.id ?? 0;
                existingProperty.bathroomsId = bathrooms.GetData().FirstOrDefault(x => x.bathrooms == use.bathroomsList)?.id ?? 0;
                existingProperty.balconysId = balconys.GetData().FirstOrDefault(x => x.balconys == use.balconysList)?.id ?? 0;
                existingProperty.Offertype = use.Offertype;
                existingProperty.Propertytype = use.Propertytype;
                existingProperty.Propertystatus = use.Propertystatus;
                existingProperty.Furnishedstatus = use.Furnishedstatus;
                existingProperty.bedrooms = use.bedrooms;
                existingProperty.bathrooms = use.bathrooms;
                existingProperty.balconys = use.balconys;



                existingProperty.IsSaved = use.IsSaved;
                existingProperty.carpetarea = use.carpetarea ?? "";
                existingProperty.propertyage = use.propertyage ?? "";
                existingProperty.totalfloors = use.totalfloors ?? "";
                existingProperty.floorroom = use.floorroom ?? "";
                existingProperty.propertydescription = use.propertydescription ?? "";
                existingProperty.AddedDate = use.AddedDate;
                // Check and handle file uploads
                if (use.File1 != null)
                {
                    existingProperty.ImageUrl1 = UploadFile(use.File1, "uploads");
                }
                if (use.File2 != null)
                {
                    existingProperty.ImageUrl2 = UploadFile(use.File2, "uploads");
                }
                if (use.File3 != null)
                {
                    existingProperty.ImageUrl3 = UploadFile(use.File3, "uploads");
                }
                if (use.File4 != null)
                {
                    existingProperty.ImageUrl4 = UploadFile(use.File4, "uploads");
                }
                if (use.File5 != null)
                {
                    existingProperty.ImageUrl5 = UploadFile(use.File5, "uploads");
                }

                // Count the total number of uploaded images
                int counter = 0;
                if (!string.IsNullOrEmpty(existingProperty.ImageUrl1))
                    counter++;
                if (!string.IsNullOrEmpty(existingProperty.ImageUrl2))
                    counter++;
                if (!string.IsNullOrEmpty(existingProperty.ImageUrl3))
                    counter++;
                if (!string.IsNullOrEmpty(existingProperty.ImageUrl4))
                    counter++;
                if (!string.IsNullOrEmpty(existingProperty.ImageUrl5))
                    counter++;

                existingProperty.ImagesCounts = counter;

                // Update the property in the database
                data.Update(existingProperty, id);

                if (!string.IsNullOrEmpty(OffertypeList))
                {
                    if (OffertypeList == "sale" || OffertypeList == "resale") // Combined conditions for sale and resale
                    {
                        return RedirectToAction("BuyingIndex", "Property");
                    }
                    else if (OffertypeList == "rent")
                    {
                        return RedirectToAction("RentingIndex", "Property");
                    }
                }

                return RedirectToAction("BuyingIndex", "Property");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error updating user: " + ex.Message });
            }
        }

        public ActionResult Delete(int id)
        {
            return View(data.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Delete(int id, RealEstateProperty collection,string OffertypeLiist)
        {
            try
            {
                data.Delete(id);
                
                if (!string.IsNullOrEmpty(OffertypeLiist))
                {
                    if (OffertypeLiist == "sale")
                    {
                        return  RedirectToAction("BuyingIndex", "Property");
                    }
                    else if (OffertypeLiist == "rent")
                    {
                        return RedirectToAction("RentingIndex", "Property");
                    }

                }
                return RedirectToAction("GerneralIndex", "Property");
            }
            catch (Exception ex)
            {
                // Log the exception
                // Handle the error gracefully (e.g., show error message to the user)
                ModelState.AddModelError(string.Empty, $"Error deleting property: {ex.Message}");
                return View("Delete", id); // Redirect to delete confirmation view with ID
            }
        }
        public ActionResult DeleteMyPosts(int id)
        {
            return View(data.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMyPosts(int id, RealEstateProperty collection )
        {
            try
            {
                data.Delete(id);
 
                return RedirectToAction("MyPosts", "Property");
            }
            catch
            {
                return View();
            }
        }
        public string UploadFile(IFormFile file, string folder)
        {
            if (file != null)
            {
                var fileDir = Path.Combine(webHost.WebRootPath, folder);
                var fileName = Guid.NewGuid() + "-" + file.FileName;
                var filePath = Path.Combine(fileDir, fileName);

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                    return fileName;
                }

            }
            else
            {
                return string.Empty;
            }
        }

        private async Task SetUser()
        {
            var user = await userManager.GetUserAsync(User);
            if (user != null)
            {
                UserId = user.Id;
            }
        }


    }
}
