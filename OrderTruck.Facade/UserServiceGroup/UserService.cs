using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OrderTruck.Data.Abstract;
using OrderTruck.Model;
using OrderTruck.Model.Entities;


namespace OrderTruck.Facade.UserServiceGroup
{
    public class UserService : BaseService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(string userName, string firstName,string lastName, string middleName, string password, string phone, int status)
        {
            var user = new User{
                Username = userName,
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                Password =password,
                Phone = phone,
                Status = status
            };

            _userRepository.Add(user);
            _userRepository.Commit();
        }

        public int GetTotalusers()
        {
            return _userRepository.Count();
        }

        public IEnumerable<User> GetUsers(int currentPage, int currentPageSize)
        {
            return _userRepository
                .AllIncluding(s => s.FirstName, t => t.LastName)
                .OrderBy(s => s.Id)
                .Skip((currentPage - 1) * currentPageSize)
                .Take(currentPageSize)
                .ToList();
        }
    }
}
