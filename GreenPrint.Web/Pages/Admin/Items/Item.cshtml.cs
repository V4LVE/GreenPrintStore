using GreenPrint.Repository.Entities;
using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using GreenPrint.Web.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GreenPrint.Web.Pages.Admin.Items
{
    public class ItemModel : PageModel
    {
        #region services
        private readonly IItemService _itemService;
        private readonly ICategoryService _categoryService;
        private readonly IWarehouseItemService _warehouseItemService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IItemImageService _imageService;
        private readonly IWarehouseService _warehouseService;
        #endregion

        #region Constructor
        public ItemModel(IItemService itemService, ICategoryService categoryService, IWarehouseItemService warehouseItemService, IWebHostEnvironment webHostEnvironment, IItemImageService imageService, IWarehouseService warehouseService)
        {
            _itemService = itemService;
            _categoryService = categoryService;
            _warehouseItemService = warehouseItemService;
            _webHostEnvironment = webHostEnvironment;
            _imageService = imageService;
            _warehouseService = warehouseService;
        }
        #endregion

        #region Properties
        [BindProperty]
        public ItemDTO Item { get; set; }
        [BindProperty]
        public List<CategoryDTO> Categories { get; set; }
        [BindProperty]
        public List<WarehouseItemDTO> WarehouseItems { get; set; }
        [BindProperty]
        public WarehouseItemDTO NewWarehouseItem { get; set; }
        [BindProperty]
        public List<WarehouseDTO> Warehouses { get; set; }

        [BindProperty]
        public IFormFile[]? NewProductImages { get; set; }
        #endregion

        public async Task<IActionResult> OnGet(int itemId)
        {
            if (!await HttpContext.AuthenticatedUserIsAdmin())
            {
                return RedirectToPage("/UnAuthorized");
            }

            Item = await _itemService.GetByIdAsync(itemId);
            if (Item == null)
            {
                return NotFound();
            }

            Categories = await _categoryService.GetAllAsync();
            Warehouses = await _warehouseService.GetAllAsync();
            WarehouseItems = await _warehouseItemService.GetAllByByItemId(itemId);

            return Page();
        }

        public async Task<IActionResult> OnPostUpdate(int itemId)
        {
            if (!ModelState.IsValid)
            {
                await OnGet(itemId);
                return Page();
            }

            Item.Id = itemId;

            if (NewProductImages != null)
            {
                List<ItemImageDTO> productImages = new();

                foreach (IFormFile imagFile in NewProductImages)
                {
                    string websiteImagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images/Items");
                    string imageName = $"{Item.Id}{Guid.NewGuid()}.png";
                    string imagePath = Path.Combine(websiteImagePath, imageName);
                    using (FileStream fileStream = new(imagePath, FileMode.Create))
                    {
                        await imagFile.CopyToAsync(fileStream);
                    }

                    productImages.Add(new() { ItemId = Item.Id, ImageUrl = imageName, DateCreated = DateTime.Now });
                }

                await _imageService.CreateListAsync(productImages);
            }

            await _itemService.UpdateAsync(Item);
            await _warehouseItemService.UpdateListAsync(WarehouseItems);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAddWarehouseAsync()
        {
            NewWarehouseItem.ItemId = Item.Id;
            await _warehouseItemService.RegisterProductAsync(NewWarehouseItem);

            return RedirectToPage("/Admin/Items/Item", new { itemId = Item.Id });

        }
    }
}
