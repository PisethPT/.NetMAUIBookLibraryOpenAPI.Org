namespace BookLibraryOpenAPI.Org.Models;
#nullable disable
public class Subjects
{
    public List<Types> types { get; set; }
}

public class Types
{
    public List<string> arts { get; set; }
    public List<string> animals { get; set; }
    public List<string> fiction { get; set; }
    public List<string> scienceMath { get; set; }
    public List<string> businessFinance { get; set; }
    public List<string> childrens { get; set; }
    public List<string> history { get; set; }
    public List<string> healthWellness { get; set; }
    public List<string> biography { get; set; }
    public List<string> socialSciences { get; set; }
    public List<string> places { get; set; }
    public List<string> textbooks { get; set; }
    public List<string> booksByLanguage { get; set; }
}



