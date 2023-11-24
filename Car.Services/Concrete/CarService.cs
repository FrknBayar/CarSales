using Car.Data.Entity;
using Car.Repositories.Context;
using Car.Services.Abstract;
using Car.Services.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;

namespace Car.Services.Concrete
{
    public class CarService : ICarService
    {
        private readonly CarContext _carContext;

        public CarService(CarContext carContext)
        {
            _carContext = carContext;
        }

        public async Task<ResponseModel<ScriptModel>> CreateOrUpdateCarAsync(CarRequestModel carRequestModel)
        {
            if (carRequestModel == null)
            {
                return null;
            }

            var existingCar = await GetCarSalesBySerialNumberAsync(carRequestModel.FieldData.SerialNumber);

            if (existingCar == null)
            {
                await AddCarAsync(new CarSales { SerialNumber = carRequestModel.FieldData.SerialNumber, TotalSales = carRequestModel.FieldData.SalesCount });
            }
            else
            {
                await UpdateCarSalesAsync(existingCar, carRequestModel.FieldData.SalesCount);
            }

            var result = await GetAllCarSalesAsync();

            return new ResponseModel<ScriptModel>
            {
                Response = new ScriptModel
                {
                    ScriptResult = JsonSerializer.Serialize(result),
                    ScriptError = "0",
                    ModId = "4"
                },
                Messages = new List<MessageModel>
                {
                    new MessageModel()
                    {
                        Code = ((int)HttpStatusCode.OK).ToString(),
                        Message = HttpStatusCode.OK.ToString(),
                    }
                }
            };
        }

        private async Task<bool> AddCarAsync(CarSales carSales)
        {
            if (carSales == null)
            {
                return false;
            }

            await _carContext.CarSales.AddAsync(carSales);
            await _carContext.SaveChangesAsync();

            return true;
        }

        private async Task<bool> UpdateCarSalesAsync(CarSales updatingCarSales, int salesCount)
        {
            if (updatingCarSales == null)
            {
                return false;
            }

            updatingCarSales.TotalSales += salesCount;

            await _carContext.SaveChangesAsync();

            return true;
        }

        private async Task<CarSales> GetCarSalesBySerialNumberAsync(string serialNumber)
        {
            return await _carContext.CarSales.FirstOrDefaultAsync(x => x.SerialNumber == serialNumber);
        }

        private async Task<List<CarSales>> GetAllCarSalesAsync()
        {
            return await _carContext.CarSales.ToListAsync();
        }
    }
}
