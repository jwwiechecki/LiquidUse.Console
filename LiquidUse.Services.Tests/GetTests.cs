﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
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
        public void Get_LiquidDataItems_ReturnAllItems()
        {
            //Arange
            var data = new List<LiquidData>()
            {
                new LiquidData(){Id = 1, Date = DateTime.Now, Kind = KindEnum.Tea, Use = 0.250M},
                new LiquidData(){Id = 2, Date = DateTime.Now, Kind = KindEnum.Coffe, Use = 0.250M},
                new LiquidData(){Id = 3, Date = DateTime.Now, Kind = KindEnum.Pepsi, Use = 0.5M}
            }.AsQueryable();

            var mocLiquidDataSet = new Mock<DbSet<LiquidData>>();
            mocLiquidDataSet.As<IQueryable<LiquidData>>().Setup(x => x.GetEnumerator()).Returns(() => data.GetEnumerator());

            var mockContext = new Mock<LiquidUseQueryDbContext>();
            
            mockContext.Setup(m => m.LiquidDatas).Returns(mocLiquidDataSet.Object);

            var service = new LiquidUseService(mockContext.Object);

            //Act
            var items = service.GetLiquidDataItems();

            //Assert
            Assert.AreEqual(3, items.Count);
        }
    }
}