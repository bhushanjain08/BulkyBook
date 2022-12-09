using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCRUDWebApplication.Data;
using RazorCRUDWebApplication.Model;

namespace RazorCRUDWebApplication.Pages.Categories
{
    [BindProperties] // used to bind the the model properties
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        //[BindProperty] //bind the single model property
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            //Server side custom validations
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                //show the error message on top
                ModelState.AddModelError(string.Empty, "The display order can not be exact match the name.");

                //show the error message below the name input box
                ModelState.AddModelError("Category.Name", "The display order can not be exact match the name.");
            }
            if(ModelState.IsValid)
            {
                await _db.Category.AddAsync(Category);
                await _db.SaveChangesAsync();

                // TempData is remain for only one request if we refresh the page it goes away
                TempData["success"] = "Category Created successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
