using AspLesson4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspLesson4.Pages.Edit
{
    public class IndexModel : PageModel
    {
        private readonly ProductDbContext _context;

        public IndexModel(ProductDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Entities.Product Product { get; set; }
        public void OnGet(int id)
        {
            Product = _context.Products.FirstOrDefault(a => a.Id == id);
            
        }

        public IActionResult OnPost()
        {
            _context.Products.Update(Product);
            _context.SaveChanges();
            return Redirect("/Product");
        }

    }
}
