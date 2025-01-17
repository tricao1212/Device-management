using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Device_management_software.Data;
using Device_management_software.Models.Entities;
using Device_management_software.Services.Interfaces;
using Device_management_software.Services.Implements;
using Device_management_software.Models.Dtos.Requests.User;
using Device_management_software.Models.Enums;
using Device_management_software.Models.Dtos.Requests.Category;

namespace Device_management_software.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _cateGoryService;

        public CategoriesController(ICategoryService cateGoryService)
        {
            _cateGoryService = cateGoryService;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var categories = await _cateGoryService.GetAll();
            return View(categories);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var category = await _cateGoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryRequest category)
        {
            if (ModelState.IsValid)
            {
                await _cateGoryService.CreateAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _cateGoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            var categoryUpdate = new CategoryRequest
            {
                Name = category.Name
            };
           
            return View(categoryUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryRequest category, int id)
        {
            if (ModelState.IsValid)
            {
                await _cateGoryService.UpdateAsync(category, id);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var category = await _cateGoryService.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await _cateGoryService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
