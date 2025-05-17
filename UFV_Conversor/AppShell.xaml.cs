namespace UFV_Conversor;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		// Registering Routes

		Routing.RegisterRoute("Homepage", typeof(MainPage));
		Routing.RegisterRoute("PrivacyPolicy", typeof(PrivacyPolicy));
		Routing.RegisterRoute("Register", typeof(Register));
		Routing.RegisterRoute("Login", typeof(Login));
		Routing.RegisterRoute("ConverterPage", typeof(ConverterPage));

		// TODO: Add route for forgot password
	}
}
