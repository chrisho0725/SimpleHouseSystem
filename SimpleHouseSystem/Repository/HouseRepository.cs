using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using SimpleHouseSystem.Models;
using SimpleHouseSystem.Repository.Interface;

namespace SimpleHouseSystem.Repository;

public class HouseRepository : IHouseRepository
{

    /// <summary>
    /// 連線字串
    /// </summary>
    private readonly string _connectString = @"Server=localhost\SQLEXPRESS;Database=test;Trusted_Connection=true;";

    public List<HouseModel> GetAllHouse()
    {
        using (var conn = new SqlConnection(_connectString))
        {
            var result = conn.Query<HouseModel>("SELECT * FROM House Where HouseId > 0");
            return (List<HouseModel>)result;
        }
    }

    public List<HouseModel> GetHouse(string cityName, int upperPrice, double lowerSquareMeters, double upperSquareMeters)
    {
        var parameters = new DynamicParameters();
        var condition = new List<String>();
        if (!cityName.IsNullOrEmpty())
        {
            condition.Add("CityName = @CityName");
            parameters.Add("CityName", cityName);
        }

        if (upperPrice > 0)
        {
            condition.Add("Price < @Price");
            parameters.Add("Price", upperPrice);
        }

        if (lowerSquareMeters > 0)
        {
            condition.Add("SquareMeters >= @SquareMeters");
            parameters.Add("SquareMeters", lowerSquareMeters);
        }

        if (upperSquareMeters > 0)
        {
            condition.Add("SquareMeters <= @SquareMeters");
            parameters.Add("SquareMeters", upperSquareMeters);
        }

        var conditionStr = string.Join(" AND ", condition);
        if (condition.Any())
        {
            conditionStr = $"WHERE {conditionStr}";
        }

        var sql = $"SELECT * FROM House {conditionStr} ";
        using (var conn = new SqlConnection(_connectString))
        {
            var result = conn.Query<HouseModel>(sql, parameters);
            return (List<HouseModel>)result;
        }
    }

    public void InsertHouse(HouseModel houseParam)
    {
        var sql =
    @"
        INSERT INTO House 
        (
            [HouseId]
           ,[CityName]
           ,[SquareMeters]
           ,[Price]
        ) 
        VALUES 
        (
            @HouseId
           ,@CityName
           ,@SquareMeters
           ,@Price
        );
        
        SELECT @@IDENTITY;
    ";

        using (var conn = new SqlConnection(_connectString))
        {
            var result = conn.QueryFirstOrDefault<int>(sql, houseParam);
        }
    }

    public void UpdateHouse(HouseModel houseParam)
    {
        var sql =
        @"
        UPDATE House
        SET 
             [CityName] = @CityName
            ,[SquareMeters] = @SquareMeters
            ,[Price] = @Price
        WHERE 
            HouseId = @HouseId
        "
        ;

        var parameters = new DynamicParameters(houseParam);
        parameters.Add("HouseId", houseParam.HouseId);

        using (var conn = new SqlConnection(_connectString))
        {
            var result = conn.Execute(sql, parameters);
        }
    }

    public void DeleteHouse(int houseId)
    {
        var sql =
    @"
        DELETE FROM House
        WHERE HouseId = @HouseId
    ";

        var parameters = new DynamicParameters();
        parameters.Add("HouseId", houseId, System.Data.DbType.Int32);

        using (var conn = new SqlConnection(_connectString))
        {
            var result = conn.Execute(sql, parameters);
        }
    }
}
