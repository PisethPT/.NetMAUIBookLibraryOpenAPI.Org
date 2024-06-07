#nullable disable
namespace BookLibraryOpenAPI.Org.Models;
public class Availability
{
    public string status { get; set; }
    public bool? available_to_browse { get; set; }
    public bool? available_to_borrow { get; set; }
    public bool? available_to_waitlist { get; set; }
    public bool? is_printdisabled { get; set; }
    public bool? is_readable { get; set; }
    public bool? is_lendable { get; set; }
    public bool is_previewable { get; set; }
    public string identifier { get; set; }
    public string isbn { get; set; }
    public object oclc { get; set; }
    public string openlibrary_work { get; set; }
    public string openlibrary_edition { get; set; }
    public object last_loan_date { get; set; }
    public object num_waitlist { get; set; }
    public object last_waitlist_date { get; set; }
    public bool is_restricted { get; set; }
    public bool? is_browseable { get; set; }
    public string __src__ { get; set; }
}


