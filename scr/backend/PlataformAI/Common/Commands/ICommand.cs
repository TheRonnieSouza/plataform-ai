using Common.Models;
using MediatR;

namespace Common.Commands
{
    public interface ICommand : IRequest<EventStream>
    {

    }
}
