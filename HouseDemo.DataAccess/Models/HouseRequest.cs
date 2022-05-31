namespace HouseDemo.DataAccess.Models;
public class HouseRequest : HouseBase
{
    public List<Guid> TagIds { get; set; }
}