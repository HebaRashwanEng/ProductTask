using BusinessLogic.Core;
using DataMapping.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShoppingDemo.RestFulAPI.Controllers
{
    public class ProductsController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            var products = new ProductsLogic().GetAll();
            if (products==null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        public IHttpActionResult GetById(int id)
        {
            var product = new ProductsLogic().GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        public IHttpActionResult Post(Product product)
        {
            new ProductsLogic().Add(product);
            return Ok();
        }


        public IHttpActionResult Put(Product product)
        {
            new ProductsLogic().Update(product);
            return Ok();
        }
        
        public IHttpActionResult Delete(int id)
        {
            new ProductsLogic().Delete(id);
            return Ok();
        }
    }
}
