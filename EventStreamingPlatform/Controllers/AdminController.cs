using EventStreamingPlatform.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EventStreamingPlatform.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminController(RoleManager<IdentityRole> roleManager)
        { 
            this.roleManager = roleManager;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProjectRole role)
        {
            
            var roleexist = await roleManager.RoleExistsAsync(role.RoleName);
            if (!roleexist)
            {
                var result = await roleManager.CreateAsync(new IdentityRole(role.RoleName));
            }
            return View();
        }
    }
}
