using Business.Abstract;
using Business.Concrate;
using Business.Constants;
using Core.Utilities.Results;
using DataAccessLayer.Concrate;
using Entities.Concrete;

namespace TestBusiness
{
    [TestClass]
    public class TestAutomobili
    {



       [TestMethod]
        
        public void Test1()
        {
            Automobil automobil = new Automobil
            {
                IdModelAutomobila = 2,
                BrojRegistracije = "AAA",
                Boja = "Plava",
                Dostupan = true,
                Rezervisan = false,
                Godiste = 2020

            };
            var ocekivani = new SuccessResult(Messages.AutomobilAdded);

            AutomobilManager service = new AutomobilManager(new EfAutomobilDal());

            var rezultat = service.Add(automobil);

            Assert.IsTrue(rezultat.Success);

        }

        [TestMethod]
        
        public void Test2()
        {
            IAutomobilService service = new AutomobilManager(new EfAutomobilDal());

            Automobil auto = service.GetAll().Data.Find(x => x.BrojRegistracije == "AAA")!;
            auto.Dostupan = false;
            auto.Rezervisan = true;
            auto.Boja = "bela";
            auto.Godiste = 2013;

            var result = service.Update(auto);
            Assert.IsTrue(result.Success);

           
        }

        [TestMethod]
        
        public void Test3()
        {
            IAutomobilService service = new AutomobilManager(new EfAutomobilDal());

            var auto = service.GetAll().Data.Find(x => x.BrojRegistracije == "AAA");

            var rezultat = service.Delete(auto!);

            Assert.IsTrue(rezultat.Success);

        }

       



    }
}