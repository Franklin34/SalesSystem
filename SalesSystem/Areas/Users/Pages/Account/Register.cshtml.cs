using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalesSystem.Areas.Users.Models;
using SalesSystem.Libreria;

namespace SalesSystem.Areas.Users.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private LUserRoles _usersRole;

        public RegisterModel(SignInManager<IdentityUser> signInManager,UserManager<IdentityUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _usersRole = new LUserRoles();
        }

        public void OnGet()
        {
            Input = new InputModel
            {
                rolesLista = _usersRole.getRoles(_roleManager)
            };
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel : InputModelRegister
        {
            public IFormFile AvatarImage { get; set; }

            [TempData]
            public string ErrorMesagge { get; set; }
            public List<SelectListItem> rolesLista { get; set; }
        }
    }
}