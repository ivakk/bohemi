using Classes;
using InterfacesLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Pages
{
    public class MenuSoftDrinksModel : PageModel
    {
        public List<Soft> SoftList { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        public int TotalPages { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 5;
        public bool IsLoggedIn { get; set; }

        private readonly ISoftService _softService;

        public MenuSoftDrinksModel(ISoftService softService)
        {
            _softService = softService;
        }

        public async Task OnGetAsync()
        {
            if (User.FindFirst("id") != null)
            {
                IsLoggedIn = true;
            }

            var totalItemCount = await _softService.GetTotalSoftsCountAsync();
            TotalPages = (int)Math.Ceiling(totalItemCount / (double)PageSize);

            SoftList = await _softService.GetPaginationSoftsAsync(CurrentPage, PageSize);
        }
        public IActionResult OnGetImage(int id)
        {
            var e = _softService.GetSoftById(id);
            if (e != null && e.Picture != null)
            {
                return File(e.Picture, "image/jpeg");
            }
            return NotFound();
        }
    }
}
