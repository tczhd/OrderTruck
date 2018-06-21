using System;
using System.Collections.Generic;

namespace OrderTruck.Model.Entities
{
    public partial class UserSetting : IEntityBase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Setting { get; set; }
        public string Value { get; set; }
    }
}
