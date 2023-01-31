using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using Microsoft.EntityFrameworkCore;
using LiquidUse.Database.Model;
using LiquidUse.Database;
using LiquidUse.Services.Classes;
using LiquidUse.Common.Enums;
using System.Linq;

namespace LiquidUse.Services.Tests
{
    public class GetTests
    {
        [Test]
        [TestCase(null, null, 4)]
        [TestCase("2022-12-20", null, 4)]
        [TestCase(null, "2023-01-31", 4)]
        [TestCase("2022-12-20", "2023-01-31", 4)]
        [TestCase("2023-01-17", "2023-01-20", 2)]
        public void Get_LiquidDataItems_ReturnAllItems(DateTime? from, DateTime? to, int expected)
        {
            //Arange
            var data = new List<LiquidData>()
            {
                new LiquidData(){Id = 1, Date = new DateTime(2022,12,31), Kind = KindEnum.Tea, Use = 0.250M},
                new LiquidData(){Id = 2, Date = new DateTime(2023,1,18), Kind = KindEnum.Coffe, Use = 0.250M},
                new LiquidData(){Id = 3, Date = new DateTime(2023,1,19), Kind = KindEnum.Pepsi, Use = 0.5M},
                new LiquidData(){Id = 3, Date = new DateTime(2023,1,23), Kind = KindEnum.Coffe, Use = 0.5M}
            }.AsQueryable();

            var mocLiquidDataSet = new Mock<DbSet<LiquidData>>();
            mocLiquidDataSet.As<IQueryable<LiquidData>>().Setup(m => m.Provider).Returns(data.Provider);
            mocLiquidDataSet.As<IQueryable<LiquidData>>().Setup(m => m.Expression).Returns(data.Expression);
            mocLiquidDataSet.As<IQueryable<LiquidData>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mocLiquidDataSet.As<IQueryable<LiquidData>>().Setup(x => x.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<LiquidUseQueryDbContext>();
            
            mockContext.Setup(m => m.LiquidDatas).Returns(mocLiquidDataSet.Object);

            var service = new LiquidUseService(mockContext.Object);

            //Act
            var items = service.GetItems(from, to);

            //Assert
            Assert.AreEqual(expected, items.Count);
        }

        [Test]
        public void GetLiquidDataItemById_ReturnItemWithGivenId()
        {
            var data = new List<LiquidData>()
            {
                new LiquidData(){Id = 1, Date = DateTime.Now, Kind = KindEnum.Tea, Use = 0.250M},
                new LiquidData(){Id = 2, Date = DateTime.Now, Kind = KindEnum.Coffe, Use = 0.250M},
                new LiquidData(){Id = 3, Date = DateTime.Now, Kind = KindEnum.Pepsi, Use = 0.5M}
            }.AsQueryable();

            var mocLiquidDataSet = new Mock<DbSet<LiquidData>>();
            mocLiquidDataSet.As<IQueryable<LiquidData>>().Setup(m => m.Provider).Returns(data.Provider);
            mocLiquidDataSet.As<IQueryable<LiquidData>>().Setup(m => m.Expression).Returns(data.Expression);
            mocLiquidDataSet.As<IQueryable<LiquidData>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mocLiquidDataSet.As<IQueryable<LiquidData>>().Setup(x => x.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<LiquidUseQueryDbContext>();

            mockContext.Setup(m => m.LiquidDatas).Returns(mocLiquidDataSet.Object);

            var service = new LiquidUseService(mockContext.Object);

            //Act
            var item = service.GetItemById(2);

            //Assert
            Assert.AreEqual(2, item.Id);
        }

        [Test]
        public void GetLiquidDataItemByNoExistingId_RetunNull()
        {
            var data = new List<LiquidData>()
            {
                new LiquidData(){Id = 1, Date = DateTime.Now, Kind = KindEnum.Tea, Use = 0.250M},
                new LiquidData(){Id = 2, Date = DateTime.Now, Kind = KindEnum.Coffe, Use = 0.250M},
                new LiquidData(){Id = 3, Date = DateTime.Now, Kind = KindEnum.Pepsi, Use = 0.5M}
            }.AsQueryable();

            var mocLiquidDataSet = new Mock<DbSet<LiquidData>>();
            mocLiquidDataSet.As<IQueryable<LiquidData>>().Setup(m => m.Provider).Returns(data.Provider);
            mocLiquidDataSet.As<IQueryable<LiquidData>>().Setup(m => m.Expression).Returns(data.Expression);
            mocLiquidDataSet.As<IQueryable<LiquidData>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mocLiquidDataSet.As<IQueryable<LiquidData>>().Setup(x => x.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<LiquidUseQueryDbContext>();

            mockContext.Setup(m => m.LiquidDatas).Returns(mocLiquidDataSet.Object);

            var service = new LiquidUseService(mockContext.Object);

            //Act
            var item = service.GetItemById(6);

            //Assert
            Assert.IsNull(item);
        }

        [Test]
        [TestCase(null, null, 3)]
        [TestCase("2022-12-20", null, 3)]
        [TestCase(null, "2023-01-31", 3)]
        [TestCase("2022-12-20", "2023-01-31", 3)]
        [TestCase("2023-01-17", "2023-01-20", 2)]
        public void GetLiquidDataItemByKindEnum_ReturnItemWithGivenId(DateTime? from, DateTime? to, int expected)
        {
            var data = new List<LiquidData>()
            {
                new LiquidData(){Id = 1, Date = new DateTime(2022,12,31), Kind = KindEnum.Tea, Use = 0.250M},
                new LiquidData(){Id = 2, Date = new DateTime(2023,1,18), Kind = KindEnum.Coffe, Use = 0.250M},
                new LiquidData(){Id = 3, Date = new DateTime(2023,1,19), Kind = KindEnum.Coffe, Use = 0.5M},
                new LiquidData(){Id = 4, Date = new DateTime(2023,1,23), Kind = KindEnum.Coffe, Use = 0.5M}
            }.AsQueryable();

            var mocLiquidDataSet = new Mock<DbSet<LiquidData>>();
            mocLiquidDataSet.As<IQueryable<LiquidData>>().Setup(m => m.Provider).Returns(data.Provider);
            mocLiquidDataSet.As<IQueryable<LiquidData>>().Setup(m => m.Expression).Returns(data.Expression);
            mocLiquidDataSet.As<IQueryable<LiquidData>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mocLiquidDataSet.As<IQueryable<LiquidData>>().Setup(x => x.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<LiquidUseQueryDbContext>();

            mockContext.Setup(m => m.LiquidDatas).Returns(mocLiquidDataSet.Object);

            var service = new LiquidUseService(mockContext.Object);

            //Act
            var items = service.GetItemsByKind(KindEnum.Coffe, from, to);

            //Assert
            Assert.AreEqual(expected, items.Count);
        }

        [Test]
        [TestCase(null, null, 0)]
        [TestCase("2022-12-20", null, 0)]
        [TestCase(null, "2023-01-31", 0)]
        [TestCase("2022-12-20", "2023-01-31", 0)]
        [TestCase("2023-01-17", "2023-01-20", 0)]
        public void GetLiquidDataItemByNoExistingItemKindInDb_RetunZero(DateTime? from, DateTime? to, int expected)
        {
            var data = new List<LiquidData>()
            {
                new LiquidData(){Id = 1, Date = new DateTime(2022,12,31), Kind = KindEnum.Tea, Use = 0.250M},
                new LiquidData(){Id = 2, Date = new DateTime(2023,1,18), Kind = KindEnum.Coffe, Use = 0.250M},
                new LiquidData(){Id = 3, Date = new DateTime(2023,1,19), Kind = KindEnum.Coffe, Use = 0.5M},
                new LiquidData(){Id = 4, Date = new DateTime(2023,1,23), Kind = KindEnum.Coffe, Use = 0.5M}
            }.AsQueryable();

            var mocLiquidDataSet = new Mock<DbSet<LiquidData>>();
            mocLiquidDataSet.As<IQueryable<LiquidData>>().Setup(m => m.Provider).Returns(data.Provider);
            mocLiquidDataSet.As<IQueryable<LiquidData>>().Setup(m => m.Expression).Returns(data.Expression);
            mocLiquidDataSet.As<IQueryable<LiquidData>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mocLiquidDataSet.As<IQueryable<LiquidData>>().Setup(x => x.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<LiquidUseQueryDbContext>();

            mockContext.Setup(m => m.LiquidDatas).Returns(mocLiquidDataSet.Object);

            var service = new LiquidUseService(mockContext.Object);

            //Act
            var items = service.GetItemsByKind(KindEnum.Dinner, from, to);

            //Assert
            Assert.AreEqual(expected, items.Count);
        }
        
        [Test]
        public void DeleteItem_ReturnVoid()
        {
            var data = new List<LiquidData>()
            {
                new LiquidData(){Id = 1, Date = new DateTime(2022,12,31), Kind = KindEnum.Tea, Use = 0.250M},
                new LiquidData(){Id = 2, Date = new DateTime(2023,1,18), Kind = KindEnum.CocaCola, Use = 0.250M},
                new LiquidData(){Id = 3, Date = new DateTime(2023,1,19), Kind = KindEnum.Coffe, Use = 0.5M},
                new LiquidData(){Id = 4, Date = new DateTime(2023,1,23), Kind = KindEnum.SparklingWater, Use = 0.5M}
            };

            var mocLiquidDataSet = new Mock<DbSet<LiquidData>>();
            mocLiquidDataSet.As<IQueryable<LiquidData>>().Setup(m => m.Provider).Returns(data.AsQueryable().Provider);
            mocLiquidDataSet.As<IQueryable<LiquidData>>().Setup(m => m.Expression).Returns(data.AsQueryable().Expression);
            mocLiquidDataSet.As<IQueryable<LiquidData>>().Setup(m => m.ElementType).Returns(data.AsQueryable().ElementType);
            mocLiquidDataSet.As<IQueryable<LiquidData>>().Setup(x => x.GetEnumerator()).Returns(() => data.GetEnumerator());
            mocLiquidDataSet.Setup(m => m.Remove(It.IsAny<LiquidData>())).Callback<LiquidData>((entity) => data.Remove(entity));

            var mockContext = new Mock<LiquidUseQueryDbContext>();

            mockContext.Setup(m => m.LiquidDatas).Returns(mocLiquidDataSet.Object);

            var service = new LiquidUseService(mockContext.Object);

            //Act
            service.DeleteItem(3);

            //Assert
            Assert.AreEqual(3, data.Count);
        }
    }
}
