using Car.Services.Models;

namespace Car.Services.Abstract
{
    public interface ICarService
    {
        Task<ResponseModel<ScriptModel>> CreateOrUpdateCarAsync(CarRequestModel carRequestModel);
    }
}
