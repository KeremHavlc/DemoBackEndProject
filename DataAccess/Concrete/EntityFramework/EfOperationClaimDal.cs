using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOperationClaimDal : IOperationClaimDal
    {
        public void Add(OperationClaim operationClaim)
        {
            using (var context = new SimpleContextDb())
            {
                context.Add(operationClaim);
                context.SaveChanges();
            }
        }

        public void Delete(OperationClaim operationClaim)
        {
            using (var context = new SimpleContextDb())
            {
                context.Remove(operationClaim);
                context.SaveChanges();
            }
        }

        public OperationClaim Get(int id)
        {
            using (var context = new SimpleContextDb())
            {
                return context.OperationClaims.Where(p => p.Id == id).FirstOrDefault();
            }   
        }

        public List<OperationClaim> GetAll()
        {
            using (var context = new SimpleContextDb())
            {
                return context.OperationClaims.ToList();
            }
        }

        public void Update(OperationClaim operationClaim)
        {
            using (var context = new SimpleContextDb())
            {
                context.Update(operationClaim);
                context.SaveChanges();
            }
        }
    }
}
