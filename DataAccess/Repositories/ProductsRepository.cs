using DataMapping.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataAccess.Repositories
{
    public class ProductsRepository
    {
        public List<Product> GetAll()
        {
            using (var db=new ProductCatalogDBEntities())
            {
                return db.Products.ToList();
            }
        }

        public Product GetById(int id)
        {
            using (var db = new ProductCatalogDBEntities())
            {
                return db.Products.FirstOrDefault(p => p.Id == id);
            }
        }

        public void Add(Product product)
        {
            using (var db = new ProductCatalogDBEntities())
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            using (var db = new ProductCatalogDBEntities())
            {
                var prod = db.Products.FirstOrDefault(p=>p.Id==product.Id);
                if (prod!=null)
                {
                    prod.Name = product.Name;
                    prod.Photo = product.Photo;
                    prod.Price = product.Price;
                    prod.LastUpdated = product.LastUpdated;
                    db.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using(var db = new ProductCatalogDBEntities())
            {
                var prod = db.Products.FirstOrDefault(p => p.Id ==id);
                db.Products.Remove(prod);
                db.SaveChanges();
            }
        }


    }
}
