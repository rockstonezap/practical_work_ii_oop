namespace UFV_Conversor;

// Allows for a public variable to be shared across all instances of AppSession Class
public static class AppSession
{
    // Holds current user in session
    public static User? CurrentUser { get; set; }
}
