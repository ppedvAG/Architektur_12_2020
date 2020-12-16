using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.Druckverwaltung.Model;
using System;

namespace ppedv.Druckverwaltung.Data.EF.Tests
{
    [TestClass]
    public class EfContextTests
    {
        [TestMethod]
        public void EfContext_can_create_DB()
        {
            var con = new EfContext();
            if (con.Database.Exists())
                con.Database.Delete();

            con.Database.Create();

            Assert.IsTrue(con.Database.Exists());
        }

        [TestMethod]
        public void EfContext_can_add_Patient()
        {
            var p = new Patient() { Name = "Fred" };
            var con = new EfContext();

            con.Patienten.Add(p);

            Assert.AreEqual(1, con.SaveChanges());
        }


        [TestMethod]
        public void EfContext_can_CRUD_Patient()
        {
            var p = new Patient() { Name = $"Fred_{Guid.NewGuid()}" };
            var newName = $"Wilma_{Guid.NewGuid()}";
            //CREATE (INSERT)
            using (var con = new EfContext())
            {
                con.Patienten.Add(p);

                Assert.AreEqual(1, con.SaveChanges());
            }

            //READ + UPDATE
            using (var con = new EfContext())
            {
                var loaded = con.Patienten.Find(p.Id);
                Assert.IsNotNull(loaded);
                Assert.AreEqual(p.Name, loaded.Name);

                loaded.Name = newName;
                con.SaveChanges();
            }

            //check UPDATE + DELETE
            using (var con = new EfContext())
            {
                var loaded = con.Patienten.Find(p.Id);
                Assert.AreEqual(newName, loaded.Name);

                con.Patienten.Remove(loaded);
                con.SaveChanges();
            }

            //check DELETE
            using (var con = new EfContext())
            {
                var loaded = con.Patienten.Find(p.Id);
                Assert.IsNull(loaded);
            }
        }

        //todo...
    }
}

