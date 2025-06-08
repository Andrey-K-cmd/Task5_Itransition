using BooksApplication.Models;

public class Book
{
    public int Index { get; set; }
    public string ISBN { get; set; } = "";
    public string Title { get; set; } = "";
    public string Author { get; set; } = "";
    public string Publisher { get; set; } = "";
    public int Likes { get; set; }
    public string Cover { get; set; } = "";
    public string Description { get; set; } = "";
    public string Reviews { get; set; } = "";
}
