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
    public interface IModelAutomobilaService
    {
        IResult Add(ModelAutomobila modelAutomobila);
        IResult Delete(ModelAutomobila modelAutomobila);
        IResult Update(ModelAutomobila modelAutomobila);
        IDataResult<List<ModelAutomobila>> GetAll();
        IDataResult<ModelAutomobila> GetById(int modelId);
        IDataResult<List<ModelAutomobilaDetailDto>> GetModelAutomobilaDetails();
    }
}
