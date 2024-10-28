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
    public class MenuTableManager : IMenuTableService
    {
       private readonly IMenuTableDal menuTableDal;

        public MenuTableManager(IMenuTableDal menuTableDal)
        {
            this.menuTableDal = menuTableDal;
        }

        public void TAdd(MenuTable entity)
        {
            menuTableDal.Add(entity);
        }

		public void TChangeMenuTableStatusToFalse(int id)
		{
            menuTableDal.ChangeMenuTableStatusToFalse(id);
		}

		public void TChangeMenuTableStatusToTrue(int id)
		{
            menuTableDal.ChangeMenuTableStatusToTrue(id);
		}

		public void TDelete(MenuTable entity)
        {
            menuTableDal.Delete(entity);
        }

        public MenuTable TGetByID(int id)
        {
            return menuTableDal.GetByID(id);
        }

        public List<MenuTable> TGetListAll()
        {
            return menuTableDal.GetListAll();
        }

        public int TMenuTableCount()
        {
            return menuTableDal.MenuTableCount();
        }

        public void TUpdate(MenuTable entity)
        {
            menuTableDal.Update(entity);
        }
    }
}
