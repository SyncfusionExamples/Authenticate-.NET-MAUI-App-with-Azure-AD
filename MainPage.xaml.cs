using CommunityToolkit.Maui.Alerts;
using Microsoft.Identity.Client;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MauiAuthApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnLoginClicked(object sender, EventArgs e)
	{
        try
        {
            var authService = new AuthService();
            var result = await authService.LoginAsync(CancellationToken.None);
            var token = result?.IdToken; // AccessToken also can be used
            if (token != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var data = handler.ReadJwtToken(token);
                var claims = data.Claims.ToList();
                if (data != null)
                {
                    var stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine($"Name: {data.Claims.FirstOrDefault(x => x.Type.Equals("name"))?.Value}");
                    stringBuilder.AppendLine($"Email: {data.Claims.FirstOrDefault(x => x.Type.Equals("preferred_username"))?.Value}");
                    await Toast.Make(stringBuilder.ToString()).Show();
                }
            }
        }
        catch (MsalClientException ex)
        {
            await Toast.Make(ex.Message).Show();
        }
    }
}