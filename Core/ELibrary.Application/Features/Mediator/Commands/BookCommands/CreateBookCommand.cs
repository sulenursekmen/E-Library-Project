using MediatR;

namespace ELibrary.Application.Features.Mediator.Commands.BookCommands
{
    public class CreateBookCommand:IRequest
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public int CategoryId { get; set; }
        public string PublisherName { get; set; }
    }
}
