#nullable disable
namespace BookLibraryOpenAPI.Org.Models;
public class TrendingBookModel
{
    public string query { get; set; }
    public List<Work> works { get; set; }
    public int days { get; set; }
    public int hours { get; set; }
}




