using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HouseDemo.DataAccess.Models;
public class House : HouseBase
{
    [Key]
    [Comment("房屋Id")]
    public Guid HouseId { get; set; }

    [Required]
    [Comment("創建時間")]
    public DateTime CreatedTime { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    [Comment("創建者")]
    public string CreatedUser { get; set; }

    [Required]
    [Comment("修改時間")]
    public DateTime UpdatedTime { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    [Comment("修改者")]
    public string UpdatedUser { get; set; }

    [Comment("刪除時間")]
    public DateTime? DeletedTime { get; set; }

    [Column(TypeName = "varchar(50)")]
    [Comment("刪除者")]
    public string? DeletedUser { get; set; }

    public ICollection<Tag> Tags { get; set; }
    public List<HouseTag> HouseTags { get; set; }
}