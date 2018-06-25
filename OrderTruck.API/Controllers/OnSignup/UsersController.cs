using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OrderTruck.Data.Abstract;
using OrderTruck.Model;
using OrderTruck.Model.Entities;
using OrderTruck.BackendAndApi.ViewModels;
using AutoMapper;
using OrderTruck.BackendAndApi.Core;
using OrderTruck.Facade.UserServiceGroup;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace OrderTruck.BackendAndApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Member")]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IUserRepository _userRepository;

        int page = 1;
        int pageSize = 10;
        public UsersController(IUserRepository userRepository)
        {
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

            var service = new UserService(_userRepository);
            int currentPage = page;
            int currentPageSize = pageSize;
            var totalUsers = service.GetTotalusers();
            var totalPages = (int)Math.Ceiling((double)totalUsers / pageSize);

            IEnumerable<User> _users = service.GetUsers(currentPage, currentPageSize);

            IEnumerable<UserViewModel> _usersVM = Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(_users);

            Response.AddPagination(page, pageSize, totalUsers, totalPages);

            return new OkObjectResult(_usersVM);
        }

        //[HttpGet("{id}", Name = "GetUser")]
        //public IActionResult Get(int id)
        //{
        //    User _user = _userRepository.GetSingle(u => u.Id == id);

        //    if (_user != null)
        //    {
        //        UserViewModel _userVM = Mapper.Map<User, UserViewModel>(_user);
        //        return new OkObjectResult(_userVM);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        //[HttpGet("{id}/schedules", Name = "GetUserSchedules")]
        //public IActionResult GetSchedules(int id)
        //{
        //    IEnumerable<Schedule> _userSchedules = _scheduleRepository.FindBy(s => s.Id == id);

        //    if (_userSchedules != null)
        //    {
        //        IEnumerable<ScheduleViewModel> _userSchedulesVM = Mapper.Map<IEnumerable<Schedule>, IEnumerable<ScheduleViewModel>>(_userSchedules);
        //        return new OkObjectResult(_userSchedulesVM);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        [HttpPost]
        public IActionResult Create([FromBody]UserViewModel user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User _newUser = new User { FirstName = user.first_name };

            var service = new UserService(_userRepository);
            service.AddUser(user.user_name, user.first_name,
                user.last_name, user.middle_name, user.password, user.phone, user.Status);

            //user = Mapper.Map<User, UserViewModel>(_newUser);

            //CreatedAtRouteResult result = CreatedAtRoute("GetUser", new { controller = "Users", id = user.id }, user);
            return Ok(Json("Success"));
        }

        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody]UserViewModel user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    User _userDb = _userRepository.GetSingle(id);

        //    if (_userDb == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        _userDb.FirstName= user.first_Name;

        //        _userRepository.Commit();
        //    }

        //    user = Mapper.Map<User, UserViewModel>(_userDb);

        //    return new NoContentResult();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    User _userDb = _userRepository.GetSingle(id);

        //    if (_userDb == null)
        //    {
        //        return new NotFoundResult();
        //    }
        //    else
        //    {
        //        IEnumerable<Schedule> _schedules = _scheduleRepository.FindBy(s => s.Id == id);

        //        foreach (var schedule in _schedules)
        //        {
        //            _scheduleRepository.Delete(schedule);
        //        }

        //        _userRepository.Delete(_userDb);

        //        _userRepository.Commit();

        //        return new NoContentResult();
        //    }
        //}

    }

}
