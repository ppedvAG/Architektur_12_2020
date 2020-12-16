using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ppedv.Druckverwaltung.Model;
using ppedv.Druckverwaltung.Model.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ppedv.Druckverwaltung.Logic.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void Core_GetLongestDruckauftrag_no_Aufträge()
        {
            var core = new Core(new TestRepo());

            var result = core.GetLongestDruckauftrag();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Core_GetLongestDruckauftrag_no_Aufträge_MOQ()
        {
            var mock = new Mock<IRepository>();
            var core = new Core(mock.Object);

            var result = core.GetLongestDruckauftrag();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Core_GetLongestDruckauftrag_zwei_Aufträge()
        {
            var mock = new Mock<IRepository>();

            mock.Setup(x => x.Query<Druckauftrag>()).Returns(() =>
            {
                var res = new List<Druckauftrag>();
                res.Add(new Druckauftrag()
                {
                    Material = "Schaum",
                    Start = new DateTime(2000, 1, 1),
                    Ende = new DateTime(2000, 1, 2),
                    Status = Druckstatus.Fertig
                });

                res.Add(new Druckauftrag()
                {
                    Material = "Gummi",
                    Start = new DateTime(2000, 1, 6),
                    Ende = new DateTime(2000, 1, 8),
                    Status= Druckstatus.Fertig
                });

                return res.AsQueryable();
            });

            var core = new Core(mock.Object);

            var result = core.GetLongestDruckauftrag();

            Assert.AreEqual("Gummi", result.Material);
        }

        [TestMethod]
        public void Core_GetLongestDruckauftrag_zwei_Aufträge_same_duration()
        {
            var mock = new Mock<IRepository>();

            mock.Setup(x => x.Query<Druckauftrag>()).Returns(() =>
            {
                var res = new List<Druckauftrag>();
                res.Add(new Druckauftrag()
                {
                    Material = "Schaum",
                    Start = new DateTime(2000, 1, 1),
                    Ende = new DateTime(2000, 1, 2),
                    Status = Druckstatus.Fertig
                });

                res.Add(new Druckauftrag()
                {
                    Material = "Gummi",
                    Start = new DateTime(2000, 1, 6),
                    Ende = new DateTime(2000, 1, 7),
                    Status = Druckstatus.Fertig
                });

                return res.AsQueryable();
            });

            var core = new Core(mock.Object);

            var result = core.GetLongestDruckauftrag();

            Assert.AreEqual("Gummi", result.Material);
        }
    }
}
