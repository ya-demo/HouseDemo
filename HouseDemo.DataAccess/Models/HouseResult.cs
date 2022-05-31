namespace HouseDemo.DataAccess.Models;
public class HouseResult : HouseBase
{
    public Guid HouseId { get; set; }
    public DateTime CreatedTime { get; set; }
    public string CreatedUser { get; set; }
    public DateTime UpdatedTime { get; set; }
    public string UpdatedUser { get; set; }
    public DateTime? DeletedTime { get; set; }
    public string? DeletedUser { get; set; }
    public List<Tag> Tags { get; set; }
}