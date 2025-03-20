
using SimpleHouseSystem.Models;

namespace SimpleHouseSystem.Service.Interface
{
    public interface IHouseService
    {
        List<HouseModel> GetAllHouse();
        List<HouseModel> GetHouse(string cityName, int upperPrice, double lowerSquareMeters, double upperSquareMeters);
        void insertHouseInfo(string cityName, int price, double squareMeters);
        void updateHouseInfo(int houseId, string cityName, int price, double squareMeters);
        void deleteHouseInfo(int houseId);
    }
}
