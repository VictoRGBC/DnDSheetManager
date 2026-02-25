using DnDSheetManager.Domain.Entities;

namespace DnDSheetManager.Domain.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        int? ValidateToken(string token);
    }
}
