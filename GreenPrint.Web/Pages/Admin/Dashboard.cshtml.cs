using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using GreenPrint.Service.Services;
using GreenPrint.Web.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace GreenPrint.Web.Pages.Admin
{
    public class AdminDashboardModel : PageModel
    {
        #region backing fields
        private readonly ICategoryService _categoryService;
        private readonly IWarehouseService _warehouseService;
        private readonly IAddressService _addressService;
        private readonly IItemService _itemService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IItemImageService _itemImageService;
        private readonly IWarehouseItemService _warehouseItemService;
        #endregion

        #region Constructor
        public AdminDashboardModel(ICategoryService categoryService, IWarehouseService warehouseService, IAddressService addressService, IItemService itemService, IWebHostEnvironment webHostEnvironment, IItemImageService itemImageService, IWarehouseItemService warehouseItemService)
        {
            _categoryService = categoryService;
            _warehouseService = warehouseService;
            _addressService = addressService;
            _itemService = itemService;
            _webHostEnvironment = webHostEnvironment;
            _itemImageService = itemImageService;
            _warehouseItemService = warehouseItemService;
        }
        #endregion

        #region Properties
        [BindProperty]
        public List<CategoryDTO> Categories { get; set; }
        [BindProperty]
        public List<WarehouseDTO> Warehouses { get; set; }
        [BindProperty]
        public ItemDTO NewProduct { get; set; }
        [BindProperty, MinLength(1, ErrorMessage = "You must select atleast 1 picture")]
        public IFormFile[] ProductImages { get; set; }
        [BindProperty]
        public WarehouseItemDTO NewWarehouseItem { get; set; }
        #endregion

        public async Task<IActionResult> OnGet()
        {
            if (!await HttpContext.AuthenticatedUserIsAdmin())
            {
                return RedirectToPage("/UnAuthorized");
            }

            Categories = await _categoryService.GetAllAsync();
            Warehouses = await _warehouseService.GetAllAsync();

            return Page();
        }

        #region Categories
        // Adds a new category
        public async Task<IActionResult> OnPostAddCategory(string newCategoryName)
        {
            CategoryDTO newCategory = new() { CategoryName = newCategoryName };

            await _categoryService.CreateAsync(newCategory);

            return RedirectToPage();
        }

        // Deletes a category
        public async Task<IActionResult> OnPostDeleteCategory(int categoryID)
        {
            CategoryDTO deleteCat = await _categoryService.GetByIdAsync(categoryID);
            await _categoryService.DeleteAsync(deleteCat);

            return RedirectToPage();
        }
        #endregion

        #region Warehouses
        // Adds a new warehouse
        public async Task<IActionResult> OnPostAddWarehouse(string wname, string street, string streetnum, string zip, string city)
        {
            await OnGet();

            AddressDTO newAddress = new()
            {
                StreetName = street,
                StreetNumber = streetnum,
                ZipCode = zip,
                City = city
            };

            WarehouseDTO newWarehouse = new()
            {
                WarehouseName = wname,
                Address = newAddress
            };

            await _warehouseService.CreateAsync(newWarehouse);

            return RedirectToPage();
        }

        // Delets a warehouse
        public async Task<IActionResult> OnPostDeleteWarehouse(int warehouseID)
        {
            WarehouseDTO deleteWare = await _warehouseService.GetByIdAsync(warehouseID);
            await _warehouseService.DeleteAsync(deleteWare);

            return RedirectToPage();
        }
        #endregion

        public async Task<IActionResult> OnPostAddNewItemAsync()
        {
            if (!ModelState.IsValid)
            {
                Categories = await _categoryService.GetAllAsync();
                Warehouses = await _warehouseService.GetAllAsync();
                return Page();
            }

            NewProduct = await _itemService.CreateAndReturn(NewProduct);

            if (ProductImages != null)
            {
                List<ItemImageDTO> productImages = new();
                string _websitePath = $"{_webHostEnvironment.WebRootPath}\\Images\\Items\\";

                if (!Directory.Exists(_websitePath))
                {
                    Directory.CreateDirectory(_websitePath);
                }

                foreach (IFormFile imagFile in ProductImages)
                {
                    string websiteImagePath = _websitePath;
                    string imageName = $"{NewProduct.Id}{Guid.NewGuid()}.png";
                    string imagePath = Path.Combine(websiteImagePath, imageName);
                    using (FileStream fileStream = new(imagePath, FileMode.Create))
                    {
                        await imagFile.CopyToAsync(fileStream);
                    }

                    productImages.Add(new() { ItemId = NewProduct.Id, ImageUrl = imageName, DateCreated = DateTime.Now });
                }

                await _itemImageService.CreateListAsync(productImages);
            }

            NewWarehouseItem.ItemId = NewProduct.Id;
            await _warehouseItemService.CreateAsync(NewWarehouseItem);

            return RedirectToPage("/Items/Item", new { itemId = NewProduct.Id });
        }
    }
}
