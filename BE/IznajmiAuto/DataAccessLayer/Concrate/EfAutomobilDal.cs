using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrate
{
    public class EfAutomobilDal : EfEntityRepositoryBase<Automobil, DataBasaContext>, IAutomobilDal
    {
        public List<AutomobilDetailDto> GetAutomobilDetails(Expression<Func<Automobil, bool>>? filter = null)
        {
            using (DataBasaContext db = new DataBasaContext())
            {
                DateTime dateTime = DateTime.Now;
                int count = 0;
                int IdModelAutomobila = 0;
                List<CenaIznjmljivanjaPoDanu> list = db.CenaIznajmljivanjaPoDanu!.ToList();
                List<CenaIznjmljivanjaPoDanu> listTemp = new List<CenaIznjmljivanjaPoDanu>();
                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        if (list[i].IdModelAutomobila == list[j].IdModelAutomobila)
                        {
                            count++;
                            IdModelAutomobila = list[i].IdModelAutomobila;
                            break;
                        }
                    }
                }

                if (count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].IdModelAutomobila == IdModelAutomobila)
                        {
                            listTemp.Add(list[i]);
                        }
                    }

                    long Max = long.MinValue;
                    for (int i = 0; i < listTemp.Count; i++)
                    {
                        var datum = DateTime.Parse(listTemp[i].Datum!);
                        var time = datum.Ticks;
                        if (time > Max)
                        {
                            Max = time;
                        }
                    }
                    dateTime = new DateTime(Max);

                    List<CenaIznjmljivanjaPoDanu> novaLista = new List<CenaIznjmljivanjaPoDanu>();
                    foreach(var item in listTemp)
                    {
                        var datum = DateTime.Parse(item.Datum!);
                        if (datum!.Equals(dateTime))
                        {
                            novaLista.Add(item);
                        }
                    }
                    var x = list.Except(listTemp).ToList();
                    foreach(var item in x)
                    {
                        novaLista.Add(item);
                    }




                    var result1 = from c in filter == null ? db.Automobil : db.Automobil!.Where(filter)
                                  join b in db.ModelAutomobila! on c.IdModelAutomobila equals b.IdModelAutomobila
                                  join d in db.ProizvodjacAutomobila! on b.IdProizvodjacAutomobila equals d.IdProizvodjacAutomobila


                                  select new AutomobilDetailDto
                                  {
                                      IdAutomobil = c.IdAutomobil,
                                      IdModelAutomobila = c.IdModelAutomobila,
                                      NazivProizvodjaca = d.Naziv,
                                      NazivModela = b.Naziv,
                                      BrojRegistracije = c.BrojRegistracije,
                                      Boja = c.Boja,
                                      Dostupan = c.Dostupan,
                                      Rezervisan = c.Rezervisan,
                                      Godiste = c.Godiste,
                                      Cena = 0,
                                      Gorivo=b.Gorivo,
                                      Kubikaza = b.Kubikaza,
                                      BrojSedista = b.BrojSedista,
                                      Menjac=b.Menjac,
                                      SlikaPutanje = (from img in db.SlikeAutomobila
                                                      where img.IdAutomobila == c.IdAutomobil
                                                      select new SlikaAutomobila
                                                      {
                                                          IdSlike = img.IdSlike,
                                                          IdAutomobila = img.IdAutomobila,
                                                          PutanjaSlike = img.PutanjaSlike,
                                                          Datum = img.Datum
                                                      }).ToList()
                                  };
                    var da= result1.ToList();
                    var res = from b in da
                              join m in novaLista
                              on b.IdModelAutomobila equals m.IdModelAutomobila
                              select new AutomobilDetailDto
                              {
                                  IdAutomobil = b.IdAutomobil,
                                  IdModelAutomobila = b.IdModelAutomobila,
                                  NazivProizvodjaca = b.NazivProizvodjaca,
                                  NazivModela = b.NazivModela,
                                  BrojRegistracije = b.BrojRegistracije,
                                  Boja = b.Boja,
                                  Dostupan = b.Dostupan,
                                  Rezervisan = b.Rezervisan,
                                  Godiste = b.Godiste,
                                  Cena = m.Cena,
                                  Gorivo=b.Gorivo,
                                  Kubikaza=b.Kubikaza,
                                  BrojSedista=b.BrojSedista,
                                  Menjac = b.Menjac,
                                  SlikaPutanje = b.SlikaPutanje

                              };
                    return res.ToList();


                }


                var result = from c in filter == null ? db.Automobil : db.Automobil!.Where(filter)
                             join b in db.ModelAutomobila! on c.IdModelAutomobila equals b.IdModelAutomobila
                             join d in db.ProizvodjacAutomobila! on b.IdProizvodjacAutomobila equals d.IdProizvodjacAutomobila
                             join cena in db.CenaIznajmljivanjaPoDanu! on b.IdModelAutomobila equals cena.IdModelAutomobila

                             select new AutomobilDetailDto
                             {
                                 IdAutomobil = c.IdAutomobil,
                                 IdModelAutomobila = c.IdModelAutomobila,
                                 NazivProizvodjaca = d.Naziv,
                                 NazivModela = b.Naziv,
                                 BrojRegistracije = c.BrojRegistracije,
                                 Boja = c.Boja,
                                 Dostupan = c.Dostupan,
                                 Rezervisan = c.Rezervisan,
                                 Godiste = c.Godiste,
                                 Cena = cena.Cena,
                                 Gorivo = b.Gorivo,
                                 Kubikaza = b.Kubikaza,
                                 BrojSedista = b.BrojSedista,
                                 Menjac = b.Menjac,
                                 SlikaPutanje = (from img in db.SlikeAutomobila
                                                 where img.IdAutomobila == c.IdAutomobil
                                                 select new SlikaAutomobila
                                                 {
                                                     IdSlike = img.IdSlike,
                                                     IdAutomobila = img.IdAutomobila,
                                                     PutanjaSlike = img.PutanjaSlike,
                                                     Datum = img.Datum
                                                 }).ToList()
                             };
                return result.ToList();





            }
        }
    }
}
