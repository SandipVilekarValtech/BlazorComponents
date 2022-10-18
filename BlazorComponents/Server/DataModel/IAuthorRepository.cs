using BlazorComponents.Shared;

namespace BlazorComponents.Server.DataModel
{
    public interface IAuthorRepository
    {
        //Task<IEnumerable<Author>> GetAll(int skip, int take);
        Task<AuthorDataResult> GetAll(int skip, int take);
        ////Task<int> GetCount();
        Task<IEnumerable<Author>> Search(string firstName);
        Task<Author> GetAuthor(int id);
        Task<Author> GetAuthorByEmail(string email);
    }
}
