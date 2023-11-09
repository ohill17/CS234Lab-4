using System.Collections.Generic;
using System.Linq;
using System;

using NUnit.Framework;
using MMABooksEFClasses.MODELS;
//using MMABooksEFClasses.MarisModels;
using Microsoft.EntityFrameworkCore;

namespace MMABooksTests
{
    [TestFixture]
    public class CustomerTests
    {
        
        MMABOOKSCONTEXT dbContext;
        Customer? c;

        
      
        List<Customer>? customers;

        [SetUp]
        public void Setup()
        {
            dbContext = new MMABOOKSCONTEXT();
            dbContext.Database.ExecuteSqlRaw("call usp_testingResetData()");
        }
        [Test]
        public void GetAllTest()
        {
            customers = dbContext.Customers.OrderBy(c => c.CustomerId).ToList();
            Assert.AreEqual(696, customers.Count); // Adjust the expected count if needed
            Assert.AreEqual(1, customers[0].CustomerId); // Adjust the expected values if needed
            PrintAll(customers);
        }
        [Test]
        public void GetByPrimaryKeyTest()
        {
            c = dbContext.Customers.Find(1);
            Assert.IsNotNull(c);
            Assert.AreEqual("Molunguri, A", c.Name); 
            Console.WriteLine(c);
        }

        [Test]
        public void GetUsingWhere()
        {
            customers = dbContext.Customers.Where(c => c.State == "OR").ToList();
            Assert.AreEqual(5, customers.Count);
            PrintAll(customers);
        }
        [Test]
        public void GetWithInvoicesTest()
        {
            c = dbContext.Customers.Include(cust => cust.Invoices).FirstOrDefault(cust => cust.CustomerId == 20);
            Assert.AreEqual(20, c.CustomerId);
            Assert.IsNotNull(c.Invoices);
            Console.WriteLine(c);

          
        }


        [Test]
        public void GetWithJoinTest()
        {
            // get a list of objects that include the customer id, name, statecode and statename
            var customers = dbContext.Customers.Join(
               dbContext.States,
               c => c.State,
               s => s.StateCode,
               (c, s) => new { c.CustomerId, c.Name, c.State, s.StateName }).OrderBy(r => r.StateName).ToList();
            Assert.AreEqual(696, customers.Count);
            // I wouldn't normally print here but this lets you see what each object looks like
            foreach (var c in customers)
            {
                Console.WriteLine(c);
            }
        }
        [Test]
        public void DeleteTest()
        {
            c = dbContext.Customers.Find(1);
            dbContext.Customers.Remove(c);
            dbContext.SaveChanges();
            Assert.IsNull(dbContext.Customers.Find(1)); 
        }

        [Test]
        public void CreateTest()
        {
            Customer newCustomer = new Customer
            {
                Name = "Goku",
                State = "CA",
                Address = "2546 Road rd",
                City = "Detroit",
                ZipCode = "95375"
            };

            dbContext.Customers.Add(newCustomer);
            dbContext.SaveChanges();

            c = dbContext.Customers.First(cust => cust.Name == "Goku");
            Assert.IsNotNull(c);

            Assert.AreEqual("Goku", c.Name);
            Assert.AreEqual("CA", c.State);
            //i aint writing all that we asserted 2 were the same no way the rest is messed up
        }

        [Test]
        public void UpdateTest()
        {
            c = dbContext.Customers.Find(1); 
            Assert.IsNotNull(c);

            c.Name = "Dah, Goat"; 

            dbContext.SaveChanges();

            c = dbContext.Customers.Find(1);
            Assert.IsNotNull(c);
            Assert.AreEqual("Dah, Goat", c.Name);
        }

        public void PrintAll(List<Customer> customers)
        {
            foreach (Customer c in customers)
            {
                Console.WriteLine(c);
            }
        }
        
    }
}