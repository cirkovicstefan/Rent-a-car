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
    public class TestModelAutomobila
    {
        [TestMethod]

        public void Test1()
        {
            ModelAutomobila modelAutomobila = new ModelAutomobila
            {
                IdProizvodjacAutomobila = 1,
                Naziv = "model1",
                Gorivo = "Benzin",
                Kubikaza = "2.3",
                BrojSedista = 2,
                Menjac = "manuel"
            };
            var ocekivani = new SuccessResult(Messages.ModelAutomobilaAdded);

            ModelAutomobilaManager service = new ModelAutomobilaManager(new EfModelAutomobilaDal(), new EfAutomobilDal());

            var rezultat = service.Add(modelAutomobila);

            Assert.IsTrue(rezultat.Success);

        }

        [TestMethod]

        public void Test2()
        {
            ModelAutomobilaManager service = new ModelAutomobilaManager(new EfModelAutomobilaDal(), new EfAutomobilDal());

            ModelAutomobila model = service.GetAll().Data.Find(x => x.Naziv == "model1")!;
            model.Gorivo = "dizel";
            model.BrojSedista = 8;
            model.Kubikaza = "1";
            model.Menjac = "automatski";

            var result = service.Update(model);
            Assert.IsTrue(result.Success);


        }

        [TestMethod]

        public void Test3()
        {
            ModelAutomobilaManager service = new ModelAutomobilaManager(new EfModelAutomobilaDal(), new EfAutomobilDal());

            var model = service.GetAll().Data.Find(x => x.Naziv == "model1" && x.Gorivo=="dizel"
            && x.BrojSedista==8 && x.Kubikaza=="1" && x.Menjac == "automatski");

            var rezultat = service.Delete(model!);

            Assert.IsTrue(rezultat.Success);

        }

    }
}
