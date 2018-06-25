using FluentValidation;
using System;

namespace OrderTruck.BackendAndApi.ViewModels.Validations
{
    public class ScheduleViewModelValidator : AbstractValidator<ScheduleViewModel>
    {
        public ScheduleViewModelValidator()
        {
            RuleFor(s => s.end_date).Must((start, end) =>
            {
                return DateTimeIsGreater(start.start_date, end);
            }).WithMessage("Schedule's End time must be greater than Start time");
        }

        private bool DateTimeIsGreater(DateTime start, DateTime end)
        {
            return end > start;
        }
    }
}
