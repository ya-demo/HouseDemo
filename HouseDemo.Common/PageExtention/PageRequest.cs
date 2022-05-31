using System;
namespace HouseDemo.Common.PageExtention;

public class PageRequest
{
    /// <summary>
    /// 第幾頁
    /// </summary>
    public int? Page { get; set; }
    /// <summary>
    /// 每頁幾筆
    /// </summary>
    public int? Rows { get; set; }
    /// <summary>
    /// 關鍵字篩選
    /// </summary>
    public string? Filter { get; set; }
}