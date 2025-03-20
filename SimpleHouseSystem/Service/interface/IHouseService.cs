
using SimpleHouseSystem.Models;

namespace SimpleHouseSystem.Service.Interface
{
    public interface IHouseService
    {
        List<HouseModel> GetAllHouse();
        void insertHouseInfo();
        void updateHouseInfo();
        void deleteHouseInfo();
    }
}
