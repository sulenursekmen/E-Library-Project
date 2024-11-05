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
    public class UserBookRepository : IUserBookRepository
    {
        private readonly ELibraryContext _context;

        public UserBookRepository(ELibraryContext context)
        {
            _context = context;
        }

        public async Task<List<UserBook>> GetUserBooksByUserIdAsync(int userId)
        {
            return await _context.UserBooks
            .Where(ub => ub.UserId == userId)
            .Include(ub => ub.Book) // Kitap bilgilerini dahil et
            .Include(ub => ub.Book.Author) // Yazar bilgilerini dahil et
            .Include(ub => ub.Book.Category) // Kategori bilgilerini dahil et
            .ToListAsync();
        }
    }
}
