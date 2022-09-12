using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAutomobilService
    {
        IResult Add(Automobil automobil);
        IResult Delete(Automobil automobil);
        IResult Update(Automobil automobil);
        IDataResult<List<Automobil>> GetAll();
        IDataResult<Automobil> GetById(int autoId);
        IDataResult<List<AutomobilDetailDto>> GetAutomobiliCenaBetween(decimal cena1, decimal cena2);
        IDataResult<List<AutomobilDetailDto>> GetAutomobilDetails(int autoId);
        IDataResult<List<AutomobilDetailDto>> GetAutomobilDetailsByModel(int modelId);
        IDataResult<List<AutomobilDetailDto>> GetAutomobilDetailsByProizvodjac(int proizvodjacId);
        IDataResult<List<AutomobilDetailDto>> GetAutomobilDetailsByFilter(int modelId, int proizvodjacId);
    }
}
