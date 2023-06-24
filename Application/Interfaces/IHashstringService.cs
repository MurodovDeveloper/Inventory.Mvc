namespace Application.Interfaces
{
    public interface IHashStringService
    {
        Task<string> GetHashStringAsync(string text);
    }
}
