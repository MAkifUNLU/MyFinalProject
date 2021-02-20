using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()//constructor
        {
            //Oracle, SQL, Postgres, MongoDB geeliyormuş gibi simüle ediyoruz
            _products = new List<Product> { 
            new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
            new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
            new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
            new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
            new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1},
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ Language Integrated Query = Dile gömülü sorgulama
            //Lambda (=>)    Çoklu yorum satırı 33. satırın uzun hali
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(productToDelete);
            /*Product productToDelete = null;//= new Product();  <--bu ifadeye gerek yok
            foreach (var p in _products)
            {
                if (product.ProductID == p.ProductID)
                {
                    productToDelete = p; 
                }
            }
            productToDelete=*/

        }

        public List<Product> GetAll()
        {
            return _products;
        }

        
        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            Product productUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productUpdate.ProductName = product.ProductName;
            productUpdate.CategoryId = product.CategoryId;
            productUpdate.UnitPrice = product.UnitPrice;
            productUpdate.UnitsInStock = product.UnitsInStock;
        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
