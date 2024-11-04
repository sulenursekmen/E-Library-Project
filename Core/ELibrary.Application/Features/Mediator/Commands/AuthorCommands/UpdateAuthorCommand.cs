using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Application.Features.Mediator.Commands.AuthorCommands
{
    public class UpdateAuthorCommand:IRequest
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
    }
}
