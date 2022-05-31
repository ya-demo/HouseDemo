using Microsoft.EntityFrameworkCore;

namespace HouseDemo.DataAccess.Models;
public class House : HouseBase
{
    [Key]
    [Comment("房屋Id")]
    public Guid HouseId { get; set; }

    public ICollection<Tag> Tags { get; set; }
    public List<HouseTag> HouseTags { get; set; }
}