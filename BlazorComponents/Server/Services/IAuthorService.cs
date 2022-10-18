using BlazorComponents.Server.DataModel;
using BlazorComponents.Shared;

namespace BlazorComponents.Server.Services
{
    public interface IAuthorService
    {
        //Task<List<Author>> GetAuthor(int skip, int take);
        Task<AuthorDataResult> GetAuthor(int skip, int take);
    }
}
