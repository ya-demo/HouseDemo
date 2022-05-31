namespace HouseDemo.Common.PageExtention;
public class PageResult<T>
{
    /// <summary>
    /// 取得頁面
    /// </summary>
    public int? Page { get; set; }
    /// <summary>
    /// 每頁最多筆數
    /// </summary>
    public int? Rows { get; set; }
    /// <summary>
    /// 總筆數
    /// </summary>
    public int Total { get; set; }
    /// <summary>
    /// 資料列
    /// </summary>
    public IEnumerable<T>? Data { get; set; }
}

