using Device_management_software.Models.Dtos.Requests.User;
using Device_management_software.Models.Enums;
using Device_management_software.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Device_management_software.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _userService.GetAll();
            return View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        public IActionResult Create()
        {
            var enumList = Enum.GetValues(typeof(Role))
            .Cast<Role>()
            .Select(role => new SelectListItem
            {
                Text = role.ToString(),
                Value = ((int)role).ToString()
            })
            .ToList();
            ViewBag.RoleList = enumList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRequest user)
        {
            if (ModelState.IsValid)
            {
                await _userService.Register(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var device = await _userService.GetById(id);
            if (device == null)
            {
                return NotFound();
            }
            var deviceUpdate = new UserRequest
            {
                Email = device.Email,
                Name = device.Name,
                Phone = device.Phone,
                Role = device.Role
            };
            var enumList = Enum.GetValues(typeof(Role))
            .Cast<Role>()
            .Select(role => new SelectListItem
            {
                Text = role.ToString(),
                Value = ((int)role).ToString()
            })
            .ToList();
            ViewBag.RoleList = enumList;
            return View(deviceUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserRequest user, int id)
        {
            if (ModelState.IsValid)
            {
                await _userService.UpdateAsync(user, id);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var device = await _userService.GetById(id);
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
            await _userService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
