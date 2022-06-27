using DTO;
using Server_Back.Models;

namespace Server_Back.Services
{

    public class CategoryService
    {
        private ServerDbContext _context;

        public CategoryService(ServerDbContext context)
        {
            _context = context;
        }

        public IEnumerable<CategoryModel> GetAll()
        {
            return _context.Categories;
        }

        public CategoryModel GetById(int id)
        {
            return getCategory(id);
        }
        public void Create(Category model)
        {
            // validate
            if (_context.Categories.Any(x => x.CategoryName == model.CategoryName))
                throw new Exception("Category with the name '" + model.CategoryName + "' already exists");
            CategoryModel category = new CategoryModel();
            category.CategoryName = model.CategoryName;
            category.Manufacturer = model.Manufacturer;

            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(int id, Category model)
        {
            var category = getCategory(id);

            // validate
            if (model.CategoryName != category.CategoryName && _context.Categories.Any(x => x.CategoryName == model.CategoryName && x.CategoryId != id))
                throw new Exception("Category with the name '" + model.CategoryName + "' already exists");
            category.CategoryName = model.CategoryName;
            category.Manufacturer = model.Manufacturer;


            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var category = getCategory(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        // helper methods

        private CategoryModel getCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) throw new KeyNotFoundException("Category not found");
            return category;
        }
    }
}
