using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorCRUDWebApplication.Data;
using RazorCRUDWebApplication.Model;

namespace RazorCRUDWebApplication.Pages.Categories
{
    [BindProperties] // used to bind the the model properties
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        
        //[BindProperty] //bind the single model property
        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            // find() will work on the primary key of the table
            Category = _db.Category.Find(id);     

            // first() requires lambda expression and selects the first value, If the fisrt will not get the value it throws an exception or
            // FirstOrDefault() will return null if they found nothing
            // Category = _db.Category.First(u => u.Id == id);

            //  Single() returns only single value, if the get multiple values it throws an error
            // SingleOrDefault() will return null if they found nothing
            // Category = _db.Category.Single(u => u.Id == id);

            // Where() it returns multiple records if the condition matches
            // Category = _db.Category.Where(u => u.Id == id).FirstOrDefault();
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
                _db.Category.Update(Category);
                await _db.SaveChangesAsync();

                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
