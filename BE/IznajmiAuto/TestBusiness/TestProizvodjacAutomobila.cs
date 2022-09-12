using Business.Concrate;
using Business.Constants;
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
    public class TestProizvodjacAutomobila
    {
        [TestMethod]

        public void Test1()
        {
            Proizvodjac proizvodjac = new Proizvodjac
            {
                Naziv = "Proizvodjac",
                Drzava = "Drzava"
            };
            var ocekivani = new SuccessResult(Messages.ProizvodjacAdded);

            ProizvodjacAutomobilaManager service = new ProizvodjacAutomobilaManager(new EfProizvodjacDal(), new EfModelAutomobilaDal());

            var rezultat = service.Add(proizvodjac);

            Assert.IsTrue(rezultat.Success);

        }

        [TestMethod]

        public void Test2()
        {
            ProizvodjacAutomobilaManager service = new ProizvodjacAutomobilaManager(new EfProizvodjacDal(), new EfModelAutomobilaDal());

            Proizvodjac proizvodjac = service.GetAll().Data.Find(x => x.Naziv == "Proizvodjac")!;
            proizvodjac.Naziv = "proizvodjac";
            proizvodjac.Drzava = "drzava";

            var result = service.Update(proizvodjac);
            Assert.IsTrue(result.Success);


        }

        [TestMethod]

        public void Test3()
        {
            ProizvodjacAutomobilaManager service = new ProizvodjacAutomobilaManager(new EfProizvodjacDal(), new EfModelAutomobilaDal());

            var proizvodjac = service.GetAll().Data.Find(x => x.Naziv == "proizvodjac" && x.Drzava == "drzava");

            var rezultat = service.Delete(proizvodjac!);

            Assert.IsTrue(rezultat.Success);

        }
    }
}
