using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderTruck.Model;
using OrderTruck.Model.Entities;

namespace OrderTruck.Data.Abstract
{
    public interface IScheduleRepository : IEntityBaseRepository<Schedule> { }

    public interface IUserRepository : IEntityBaseRepository<User> { }

}
