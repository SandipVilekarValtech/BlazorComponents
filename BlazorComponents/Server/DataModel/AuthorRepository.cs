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
        public async Task<IEnumerable<Author>> GetAll(int skip = 0, int take = 5)
        {
            var result = await _dbContext.Authors.Skip(skip).Take(take).ToListAsync();
            return result;
        }


        //public async Task<AuthorDataResult> GetAll(int skip = 0, int take = 5)
        //{
        //    AuthorDataResult authorDataResult = new AuthorDataResult()
        //    {
        //        Authors = _dbContext.Authors.Skip(skip).Take(take).ToList(),
        //        Count = await _dbContext.Authors.CountAsync()
        //    };

        //    return authorDataResult;
        //}
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
