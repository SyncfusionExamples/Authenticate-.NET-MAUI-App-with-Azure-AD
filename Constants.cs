namespace MauiAuthApp;

public static class Constants
{
    //The Application or Client ID will be generated while registering the app in the Azure portal. Copy and paste the GUID.
    public static readonly string ClientId = "3bf5e165-a671-44e9-a412-22f13c737078";

    //Leaving the scope to its default values
    public static readonly string[] Scopes = new string[] { "openid", "offline_access" };
}


