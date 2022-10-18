using BlazorComponents.Server.DataModel;
using BlazorComponents.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorComponents.Server.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly ShopOnlineContext _context;

        public AuthorService(ShopOnlineContext context)
        {
            _context = context;
        }
        //public async Task<List<Author>> GetAuthor(int skip = 0, int take = 5)
        public async Task<AuthorDataResult> GetAuthor(int skip = 0, int take = 5)
        {
            AuthorDataResult result = new AuthorDataResult()
            {
                Authors = _context.Authors.Skip(skip).Take(take).ToListAsync(),
                Count = _context.Authors.Count()
            };
            return result;
        }
    }
}
