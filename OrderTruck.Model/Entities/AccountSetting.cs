using System;
using System.Collections.Generic;

namespace OrderTruck.Model.Entities
{
    public partial class AccountSetting : IEntityBase
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Setting { get; set; }
        public string Value { get; set; }
    }
}
