using Car.Services.Models;

namespace Car.Services.Abstract
{
    public interface IUserService
    {
        ResponseModel<LoginModel> Login(string userName, string password);
    }
}
