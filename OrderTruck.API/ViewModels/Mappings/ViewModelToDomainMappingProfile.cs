using AutoMapper;
using OrderTruck.Model;
using System.Collections.Generic;

namespace OrderTruck.API.ViewModels.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        //protected override void Configure()
        //{
        //    Mapper.CreateMap<ScheduleViewModel, Schedule>()
        //       .ForMember(s => s.Creator, map => map.UseValue(null))
        //       .ForMember(s => s.Attendees, map => map.UseValue(new List<Attendee>()));

        //    Mapper.CreateMap<UserViewModel, User>();
        //}
    }
}
