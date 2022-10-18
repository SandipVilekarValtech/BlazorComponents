namespace BlazorComponents.Server.DataModel
{
    public class AuthorDataResult
    {
        public IEnumerable<Author> Authors { get; set; }
        public int Count { get; set; }
    }
}
