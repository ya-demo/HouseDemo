


namespace HouseDemo.DataAccess.Models;
public class HouseTag
{
    [Key]
    public Guid HouseTagId { get; set; }

    public Guid FkHouseId { get; set; }
    public House House { get; set; }

    public Guid FkTagId { get; set; }
    public Tag Tag { get; set; }
}

