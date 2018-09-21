using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Talento.Clases;
using Talento.Models;

namespace Talento.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        /* private readonly IEmailSender _emailSender;*/

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger

           /* IEmailSender emailSender*/)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            /*_emailSender = emailSender*/;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public Users Usuario { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Debes Ingresar tu Apellido Paterno")]
            [StringLength(50)]
            [Display(Name = "Apellido Paterno")]
            public string Apaterno { get; set; }


            [Required(ErrorMessage = "Debes Ingresar tu Apellido Materno")]
            [StringLength(50)]
            [Display(Name = "Apellido Materno")]
            public string Amaterno { get; set; }


            [Required(ErrorMessage = "Debes Ingresar tu nombre")]
            [StringLength(50)]
            [Display(Name = "Nombre(s)")]
            public string Nombre { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Correo Electrónico")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña:")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar Contraseña:")]
            [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
            public string ConfirmPassword { get; set; }

            //[Required]
            //[StringLength(50)]
            //[Display(Name = "Ciudad")]
            //public string Ciudad { get; set; }

            [Required]
            [StringLength(50)]
            [Display(Name = "Estado")]
            public string Estado { get; set; }


        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                DataTable dt = new DataTable();
                dt = Estados.Consec(Input.Estado);
                int cons = Convert.ToInt32(dt.Rows[0][0].ToString()) +1;
                string corto = Estados.Abreviatura(Input.Estado);

                string consformat = string.Format("{0:0000}", cons);

                string membresia = corto + "-" + consformat;

                var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                { 
                    //_logger.LogInformation("El usuario creó una nueva cuenta con contraseña.");

                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { userId = user.Id, code = code },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "confirme su email",
                    //    $"Por favor confirme su cuenta por<a href='{HtmlEncoder.Default.Encode(callbackUrl)}'> clic aquí</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    await _userManager.AddToRoleAsync(user, "Silver");
                    Usuarios.InsertaUsuario(membresia, Input.Nombre, user.Email, Input.Estado, user.Id, Input.Apaterno, Input.Amaterno);

                    Estados.ActualizarConsecutivo(cons, Input.Estado);
                    
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
