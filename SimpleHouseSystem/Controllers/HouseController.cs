using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleHouseSystem.Models;
using SimpleHouseSystem.Models.DTO;
using SimpleHouseSystem.Service;
using SimpleHouseSystem.Service.Interface;

namespace SimpleHouseSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private IHouseService _houseService;

        public HouseController(IHouseService houseService) 
        {
            _houseService = houseService;
        }

        /// <summary>
        /// 查詢符合條件的房屋
        /// </summary>
        /// <param name="cityName">城市名稱</param>
        /// <param name="upperPrice">最高價格</param>
        /// <param name="lowerSquareMeters">最低坪數</param>
        /// <param name="upperSquareMeters">最高坪數</param>
        /// <returns></returns>
        [HttpGet]
        public List<HouseModel> Get([FromBody] string cityName, int upperPrice, double lowerSquareMeters, double upperSquareMeters)
        {
            return _houseService.GetHouse(cityName, upperPrice, lowerSquareMeters, upperSquareMeters);
        }

        /// <summary>
        /// 新增房屋相關資訊
        /// </summary>
        /// <param name="house">房屋相關資訊</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Insert([FromBody] HouseModel house)
        {
            _houseService.InsertHouseInfo(house);
            return Ok();
        }

        /// <summary>
        /// 更新房屋相關資訊
        /// </summary>
        /// <param name="houseId">房屋編號</param>
        /// <param name="house">房屋相關資訊</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{houseId}")]
        public IActionResult Update(
            [FromRoute] int houseId,
            [FromBody] HouseModel house)
        {
            int status = _houseService.UpdateHouseInfo(house);
            if (status == 1)
            {
                return NotFound();
            }
            return Ok();
        }

        /// <summary>
        /// 刪除房屋相關資訊
        /// </summary>
        /// <param name="houseId">房屋編號</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{houseId}")]
        public IActionResult Delete([FromRoute] int houseId)
        {
            _houseService.DeleteHouseInfo(houseId);
            return Ok();
        }
    }
}
