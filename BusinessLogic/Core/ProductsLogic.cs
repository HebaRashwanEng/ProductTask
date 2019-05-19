using DataAccess.Repositories;
using DataMapping.Entities;
using System;
using System.Collections.Generic;


namespace BusinessLogic.Core
{
    public class ProductsLogic
    {
        public List<Product> GetAll()
        {
            return new ProductsRepository().GetAll();
        }

        public Product GetById(int id)
        {
            return new ProductsRepository().GetById(id);
        }

        public void Add(Product product)
        {
            new ProductsRepository().Add(product);
        }

        public void Update(Product product)
        {
            new ProductsRepository().Update(product);
        }

        public void Delete(int id)
        {
            new ProductsRepository().Delete(id);
        }

    }
}
