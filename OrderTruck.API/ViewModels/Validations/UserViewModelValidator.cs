using FluentValidation;

namespace OrderTruck.BackendAndApi.ViewModels.Validations
{
    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
            RuleFor(user => user.first_name).NotEmpty().WithMessage("First Name cannot be empty");
            RuleFor(user => user.last_name).NotEmpty().WithMessage("Last Name cannot be empty");
        }
    }
}
