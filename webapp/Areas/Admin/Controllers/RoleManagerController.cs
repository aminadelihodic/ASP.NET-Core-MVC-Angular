using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rentacar.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RoleManagerController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleManagerController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(string roleName)
        {
            if(roleName != null)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(string Id)
        {
            var existingRole = await _roleManager.FindByIdAsync(Id);
            if (existingRole == null)
                return NotFound();

            return View(existingRole);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(IdentityRole role)
        {
            var existingRole = await _roleManager.FindByIdAsync(role.Id);

            if (existingRole == null)
                return NotFound();

            await _roleManager.SetRoleNameAsync(existingRole, role.Name);
            await _roleManager.UpdateAsync(existingRole);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string Id)
        {
            var existingRole = await _roleManager.FindByIdAsync(Id);

            if (existingRole == null)
                return NotFound();

            await _roleManager.DeleteAsync(existingRole);
            
            return RedirectToAction("Index");
        }

    }
}
