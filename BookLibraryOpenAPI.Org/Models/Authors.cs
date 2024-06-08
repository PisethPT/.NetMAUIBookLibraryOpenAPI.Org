
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BookLibraryOpenAPI.Org.Models;
public class Authors
{
    //public Author author { get; set; }
    public Type type { get; set; }
}


public class Created
{
    public string type { get; set; }
    public DateTime value { get; set; }
}

public class Description
{
    public string type { get; set; }
    public string value { get; set; }
}

public class LastModified
{
    public string type { get; set; }
    public DateTime value { get; set; }
}

public class Root
{
    public string title { get; set; }
    public List<Author> authors { get; set; }
    public string key { get; set; }
    public Type type { get; set; }
    public List<int> covers { get; set; }
    public List<string> subjects { get; set; }
    public Description description { get; set; }
    public int latest_revision { get; set; }
    public int revision { get; set; }
    public Created created { get; set; }
    public LastModified last_modified { get; set; }
}

public class Type
{
    public string key { get; set; }
}