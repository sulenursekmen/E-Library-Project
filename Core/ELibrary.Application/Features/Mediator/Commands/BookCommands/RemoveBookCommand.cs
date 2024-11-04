using MediatR;

namespace ELibrary.Application.Features.Mediator.Commands.BookCommands
{
    public class RemoveBookCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveBookCommand(int id)
        {
            Id = id;
        }
    }
}
