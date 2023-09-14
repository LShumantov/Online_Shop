namespace OnlineShop.Controllers
{
    using OnlineShop.Data;
    using OnlineShop.Data.Services;
    using OnlineShop.Data.Static;
    using OnlineShop.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize(Roles = UserRoles.Admin)]
    public class StoresController : Controller
    {
        private readonly IStoresService _service;
        public StoresController(IStoresService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allStores = await _service.GetAllAsync();
            return View(allStores);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")]Store Store)
        {
            if (!ModelState.IsValid) return View(Store);
            await _service.AddAsync(Store);
            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var StoreDetails = await _service.GetByIdAsync(id);
            if (StoreDetails == null) return View("NotFound");
            return View(StoreDetails);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var StoreDetails = await _service.GetByIdAsync(id);
            if (StoreDetails == null) return View("NotFound");
            return View(StoreDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Store Store)
        {
            if (!ModelState.IsValid) return View(Store);
            await _service.UpdateAsync(id, Store);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var StoreDetails = await _service.GetByIdAsync(id);
            if (StoreDetails == null) return View("NotFound");
            return View(StoreDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var StoreDetails = await _service.GetByIdAsync(id);
            if (StoreDetails == null) return View("NotFound");
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
