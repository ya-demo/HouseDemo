
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HouseDemo.DataAccess.Models;

public class HouseBase
{
    [Required]
    [Column(TypeName = "varchar(20)")]
    [Comment("房屋名稱")]
    public string HouseName { get; set; }

    [Required]
    [Column(TypeName = "varchar(100)")]
    [Comment("地址")]
    public string Address { get; set; }

    [Column(TypeName = "varchar(100)")]
    [Comment("描述")]
    public string? Description { get; set; }

    [Required]
    [Comment("價格")]
    public int Price { get; set; }

    [Column(TypeName = "float")]
    [Comment("折扣率")]
    public float? DiscountRate { get; set; }

    [Required]
    [Comment("房屋類型")]
    public HouseType HouseType { get; set; }

    [Required]
    [Column(TypeName = "float")]
    [Comment("年")]
    public float Years { get; set; }

    [Required]
    [Comment("最低樓層")]
    public int MinFloor { get; set; }

    [Required]
    [Comment("最高樓層")]
    public int MaxFloor { get; set; }

    [Required]
    [Comment("總樓層")]
    public int TotalFloor { get; set; }

    [Required]
    [Comment("房間數")]
    public int Rooms { get; set; }

    [Required]
    [Comment("廳數")]
    public int LivingRooms { get; set; }

    [Required]
    [Comment("衛浴數")]
    public int Bathrooms { get; set; }

    [Required]
    [Comment("是否有陽台")]
    public bool HasBalcony { get; set; }

    [Required]
    [Column(TypeName = "float")]
    [Comment("土地坪數")]
    public float LandSpace { get; set; }

    [Required]
    [Column(TypeName = "float")]
    [Comment("主坪數")]
    public float MainSpace { get; set; }

    [Required]
    [Column(TypeName = "float")]
    [Comment("建物坪數")]
    public float BuildingSpace { get; set; }

    [Column(TypeName = "float")]
    [Comment("車位坪數")]
    public float? ParkingSpace { get; set; }


}


