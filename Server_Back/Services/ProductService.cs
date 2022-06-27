using Server_Back.Models;

namespace Server_Back.Services
{

    public class ProductService 
    {
        private ServerDbContext _context;

        public ProductService(ServerDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product_Request> GetAll()
        {
            return (IEnumerable<Product_Request>)_context.Products;
        }

        public Product_Request GetById(int id)
        {
            return getProduct(id);
        }

        public void Create(Product_Request model)
        {
            // validate
            if (_context.Products.Any(x => x.ProductName == model.ProductName))
                throw new Exception("Product with the name '" + model.ProductName + "' already exists");
            Product_Request product = new Product_Request();
            product.ProductName = model.ProductName;
            product.CategoryId = model.CategoryId;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Created = DateTime.Now;

            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(int id, Product_Request model)
        {
            var product = getProduct(id);
            product.ProductName = model.ProductName;
            product.CategoryId = model.CategoryId;
            product.Description = model.Description;
            product.Price = model.Price;

            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = getProduct(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        // helper methods

        private Product_Request getProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) throw new KeyNotFoundException("Product not found");
            return product;
        }
    }
}
