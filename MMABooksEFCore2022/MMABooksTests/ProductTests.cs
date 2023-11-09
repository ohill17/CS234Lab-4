using System.Collections.Generic;
using System.Linq;
using System;

using NUnit.Framework;
using MMABooksEFClasses.MODELS;
using Microsoft.EntityFrameworkCore;

namespace MMABooksTests
{
    [TestFixture]
    public class ProductTests
    {
        
        MMABOOKSCONTEXT dbContext;

        Product? s;
        List<Invoicelineitem>? invoice;

        List<Product>? products;

        [SetUp]
        public void Setup()

        {
            dbContext = new MMABOOKSCONTEXT();
            dbContext.Database.ExecuteSqlRaw("call usp_testingResetData()");
        }

        [Test]
        public void GetAllTest()
        {
            products = dbContext.Products.OrderBy(s => s.ProductCode).ToList();
            Assert.AreEqual(16, products.Count);
            Assert.AreEqual("A4CS", products[0].ProductCode);
            PrintAll(products);
        }

        [Test]
        public void GetByPrimaryKeyTest()
        {

            s = dbContext.Products.Find("A4CS");
            Assert.IsNotNull(s);
            Assert.AreEqual("Murach's ASP.NET 4 Web Programming with C# 2010", s.Description);
            Console.WriteLine(s);

        }

        [Test]
        public void GetUsingWhere()
        {
            var products = dbContext.Products.Where(p => p.UnitPrice == 56.50m).ToList();


            Assert.AreEqual(7, products.Count); 
                                                            
            PrintAll(products);
        }

        [Test]
        public void GetWithCalculatedFieldTest()
        {
            // get a list of objects that include the productcode, unitprice, quantity and inventoryvalue
            var products = dbContext.Products.Select(
            p => new { p.ProductCode, p.UnitPrice, p.OnHandQuantity, Value = p.UnitPrice * p.OnHandQuantity }).
            OrderBy(p => p.ProductCode).ToList();
            Assert.AreEqual(16, products.Count);
            foreach (var p in products)
            {
                Console.WriteLine(p);
            }
        }
        [Test]
        public void DeleteTest()
        {
            s = dbContext.Products.Find("A4CS");

            dbContext.Products.Remove(s);

            dbContext.SaveChanges();
            

            s = dbContext.Products.Find("A4CS");
            Assert.IsNull(s);
        }

        [Test]
        public void CreateTest()
        {
            Product newProduct = new Product
            {
                ProductCode = "GH54", 
                Description = "Book about Drugs", 
                UnitPrice = 69.99m, 
                OnHandQuantity = 50 
            };

           
            dbContext.Products.Add(newProduct);
            dbContext.SaveChanges();

            s = dbContext.Products.Find("GH54");
            Assert.IsNotNull(s);

            Assert.AreEqual("Book about Drugs", s.Description);
            Assert.AreEqual(69.99m, s.UnitPrice);
            Assert.AreEqual(50, s.OnHandQuantity);
            Console.WriteLine(s);
        }

        [Test]
        public void UpdateTest()
        {
            s = dbContext.Products.Find("A4VB"); 
            Assert.IsNotNull(s);

            s.Description = "YEAHHHH UPDATED";

            dbContext.SaveChanges();

            s = dbContext.Products.Find("A4VB");
            Assert.IsNotNull(s);
            Assert.AreEqual("YEAHHHH UPDATED", s.Description);
            Console.WriteLine(s);
        }
        public void PrintAll(List<Product> products)
        {
            foreach (Product s in products)
            {
                Console.WriteLine(s);
            }
        }
    }
}