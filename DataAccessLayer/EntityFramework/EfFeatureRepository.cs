using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfFeatureRepository : GenericRepository<Feature>, IFeatureDal
	{
		public EfFeatureRepository(SignalRContext context) : base(context)
		{
		}
	}
}
