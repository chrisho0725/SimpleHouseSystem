using Microsoft.IdentityModel.Tokens;
using SimpleHouseSystem.Models;
using SimpleHouseSystem.Repository.Interface;
using SimpleHouseSystem.Service.Interface;

namespace SimpleHouseSystem.Service;

public class HouseService: IHouseService
{
    private IHouseRepository _houseRepository;

    public HouseService(IHouseRepository houseRepository)
    { 
        _houseRepository = houseRepository;
    }

    public List<HouseModel> GetAllHouse()
    {
        return _houseRepository.GetAllHouse();
    }

    public List<HouseModel> GetHouse(string cityName, int upperPrice, double lowerSquareMeters, double upperSquareMeters)
    {
        return _houseRepository.GetHouse(cityName, upperPrice, lowerSquareMeters, upperSquareMeters);
    }

    public void insertHouseInfo(string cityName, int price, double squareMeters)
    { 
        var house = new HouseModel();
        house.CityName = cityName;
        house.Price = price;
        house.SquareMeters = squareMeters;
        _houseRepository.InsertHouse(house);
    }

    public void updateHouseInfo(int houseId, string cityName, int price, double squareMeters)
    {
        var house = new HouseModel();
        house.HouseId = houseId;
        if (!cityName.IsNullOrEmpty())
        {
            house.CityName = cityName;        
        }
        if (price > 0)
        { 
            house.Price = price;            
        }
        if (squareMeters > 0)
        { 
            house.SquareMeters = squareMeters;            
        }
        _houseRepository.UpdateHouse(house);
    }
    public void deleteHouseInfo(int houseId)
    {
        _houseRepository.DeleteHouse(houseId);
    }
}
