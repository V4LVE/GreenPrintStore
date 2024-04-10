using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using GreenPrint.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GreenPrint.Web.Pages.Admin
{
    public class AdminDashboardModel : PageModel
    {
        #region backing fields
        private readonly ICategoryService _categoryService;
        private readonly IWarehouseService _warehouseService;
        private readonly IAddressService _addressService;
        #endregion

        #region Constructor
        public AdminDashboardModel(ICategoryService categoryService, IWarehouseService warehouseService, IAddressService addressService)
        {
            _categoryService = categoryService;
            _warehouseService = warehouseService;
            _addressService = addressService;
        }
        #endregion

        #region Properties
        public List<CategoryDTO> Categories { get; set; }
        public List<WarehouseDTO> Warehouses { get; set; }
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
    }
}
