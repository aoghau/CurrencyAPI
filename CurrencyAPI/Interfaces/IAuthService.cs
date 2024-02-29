namespace CurrencyAPI.Interfaces
{
    public interface IAuthService
    {
        public bool ValidateUser();
        public string ValidatedUserName();
    }
}
