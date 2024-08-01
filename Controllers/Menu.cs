using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class Menu : Controller
    {
        private readonly MenuContext _context;
        public Menu (MenuContext context)
        {
            _context = context;
        }
      public async Task<IActionResult> Index(string searchString) {
            var dishes = from d in _context.Dishes
                       select d;
            if(!string.IsNullOrEmpty(searchString))
                {
                dishes = dishes.Where(d=> d.name.Contains(searchString));
            }
            return View(await dishes.ToListAsync());
        }

    public async Task<IActionResult> Details (int? id)
        {
            var dish = await _context.Dishes.Include(di => di.DishIngredients).ThenInclude(i => i.Ingredient)
                .FirstOrDefaultAsync(x => x.id ==id);
            if(dish == null)
            {
              return NotFound();
            }
            return View(dish);

        }
    }
}
