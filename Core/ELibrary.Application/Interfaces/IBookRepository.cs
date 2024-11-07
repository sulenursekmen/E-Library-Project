using ELibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Application.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllBookWithCategoryAndAuthorAsync();
        Task<List<Book>> GetBooksByPublishedDateAsync(DateTime startDate, DateTime endDate);
    }
}
