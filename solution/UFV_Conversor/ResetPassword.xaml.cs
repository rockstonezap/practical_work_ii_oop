using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace UFV_Conversor {

    public partial class ResetPassword : ContentPage {
        
        private PasswordValidator PasswordChecker = new PasswordValidator();
        private AccountsData Data = new AccountsData();

        public ResetPassword()
        {
            InitializeComponent();
        }

        private async void ChangePassword(object sender, EventArgs e)
        {
            string username = checkUsername.Text;
            string email = checkEmail.Text;

            string password = newPassword.Text;
            string confirmPassword = checkNewPassword.Text;

            try
            {
                Data.UpdatePasswordEntry(username, email, password);

                if (!(password == confirmPassword))
                {
                    throw new FormatException("Password fields must match");
                }

                PasswordChecker.Validate(password);
                
                await Shell.Current.GoToAsync("Login");
            }
            catch (ValidationException ex)
            {
                await DisplayAlert("Password Change Validation Error: ", ex.Message, "OK");
            }
            catch (FormatException ex)
            {
                await DisplayAlert("Format Error: ", ex.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.GetType().Name + ": " + ex.Message, "OK");
            }
        }

        private async void ReturnToHomepage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("Homepage");
        }
        
        private void Exit(object sender, EventArgs e) {
            if (App.Current != null) {
                Application.Current.Quit();
            }
        }
    }
}