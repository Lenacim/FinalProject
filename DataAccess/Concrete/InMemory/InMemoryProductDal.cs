using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    //teknoloji Class Katman  InMemoryProductDal
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            //Oracle,sql server, Postgres, MongoDb
            _products = new List<Product>
            {
                new Product{ProductId =1,CategoryId=1, ProductName="Bardak", UnitPrice=15, UnitsInStock=15},
                new Product{ProductId =2,CategoryId=1, ProductName="Kamera", UnitPrice=500, UnitsInStock=3},
                new Product{ProductId =3,CategoryId=1, ProductName="Telefon", UnitPrice=1500, UnitsInStock=2},
                new Product{ProductId =4,CategoryId=1, ProductName="Klavye", UnitPrice=150, UnitsInStock=65},
                new Product{ProductId =5,CategoryId=1, ProductName="Fare", UnitPrice=85, UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ - Language Integrated Query
            //Product productToDelete =null;

            //foreach (var p in _products)
            //{
            //    if(p.ProductId == product.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //lambda isareti p tektek dolasicak product

            //SingleOrDefault veya First tek bir eleman bulmaya calisir 

            if (productToDelete !=null)
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int CategoryId)
        {
            //Linq de  Where komutu yeni liste olusturur geri dondurur
            return _products.Where(p => p.CategoryId == CategoryId).ToList() ;
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //Gönderdigim urun id'sine sahip olan listedeki  urunu bul demek
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //lambda isareti p tektek dolasicak product
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }
    }
}
