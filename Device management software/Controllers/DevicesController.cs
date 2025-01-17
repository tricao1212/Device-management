using Device_management_software.Models.Dtos.Requests.Device;
using Device_management_software.Models.Dtos.Responses.Device;
using Device_management_software.Models.Entities;
using Device_management_software.Models.Enums;
using Device_management_software.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Device_management_software.Controllers
{
    public class DevicesController : Controller
    {
        private readonly IDeviceService _deviceService;
        private readonly ICategoryService _categoryService;


        public DevicesController(IDeviceService deviceService, ICategoryService categoryService)
        {
            _deviceService = deviceService;
            _categoryService = categoryService;
        }

        // GET: Devices
        public async Task<IActionResult> Index(string searchTerm, int categoryId, int statusValue)
        {
            var devices = string.IsNullOrWhiteSpace(searchTerm)
            ? await _deviceService.GetAll()
            : await _deviceService.SearchByNameOrCode(searchTerm);

            if (categoryId != 0)
            {
                devices = devices.Where(x => x.Category.Id == categoryId);
            }

            if(statusValue != 0)
            {
                devices = devices.Where(x => x.Status == (Status)statusValue);
            }

            ViewBag.Categories = new SelectList(await _categoryService.GetAll(), nameof(Category.Id), nameof(Category.Name));
            var enumList = Enum.GetValues(typeof(Status))
            .Cast<Status>()
            .Select(status => new SelectListItem
            {
                Text = status.ToString(),
                Value = ((int)status).ToString()
            })
            .ToList();
            ViewBag.StatusList = enumList;
            ViewBag.SelectedCategory = categoryId;
            ViewBag.SelectedStatus = statusValue;
            ViewBag.SearchTerm = searchTerm;

            return View(devices);
        }

        // GET: Devices/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var device = await _deviceService.GetById(id);
            if (device == null)
            {
                return NotFound();
            }
            return View(device);
        }

        // GET: Devices/Create
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAll();
            ViewData["CategoryId"] = new SelectList(categories,
                nameof(Category.Id), nameof(Category.Name));

            var enumList = Enum.GetValues(typeof(Status))
            .Cast<Status>()
            .Select(status => new SelectListItem
            {
                Text = status.ToString(),
                Value = ((int)status).ToString()
            })
            .ToList();
            ViewBag.StatusList = enumList;

            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(DeviceRequest device)
        {
            if (ModelState.IsValid)
            {
                await _deviceService.CreateAsync(device);
                return RedirectToAction(nameof(Index));
            }
            return View(device);
        }

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var device = await _deviceService.GetById(id);
            if (device == null)
            {
                return NotFound();
            }
            var deviceUpdate = new DeviceRequest
            {
                Name = device.Name,
                Code = device.Code,
                CategoryId = device.Category.Id,
                Status = device.Status
            };

            var categories = await _categoryService.GetAll();
            ViewData["CategoryId"] = new SelectList(categories,
                nameof(Category.Id), nameof(Category.Name));

            var enumList = Enum.GetValues(typeof(Status))
            .Cast<Status>()
            .Select(status => new SelectListItem
            {
                Text = status.ToString(),
                Value = ((int)status).ToString()
            })
            .ToList();
            ViewBag.StatusList = enumList;
            return View(deviceUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(DeviceRequest device, int id)
        {
            if (ModelState.IsValid)
            {
                await _deviceService.UpdateAsync(device, id);
                return RedirectToAction(nameof(Index));
            }
            var categories = await _categoryService.GetAll();
            ViewData["CategoryId"] = new SelectList(categories,
                nameof(Category.Id), nameof(Category.Name));

            var enumList = Enum.GetValues(typeof(Status))
            .Cast<Status>()
            .Select(status => new SelectListItem
            {
                Text = status.ToString(),
                Value = ((int)status).ToString()
            })
            .ToList();
            ViewBag.StatusList = enumList;
            return View(device);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var device = await _deviceService.GetById(id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _deviceService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
