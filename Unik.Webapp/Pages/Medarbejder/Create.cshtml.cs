using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using Unik.WebApp.Infrastructure.Medarbej.Contract;
using Unik.WebApp.Infrastructure.Medarbej.Contract.Dto;

namespace Unik.WebApp.Pages.Medarbejder
{
    public class CreateModel : PageModel
    {
        private readonly IMedarbejderService _stamdataMedarbejderService;

        public CreateModel(IMedarbejderService stamdataMedarbejderService)
        {
            _stamdataMedarbejderService = stamdataMedarbejderService;
        }

        [BindProperty]
        public MedarbejderCreateViewModel MedarbejderModel { get; set; } = new();


        public ActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost(string message)
        {
            try
            {
                if (!ModelState.IsValid || !MedarbejderModel.Navn.IsNullOrEmpty() ||
                !MedarbejderModel.Tlf.IsNullOrEmpty() ||
                !MedarbejderModel.Titel.IsNullOrEmpty()) new Exception("Udfyld felterne");




                var dto = new MedarbejderCreateRequestDto
                {
                    Navn = MedarbejderModel.Navn,
                    Tlf = MedarbejderModel.Tlf,
                    Titel = MedarbejderModel.Titel,
                    Email = message,
                    UserId = message
                };


                await _stamdataMedarbejderService.Create(dto);
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return Page();
            }


            return new RedirectToPageResult("/Medarbejder/Index");



        }

    }
}
