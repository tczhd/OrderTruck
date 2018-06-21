using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderTruck.Model;
using OrderTruck.Model.Entities;
using OrderTruck.Data;
using OrderTruck.Data.Repositories;
using OrderTruck.Data.Abstract;

namespace OrderTruck.Data.Repositories
{
    public class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context)
            : base(context)
        { }
    }
}
