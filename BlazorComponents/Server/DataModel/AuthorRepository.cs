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
            //var items = _dbContext.Authors.AsQueryable();
            IQueryable<Author> authors = Enumerable.Empty<Author>().AsQueryable();
            var count = 0;
            StringBuilder query = new StringBuilder();

            if (filterText != "f")
            {
                query.Append(" ((FirstName == null ? \"\" : FirstName.ToLower()).Contains(\"");
                query.Append(filterText);
                query.Append("\")");

                query.Append(" OR (LastName == null ? \"\" : LastName.ToLower()).Contains(\"");
                query.Append(filterText.ToLower());
                query.Append("\")");

                query.Append(" OR (Email == null ? \"\" : Email.ToLower()).Contains(\"");
                query.Append(filterText.ToLower());
                query.Append("\"))");
            }

            if (filterDate != null)
            {
                if (query.Length > 0)
                {
                    query.Append(" AND (Birthdate = DateTime(\""); 
                }
                else
                {
                    query.Append(" (Birthdate = DateTime(\"");
                }
                
                query.Append(filterDate.Value.ToString("yyyy/MM/dd"));
                query.Append("\"))");
            }

            if (filter != "f")
            {
                query.Append(query.Length > 0 ? " AND (" + filter + " )" : filter);
            }

            if (query.Length > 0)
            {
                //items = items.Where(query.ToString());

                authors = _dbContext.Authors.Where(query.ToString());
                count = await authors.CountAsync();
                authors = authors.OrderBy(orderBy).Skip(skip).Take(take);
            }

            if (count == 0)
            {
                authors = _dbContext.Authors.OrderBy(orderBy).Skip(skip).Take(take);
                count = await _dbContext.Authors.CountAsync();
            }
            

            AuthorDataResult authorDataResult = new AuthorDataResult()
            {
                Authors = authors.ToList(),
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
