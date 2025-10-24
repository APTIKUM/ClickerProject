using MediatR;

namespace ClickerProject.UseCases.Login
{
    public record LoginUserCommand(string Username, string password) : IRequest<Unit>;
}
