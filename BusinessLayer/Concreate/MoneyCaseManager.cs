using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class MoneyCaseManager : IMoneyCaseService
    {
        private readonly IMoneyCaseDal moneyCaseDal;

        public MoneyCaseManager(IMoneyCaseDal moneyCaseDal)
        {
            this.moneyCaseDal = moneyCaseDal;
        }

        public void TAdd(MoneyCase entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(MoneyCase entity)
        {
            throw new NotImplementedException();
        }

        public MoneyCase TGetByID(int id)
        {
            return moneyCaseDal.GetByID(id);
        }

        public List<MoneyCase> TGetListAll()
        {
          return moneyCaseDal.GetListAll();
        }

        public decimal TTotalMoneyCaseAmount()
        {
            return moneyCaseDal.TotalMoneyCaseAmount();
        }

        public void TUpdate(MoneyCase entity)
        {
            moneyCaseDal.Update(entity);
        }
    }
}
