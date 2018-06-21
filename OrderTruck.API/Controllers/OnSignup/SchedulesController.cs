using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OrderTruck.Data.Abstract;
using OrderTruck.Model.Entities;
using OrderTruck.API.ViewModels;
using AutoMapper;
using OrderTruck.API.Core;
using OrderTruck.Facade.ScheduleServiceGroup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace OrderTruck.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Member")]
    [Route("api/[controller]")]
    public class SchedulesController : Controller
    {
        private IScheduleRepository _scheduleRepository;
        private IUserRepository _userRepository;
        int page = 1;
        int pageSize = 4;
        public SchedulesController(IScheduleRepository scheduleRepository,
                                    IUserRepository userRepository)
        {
            _scheduleRepository = scheduleRepository;
            _userRepository = userRepository;
        }

        public IActionResult Get()
        {
            var pagination = Request.Headers["Pagination"];

            if (!string.IsNullOrEmpty(pagination))
            {
                string[] vals = pagination.ToString().Split(',');
                int.TryParse(vals[0], out page);
                int.TryParse(vals[1], out pageSize);
            }

            var servie = new ScheduleService(_scheduleRepository);
            int currentPage = page;
            int currentPageSize = pageSize;
            var totalSchedules = servie.GetTotalSchedules();
            var totalPages = (int)Math.Ceiling((double)totalSchedules / pageSize);

            IEnumerable<Schedule> _schedules = servie.GetSchedules(currentPageSize, currentPage);

            Response.AddPagination(page, pageSize, totalSchedules, totalPages);

            IEnumerable<ScheduleViewModel> _schedulesVM = Mapper.Map<IEnumerable<Schedule>, IEnumerable<ScheduleViewModel>>(_schedules);

            return new OkObjectResult(_schedulesVM);
        }

        //[HttpGet("{id}", Name = "GetSchedule")]
        //public IActionResult Get(int id)
        //{
        //    Schedule _schedule = _scheduleRepository
        //        .GetSingle(s => s.Id == id, s => s.Description);

        //    if (_schedule != null)
        //    {
        //        ScheduleViewModel _scheduleVM = Mapper.Map<Schedule, ScheduleViewModel>(_schedule);
        //        return new OkObjectResult(_scheduleVM);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}


        //[HttpPost]
        //public IActionResult Create([FromBody]ScheduleViewModel schedule)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Schedule _newSchedule = Mapper.Map<ScheduleViewModel, Schedule>(schedule);
        //    _newSchedule.StartDate = DateTime.Now;

        //    _scheduleRepository.Add(_newSchedule);
        //    _scheduleRepository.Commit();

        //    _scheduleRepository.Commit();

        //    schedule = Mapper.Map<Schedule, ScheduleViewModel>(_newSchedule);

        //    CreatedAtRouteResult result = CreatedAtRoute("GetSchedule", new { controller = "Schedules", id = schedule.id }, schedule);
        //    return result;
        //}

        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody]ScheduleViewModel schedule)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    Schedule _scheduleDb = _scheduleRepository.GetSingle(id);

        //    if (_scheduleDb == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        _scheduleDb.Description = schedule.description;

        //        _scheduleRepository.Commit();
        //    }

        //    schedule = Mapper.Map<Schedule, ScheduleViewModel>(_scheduleDb);

        //    return new NoContentResult();
        //}

        //[HttpDelete("{id}", Name = "RemoveSchedule")]
        //public IActionResult Delete(int id)
        //{
        //    Schedule _scheduleDb = _scheduleRepository.GetSingle(id);

        //    if (_scheduleDb == null)
        //    {
        //        return new NotFoundResult();
        //    }
        //    else
        //    {
        //        _scheduleRepository.Delete(_scheduleDb);

        //        _scheduleRepository.Commit();

        //        return new NoContentResult();
        //    }
        //}
    }
}
