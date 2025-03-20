using SimpleHouseSystem.Models;
using SimpleHouseSystem.Models.DTO;

namespace SimpleHouseSystem.Repository.Interface;
public interface IHouseRepository
{
    
    List<HouseModel> GetAllHouse();
    List<HouseModel> GetHouse(string cityName, int upperPrice, double lowerSquareMeters, double upperSquareMeters);
    void InsertHouse(HouseModel houseParam);
    void UpdateHouse(HouseModel houseParam);
    void DeleteHouse(int houseId);
}