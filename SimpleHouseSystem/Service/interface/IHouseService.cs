
using SimpleHouseSystem.Models.DTO;

namespace SimpleHouseSystem.Service.Interface
{
    public interface IHouseService
    {
        List<HouseDto> GetAllHouse();
        void insertHouseInfo();
        void updateHouseInfo();
        void deleteHouseInfo();
    }
}
