using BlazorComponents.Shared;
using Microsoft.EntityFrameworkCore;
using Radzen;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace BlazorComponents.Server.DataModel
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ShopOnlineContext _dbContext;

        public AuthorRepository(ShopOnlineContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AuthorDataResult> GetAll(int skip = 0, int take = 5)
        {
            AuthorDataResult authorDataResult = new AuthorDataResult()
            {
                Authors = _dbContext.Authors.Skip(skip).Take(take).ToList(),
                Count = await _dbContext.Authors.CountAsync()
            };

            return authorDataResult;
        }
        public async Task<AuthorDataResult> Search(string filter, int skip = 0, int take = 5)
        {
            var filteredAuthors = _dbContext.Authors.Where(x =>
            (x.FirstName.ToLower().Contains(filter.ToLower())) ||
            (x.LastName.ToLower().Contains(filter.ToLower())) ||
            (x.Email.ToLower().Contains(filter.ToLower())));

            AuthorDataResult authorDataResult = new AuthorDataResult()
            {
                Authors = filteredAuthors.Skip(skip).Take(take).ToList(),
                Count = filteredAuthors.Count()
            };

            return authorDataResult;
        }
        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _dbContext.Authors.ToListAsync();
        }
        public async Task<Author> GetAuthor(int id)
        {
            return await _dbContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Author> GetAuthorByEmail(string email)
        {
            return await _dbContext.Authors.FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task<IEnumerable<Author>> Search(string firstName)
        {
            IQueryable<Author> query = _dbContext.Authors;

            if (!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(a => a.FirstName.Contains(firstName));
            }

            return await query.ToListAsync();
        }
    }
}
