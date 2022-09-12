using Business.Concrate;
using Core.Utilities.Results;
using DataAccessLayer.Concrate;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBusiness
{
    [TestClass]
    public class TestCenePoDanu
    {
        [TestMethod]

        public void Test1()
        {
            CenaIznjmljivanjaPoDanu cena = new CenaIznjmljivanjaPoDanu
            {
                Cena = 200,
                Datum = "21",
                IdModelAutomobila = 2
            };
           

            CenaIznajmljivanjaPoDanuMenager service = new CenaIznajmljivanjaPoDanuMenager(new EfCenaIznajmljivanjaPoDanuDal());

            var rezultat = service.Add(cena);

            Assert.IsTrue(rezultat.Success);

        }

        [TestMethod]

        public void Test2()
        {
            CenaIznajmljivanjaPoDanuMenager service = new CenaIznajmljivanjaPoDanuMenager(new EfCenaIznajmljivanjaPoDanuDal());

            CenaIznjmljivanjaPoDanu cena = service.GetAll().Data.Find(x => x.Cena == 200 && x.Datum=="21")!;
            cena.Cena = 210;
            cena.Datum = "19";

            var result = service.Update(cena);
            Assert.IsTrue(result.Success);


        }

        [TestMethod]

        public void Test3()
        {
            CenaIznajmljivanjaPoDanuMenager service = new CenaIznajmljivanjaPoDanuMenager(new EfCenaIznajmljivanjaPoDanuDal());

            var cena = service.GetAll().Data.Find(x => x.Cena == 210 && x.Datum == "19");

            var rezultat = service.Delete(cena!);

            Assert.IsTrue(rezultat.Success);

        }
    }
}
