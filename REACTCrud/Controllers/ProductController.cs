using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REACTCrud.Interface;
using REACTCrud.Models;
using REACTCrud.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace REACTCrud.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ClaimsPrincipal _caller;
        private readonly HttpContext httpContext;


        public ProductController(IHttpContextAccessor httpContextAccessor, IProductRepository productRepository)
        {
            _caller = httpContextAccessor.HttpContext.User;
            httpContext = httpContextAccessor.HttpContext;
            _productRepository = productRepository;
        }
        // GET api/GetAllProducts

        [Route("GetAllProducts")]
        public IEnumerable<Product> GetAllProducts()
        {
            Claim claim = _caller.Claims.FirstOrDefault();

            return _productRepository.GetAll();
        }


        // GET api/GetAllProducts

        [Route("GetProductDetails")]
        public Product GetProductDetails(int id)
        {
            Product prd = _productRepository.Get(id);
            return prd;

        }
        // POST api/PostProduct
        [Route("PostProduct")]
        public Product PostProduct(Product item)
        {
            return _productRepository.Add(item);
        }



        // PUT api/PutProduct/id
        [Route("PutProduct/{id}")]
        public IEnumerable PutProduct(int id, Product product)
        {
            product.ID = id;
            if (_productRepository.Update(product))
            {
                return _productRepository.GetAll();
            }
            else
            {
                return null;
            }
        }

        //Delete api/DeleteProduct
        [Route("DeleteProduct/{id}")]
        public bool DeleteProduct(int id)
        {
            if (_productRepository.Delete(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
       
}
