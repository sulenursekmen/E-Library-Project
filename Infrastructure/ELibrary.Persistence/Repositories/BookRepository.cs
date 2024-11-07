using ELibrary.Application.Interfaces;
using ELibrary.Domain.Entities;
using ELibrary.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Persistence.Repositories
{
    public class BookRepository:IBookRepository
    {
        private readonly ELibraryContext _context;

        public BookRepository(ELibraryContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllBookWithCategoryAndAuthorAsync()
        {
             return await _context.Books
            .Include(b => b.Author) 
            .Include(b => b.Category) 
            .ToListAsync();
        }

        public async Task<List<Book>> GetBooksByPublishedDateAsync(DateTime startDate, DateTime endDate)
        {
            startDate = DateTime.SpecifyKind(startDate, DateTimeKind.Utc);
            endDate = DateTime.SpecifyKind(endDate, DateTimeKind.Utc);

            return await _context.Books
                .Where(b => b.PublishedDate >= startDate && b.PublishedDate <= endDate)
                .ToListAsync();
        }

    }
}
