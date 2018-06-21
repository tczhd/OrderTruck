using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OrderTruck.Data.Abstract;
using OrderTruck.Model;
using OrderTruck.Model.Entities;

namespace OrderTruck.Facade.ScheduleServiceGroup
{
    public class ScheduleService : BaseService
    {
        private IScheduleRepository _scheduleRepository;
        //private IUserRepository _userRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public int GetTotalSchedules()
        {
            return _scheduleRepository.Count();
        }

        public IEnumerable<Schedule> GetSchedules(int currentPage, int currentPageSize)
        {
            return _scheduleRepository
                .AllIncluding(s => s.Description)
                .OrderBy(s => s.Id)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();
        }
    }
}
