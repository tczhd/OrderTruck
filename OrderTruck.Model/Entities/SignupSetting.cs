using System;
using System.Collections.Generic;

namespace OrderTruck.Model.Entities
{
    public partial class SignupSetting : IEntityBase
    {
        public int Id { get; set; }
        public int SignupId { get; set; }
        public string Setting { get; set; }
        public string Value { get; set; }
    }
}
