using System.ComponentModel.DataAnnotations;

namespace UFV_Conversor;

public partial class Login : ContentPage
{
    private AccountsData Data = new AccountsData();

    public Login()
    {
        InitializeComponent();
    }

    private async void GoToPrivacyPolicy(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("PrivacyPolicy");
    }

    private async void GoToResetPassword(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("ResetPassword");
    }

    /* 
        Creates a new User and adds it to AppSession by finding the user information 
        from information provided in the entries on page.

        The information before being added to session is combined as an array of strings.
    */
    private async void ExecuteLogin(object sender, EventArgs e)
    {
        try
        {
            string inputUsername = loginUsername.Text;
            string inputPassword = loginPassword.Text;
            bool found = false;

            string[] CurrentUserData = Data.SearchForUser(inputUsername, inputPassword, ref found);

            AppSession.CurrentUser = new User(CurrentUserData);

            if (found)
                await Shell.Current.GoToAsync("ConverterPage");
            else
                throw new ValidationException("Validation Failed: Please verify if your username or password are correct");

        }
        catch (ValidationException ex)
        {
            await DisplayAlert("Login Validation Error: ", ex.Message, "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.GetType().Name + ": " + ex.Message, "OK");
        }
    }

    private async void GoToRecovery(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Recovery");
    }

    private void Exit(object sender, EventArgs e)
    {
        if (App.Current != null)
        {
            Application.Current.Quit();
        }
    }
}
