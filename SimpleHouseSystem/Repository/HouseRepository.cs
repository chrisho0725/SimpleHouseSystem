using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using SimpleHouseSystem.Models;
using SimpleHouseSystem.Models.DTO;
using SimpleHouseSystem.Repository.Interface;

namespace SimpleHouseSystem.Repository;

public class HouseRepository: IHouseRepository
{

    /// <summary>
    /// 連線字串
    /// </summary>
    private readonly string _connectString = @"Server=localhost\SQLEXPRESS;Database=test;Trusted_Connection=True;";

    public void DeleteHouse()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 查詢卡片列表
    /// </summary>
    /// <returns></returns>
    public List<HouseDto> GetAllHouse()
    {
        using (var conn = new SqlConnection(_connectString))
        {
            var result = conn.Query<HouseModel>("SELECT * FROM house Where HouseId > 0");
            var lsHouseDto = new List<HouseDto>();
            foreach (var item in result)
            {
                var houseDto = new HouseDto();
                houseDto.HouseId = item.HouseId;
                houseDto.CityName = item.CityName;
                houseDto.SquareMeters = item.SquareMeters;
                houseDto.Price = item.UnitPrice * item.SquareMeters;
                lsHouseDto.Add(houseDto);
            }
            return lsHouseDto;
        }
    }

    public List<HouseDto> GetHouse(string cityName,int price, double SquareMeters)
    {
        var condition = new List<String>();
        if (!cityName.IsNullOrEmpty())
        { 
            condition.Add("CityName = @CityName");
        }

        if (condition.Any()) 
        {
            condition.Insert(0, "WHERE");
        }

        var conditionStr = string.Join(" ",condition);
        var sql = $"SELECT * FROM house {conditionStr} ";

        var parameters = new DynamicParameters();
        parameters.Add("CityName", cityName);

        using (var conn = new SqlConnection(_connectString))
        {
            var result = conn.Query<HouseModel>(sql, parameters);
            var lsHouseDto = new List<HouseDto>();
            foreach (var item in result)
            {
                var houseDto = new HouseDto();
                houseDto.HouseId = item.HouseId;
                houseDto.CityName = item.CityName;
                houseDto.SquareMeters = item.SquareMeters;
                houseDto.Price = item.UnitPrice * item.SquareMeters;
                lsHouseDto.Add(houseDto);
            }
            return lsHouseDto;
        }
    }

    public void InsertHouse()
    {
        throw new NotImplementedException();
    }

    public void UpdateHouse(HouseModel house)
    {
        throw new NotImplementedException();
    }
}
