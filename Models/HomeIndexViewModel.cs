namespace SimpleAuthApp.Models;

public class HomeIndexViewModel
{
    public bool IsAuthenticated { get; set; }

    public string? UserId { get; set; }

    public string? Email { get; set; }

    public string? UserName { get; set; }
}
