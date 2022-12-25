using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using TimirzinEShop.Areas.Identity.Data;

namespace TimirzinEShop.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<EShopUser> _signInManager;
        private readonly UserManager<EShopUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<EShopUser> userManager,
            SignInManager<EShopUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Не указана электронная почта")]
            [EmailAddress(ErrorMessage = "Неверный формат")]
            [Display(Name = "Электронная почта")]
            public string Email { get; set; }

            [Display(Name = "Имя")]
            [Required(ErrorMessage = "Не указано Ваше имя")]
            public string FirstName { get; set; }

            [Display(Name = "Фамилия")]
            [Required(ErrorMessage = "Не указана Ваша фамилия")]
            public string LastName { get; set; }

            [Display(Name = "Отчество")]
            public string MiddleName { get; set; }

            [Display(Name = "Адрес")]
            [Required(ErrorMessage = "Не указан адрес доставки")]
            public string Address { get; set; }

            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Номер телефона")]
            [Required(ErrorMessage = "Не указан Ваш номер телефона")]
            public string Phone { get; set; }

            [Required(ErrorMessage = "Не указан пароль")]
            [StringLength(100, ErrorMessage = "{0} должен быть длиной не меньше {2} и не больше {1} символов.", MinimumLength = 3)]
            [Display(Name = "Пароль")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Повторите пароль")]
            [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
            [DataType(DataType.Password)]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new EShopUser { 
                    UserName = Input.Email, 
                    Email = Input.Email,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    MiddleName = Input.MiddleName,
                    Phone = Input.Phone,
                    Address = Input.Address,
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
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
