using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        //readonly ifadeler yalnızda ctor'da ya da tanımlandığı yerde set edilebilir.
        //ctor da yapmasaydık karşılığı null olacaktı.  
        private readonly IOperationClaimDal _operationClaimDal;
        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }
        public void Add(OperationClaim operationClaim)
        {
            //Kontrol kodları yazılacak
            //Data Access'e git ve Kayıt işlemi yapması gerektiğini söyle !
            _operationClaimDal.Add(operationClaim);
        }
    }
}
