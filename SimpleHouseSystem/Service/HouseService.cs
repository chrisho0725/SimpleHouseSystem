using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using SimpleHouseSystem.Models;
using SimpleHouseSystem.Repository;
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



    public void InsertHouseInfo(HouseModel house)
    {
        house.HouseId = _houseRepository.GetLastHouseId();
        _houseRepository.InsertHouse(house);
    }

    public int UpdateHouseInfo(HouseModel house)
    {
        if (CheckHouseExist(house.HouseId))
        {
            _houseRepository.UpdateHouse(house);
            return 0;
        }

        return 1;
    }
    public void DeleteHouseInfo(int houseId)
    {
        _houseRepository.DeleteHouse(houseId);
    }

    private bool CheckHouseExist(int houseId)
    {
        HouseModel house = _houseRepository.GetHouseById(houseId);
        return house != null;
    }
}
