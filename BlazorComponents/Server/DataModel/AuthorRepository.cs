using BlazorComponents.Shared;
using Microsoft.EntityFrameworkCore;
using Radzen;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;

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

        public async Task<AuthorDataResult> GridSearch(string filterText, DateTime? filterDate, string filter, string orderBy, int skip = 0, int take = 5)
        {
            var items = _dbContext.Authors.AsQueryable();

            StringBuilder query = new StringBuilder();

            if (filterText != "f")
            {
                query.Append(" (FirstName == null ? \"\" : FirstName.ToLower()).Contains(\"");
                query.Append(filterText);
                query.Append("\")");

                query.Append(" OR (LastName == null ? \"\" : LastName.ToLower()).Contains(\"");
                query.Append(filterText.ToLower());
                query.Append("\")");

                query.Append(" OR (Email == null ? \"\" : Email.ToLower()).Contains(\"");
                query.Append(filterText.ToLower());
                query.Append("\")");

                query.Append(" OR Birthdate = DateTime(\"");
                query.Append(filterDate.Value.ToString("yyyy/MM/dd"));
                query.Append("\")");
            }

            if (filter != "f")
            {
                query.Append(query.Length > 0 ? " OR (" + filter + " )" : filter);
            }

            items = items.Where(query.ToString());

            /*if (!(filterText == "f"))
            {
                items = items.Where(x =>
                                    (x.FirstName.ToLower().Contains(filterText.ToLower())) ||
                                    (x.LastName.ToLower().Contains(filterText.ToLower())) ||
                                    (x.Email.ToLower().Contains(filterText.ToLower())) ||
                                    (x.Birthdate == filterDate));
            }*/

            if (!string.IsNullOrEmpty(orderBy))
            {
                items = items.OrderBy(orderBy);
            }

            var count = items.Count();
            items = items.Skip(skip).Take(take);

            AuthorDataResult authorDataResult = new AuthorDataResult()
            {
                Authors = items.ToList(),
                Count = count
            };

            return authorDataResult;
        }
        public async Task<AuthorDataResult> Search(string filter, DateTime? filterDate, int skip = 0, int take = 5)
        {
            var filteredAuthors = _dbContext.Authors.Where(x =>
            (x.FirstName.ToLower().Contains(filter.ToLower())) ||
            (x.LastName.ToLower().Contains(filter.ToLower())) ||
            (x.Email.ToLower().Contains(filter.ToLower())) ||
            (x.Birthdate == filterDate));

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
    }
}
