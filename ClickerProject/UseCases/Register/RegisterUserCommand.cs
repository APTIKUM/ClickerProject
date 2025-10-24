using MediatR;

namespace ClickerProject.UseCases.Register
{
    public record RegisterUserCommand(string Username, string Password) : IRequest<Unit>;
}
