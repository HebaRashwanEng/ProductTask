using BusinessLogic.Core;
using DataMapping.Entities;
using System.Web;
using System.Web.Mvc;

namespace ShoppingDemo.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index()
        {
            var products = new ProductsLogic().GetAll();
            return View(products);
        }

        public ActionResult Details(int id)
        {
            var product = new ProductsLogic().GetById(id);
            return View(product);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Product product,HttpPostedFileBase productPhoto)
        {
            if (productPhoto!=null)
            {
                string path = Server.MapPath("~/Photos/");
                string fname = productPhoto.FileName;
                productPhoto.SaveAs(path + fname);
                product.Photo = "/Photos/" + fname;
            }
            new ProductsLogic().Add(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product=new ProductsLogic().GetById(id);
            return View(product);
        }


        [HttpPost]
        public ActionResult Edit(Product product)
        {
            new ProductsLogic().Update(product);
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            new ProductsLogic().Delete(id);
            return RedirectToAction("Index");
        }

    }
}