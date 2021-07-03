using REACTCrud.Authentication;
using REACTCrud.Interface;
using REACTCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REACTCrud.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ApplicationDbContext _applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }


        Product IProductRepository.Add(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            _applicationDbContext.Products.Add(item);
            _applicationDbContext.SaveChanges();
            return item;
        }

        bool IProductRepository.Delete(int id)
        {
            Product products = _applicationDbContext.Products.Find(id);
            _applicationDbContext.Products.Remove(products);
            _applicationDbContext.SaveChanges();
            return true;
        }

        Product IProductRepository.Get(int id)
        {
            return _applicationDbContext.Products.Find(id);
        }

        IEnumerable<Product> IProductRepository.GetAll()
        {
            return _applicationDbContext.Products;
        }

        bool IProductRepository.Update(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            var products = _applicationDbContext.Products.Single(a => a.ID == item.ID);
            products.Name = item.Name;
            products.Category = item.Category;
            products.Price = item.Price;
            _applicationDbContext.SaveChanges();

            return true;
        }
    }
}
