using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using MMABooksEFClasses.MODELS;
using Microsoft.EntityFrameworkCore;

namespace MMABooksTests
{
    [TestFixture]
    public class YeastTests
    {
        private MMABOOKSCONTEXT dbContext;
        private Yeast yeast;

        [SetUp]
        public void Setup()
        {
            dbContext = new MMABOOKSCONTEXT();
        }

        [Test]
        public void GetAllYeastTest()
        {
            var yeasts = dbContext.Yeasts.OrderBy(y => y.IngredientId).ToList();
            Assert.AreEqual(483, yeasts.Count);
            PrintAll(yeasts);
        }

      

        [Test]
        public void GetYeastByAddToSecondaryTest()
        {
            var yeasts = dbContext.Yeasts.Where(y => y.AddToSecondary == 1).ToList();
            Assert.AreEqual( 15, yeasts.Count);
            PrintAll(yeasts);
        }

   

        [Test]
        public void GetYeastOrderedByAttenuationDescendingTest()
        {
            var yeasts = dbContext.Yeasts.OrderByDescending(y => y.Attenuation).ToList();
            Assert.AreEqual(483 , yeasts.Count);
            PrintAll(yeasts);
        }

        [Test]
        public void CreateYeastTest()
        {
            // Arrange
            Yeast newYeast = new Yeast
            {
                IngredientId = 900,
                ProductId = "NewProductId",
                MinTemp = 20.0,
                MaxTemp = 25.0,
                Form = "Dry",
                Laboratory = "NewLab",
                Flocculation = "High",
                Attenuation = 75.0,
                MaxReuse = 3,
                AddToSecondary = 0,
                Type = "Ale",
                BestFor = "BestForTest"
            };

            // Act
            dbContext.Yeasts.Add(newYeast);
            dbContext.SaveChanges();

            // Assert
            yeast = dbContext.Yeasts.Find(newYeast.IngredientId);
            Assert.IsNotNull(yeast);
            Assert.AreEqual("NewProductId", yeast.ProductId);
        }

        public void PrintAll(List<Yeast> yeasts)
        {
            foreach (var yeast in yeasts)
            {
                Console.WriteLine(yeast);
            }
        }
    }
}