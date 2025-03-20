namespace SimpleHouseSystem.Models.DTO
{
    public class HouseDto
    {
        public int HouseId { get; set; }
        public string CityName { get; set; }
        public int UpperPrice { get; set; }
        public int LowerPrice { get; set; }
        public double UpperSquareMeters { get; set; }

        public double LowerSquareMeters { get; set; }
    }
}
