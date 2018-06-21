using OrderTruck.Data.Abstract;
using OrderTruck.Model;
using OrderTruck.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderTruck.Data.Repositories
{
    public class ScheduleRepository : EntityBaseRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(ApplicationDbContext context)
            : base(context)
        { }
    }
}
