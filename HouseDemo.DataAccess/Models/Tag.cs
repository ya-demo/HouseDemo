using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HouseDemo.DataAccess.Models;
public class Tag : BaseColumn
{
    [Key]
    [Comment("標籤Id")]
    public Guid TagId { get; set; }
    [Required]
    [Column(TypeName = "varchar(20)")]
    [Comment("標籤名稱")]
    public string TagName { get; set; }

    public ICollection<House> Houses { get; set; }
    public List<HouseTag> HouseTags { get; set; }
}
