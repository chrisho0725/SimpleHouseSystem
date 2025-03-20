
using SimpleHouseSystem.Models;

namespace SimpleHouseSystem.Service.Interface
{
    public interface IHouseService
    {
        List<HouseModel> GetAllHouse();
        List<HouseModel> GetHouse(string cityName, int upperPrice, double lowerSquareMeters, double upperSquareMeters);
        void InsertHouseInfo(HouseModel house);
        int UpdateHouseInfo(HouseModel house);
        void DeleteHouseInfo(int houseId);
    }
}
