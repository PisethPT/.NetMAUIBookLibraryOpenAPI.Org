#nullable disable
namespace BookLibraryOpenAPI.Org.Models;
public class Work
{
    public List<string> author_key { get; set; }
    public List<string> author_name { get; set; }
    public string cover_edition_key { get; set; }
    public int cover_i { get; set; }
    public int edition_count { get; set; }
    public int first_publish_year { get; set; }
    public bool has_fulltext { get; set; }
    public string key { get; set; }
    public List<string> language { get; set; }
    public bool public_scan_b { get; set; }
    public string title { get; set; }
    public List<string> ia { get; set; }
    public string ia_collection_s { get; set; }
    public string lending_edition_s { get; set; }
    public string lending_identifier_s { get; set; }
    public Availability availability { get; set; }
    public string subtitle { get; set; }
    public List<string> id_project_gutenberg { get; set; }
    public List<string> id_librivox { get; set; }
    public List<string> id_standard_ebooks { get; set; }
}
