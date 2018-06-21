using System;
using System.Collections.Generic;

namespace OrderTruck.Model.Entities
{
    public partial class User : IEntityBase
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public int Status { get; set; }
        public byte[] Avatar { get; set; }
    }
}
