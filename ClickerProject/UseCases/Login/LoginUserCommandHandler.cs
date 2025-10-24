using ClickerProject.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ClickerProject.UseCases.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Unit>
    {

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginUserCommandHandler(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public async Task<Unit> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);

            var result = await _signInManager.PasswordSignInAsync(user, request.password, isPersistent: true, lockoutOnFailure: false);

    
            return Unit.Value;
        }
    }
}
