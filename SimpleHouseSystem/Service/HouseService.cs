using SimpleHouseSystem.Models.DTO;
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

    public void deleteHouseInfo()
    {
        throw new NotImplementedException();
    }

    public List<HouseDto> GetAllHouse()
    {
        return _houseRepository.GetAllHouse();
    }

    public void insertHouseInfo()
    { 
        
    }

    public void updateHouseInfo()
    {
        throw new NotImplementedException();
    }
}
