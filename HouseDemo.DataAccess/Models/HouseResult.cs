namespace HouseDemo.DataAccess.Models;
public class HouseResult : HouseBase
{
    public Guid HouseId { get; set; }
    public List<HouseTag> HouseTags { get; set; }
}