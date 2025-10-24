using ClickerProject.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ClickerProject.UseCases.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Unit>
    {
        private readonly UserManager<ApplicationUser> _userManager;


        public RegisterUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                UserName = request.Username
            };

            await _userManager.CreateAsync(user, request.Password);

            return Unit.Value;
        }
    }
}
