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

        public IEnumerable<Category_Request> GetAll()
        {
            return _context.Categories;
        }

        public Category_Request GetById(int id)
        {
            return getCategory(id);
        }
        public void Create(Category_Request model)
        {
            // validate
            if (_context.Categories.Any(x => x.CategoryName == model.CategoryName))
                throw new Exception("Category with the name '" + model.CategoryName + "' already exists");
            Category_Request category = new Category_Request();
            category.CategoryName = model.CategoryName;
            category.Manufacturer = model.Manufacturer;

            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(int id, Category_Request model)
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

        private Category_Request getCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) throw new KeyNotFoundException("Category not found");
            return category;
        }
    }
}
