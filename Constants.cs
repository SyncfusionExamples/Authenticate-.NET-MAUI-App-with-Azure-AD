namespace MauiAuthApp;

public static class Constants
{
    //The Application or Client ID will be generated while registering the app in the Azure portal. Copy and paste the GUID.
    public static readonly string ClientId = "Client_ID";

    //Leaving the scope to its default values
    public static readonly string[] Scopes = new string[] { "openid", "offline_access" };
}


