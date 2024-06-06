using Classes;
using InterfacesLL;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace Website.Pages
{
    public class MenuAlcoholsModel : PageModel
    {
        public List<Alcohol> AlcoholList { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public int TotalPages { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 5;
        public bool IsLoggedIn { get; set; }

        private readonly IAlcoholService _alcoholService;

        public MenuAlcoholsModel(IAlcoholService alcoholService)
        {
            _alcoholService = alcoholService;
        }

        public async Task OnGetAsync()
        {
            if (User.FindFirst("id") != null)
            {
                IsLoggedIn = true;
            }

            var totalItemCount = await _alcoholService.GetTotalAlcoholsCountAsync();
            TotalPages = (int)Math.Ceiling(totalItemCount / (double)PageSize);

            AlcoholList = await _alcoholService.GetPaginationAlcoholsAsync(CurrentPage, PageSize);
        }
        public IActionResult OnGetImage(int id)
        {
            var e = _alcoholService.GetAlcoholById(id);
            if (e != null && e.Picture != null)
            {
                return File(e.Picture, "image/jpeg");
            }
            return NotFound();
        }
    }
}
