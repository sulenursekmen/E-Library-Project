using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Application.Features.Mediator.Commands.UserBookCommands
{
    public class RemoveUserBookCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveUserBookCommand(int id)
        {
            Id = id;
        }
    }
}
