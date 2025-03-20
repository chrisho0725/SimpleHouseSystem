using SimpleHouseSystem.Models;
using SimpleHouseSystem.Models.DTO;

namespace SimpleHouseSystem.Repository.Interface;
public interface IHouseRepository
{
    
    List<HouseDto> GetAllHouse();
    List<HouseDto> GetHouse(string cityName, int price, double SquareMeters);
    void InsertHouse();
    void UpdateHouse(HouseModel house);
    void DeleteHouse();
}