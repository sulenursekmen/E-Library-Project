using ELibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Application.Interfaces
{
    public interface IUserBookRepository
    {
        Task<List<UserBook>> GetUserBooksByUserIdAsync(int userId);
    }
}
