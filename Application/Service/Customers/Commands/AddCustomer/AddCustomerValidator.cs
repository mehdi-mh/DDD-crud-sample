using Application.Service.Customers.Dto;
using FluentValidation;
using PhoneNumbers;

namespace Application.Service.Customers.Commands.AddCustomer
{
    internal class AddCustomerValidator : AbstractValidator<RequestAddCustomerDto>
    {
        public AddCustomerValidator(RequestAddCustomerDto requestAddCustomerDto)
        {

            RuleFor(x => x.Email).NotNull().EmailAddress();
            RuleFor(x => x.Firstname).NotNull().NotEmpty();
            RuleFor(x => x.Lastname).NotNull().NotEmpty();
            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty();
            RuleFor(x => x.BankAccountNumber).NotNull().NotEmpty();
            RuleFor(x => x.DateOfBirth).NotNull().NotEmpty();
            RuleFor(x => x.PhoneNumber).Custom((phoneNumber, context) =>
            {
                var phoneNumberUtil = PhoneNumberUtil.GetInstance();
                if (phoneNumber == null)
                    context.AddFailure("Invalid phone number");
                else
                {
                    var googlePhoneNumber = phoneNumberUtil.Parse(phoneNumber, "US");
                    if (!phoneNumberUtil.IsValidNumber(googlePhoneNumber))
                    {
                        context.AddFailure("Invalid phone number");
                    }
                }
            });
        }
    }
}

