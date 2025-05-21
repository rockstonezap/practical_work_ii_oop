using CommunityToolkit.Maui.Views;

namespace UFV_Conversor;

public partial class ConverterPage : ContentPage
{
    private AccountsData Data = new AccountsData();
    private List<Conversion> operations;

    public ConverterPage()
    {
        InitializeComponent();

        this.operations = new List<Conversion>();

        this.operations.Add(new DecimalToBinary("Binary", "Decimal to binary"));
        this.operations.Add(new DecimalToOctal("Octal", "Decimal to octal"));
        this.operations.Add(new DecimalToHexadecimal("Hexadecimal", "Decimal to hexadecimal"));
        this.operations.Add(new DecimalToTwoComplement("TwoComplement", "Decimal to binary (2Complement)"));
        this.operations.Add(new BinaryToDecimal("Decimal", "Binary to Decimal"));
        this.operations.Add(new TwoComplementToDecimal("Decimal", "Binary (TwoComplement) to Decimal"));
        this.operations.Add(new OctalToDecimal("Decimal", "Octal to Decimal"));
        this.operations.Add(new HexadecimalToDecimal("Decimal", "Hexadecimal to Decimal"));
    }

    // Method just to get the event from page, executes the next method for the actual addition
    private void AddNewElement(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is string value)
            AddNewElement(value);
    }
    
    // Adds any value to the current text in the Entry for Converter
    private async void AddNewElement(string value)
    {
        // When null (on initialization) makes it empty string, to perform string addition later
        string input = userInput.Text ?? "";

        try
        {
            if (input.Contains('-') && value.Any(char.IsLetter))
            {
                throw new FormatException("Cannot add negative sign to number in hexadecimal form.");
            }

            userInput.Text += value;
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

    // Negates the number in the Entry for Converter
    private async void PerformNegation(object sender, EventArgs e)
    {
        string input = userInput.Text ?? "";

        try
        {
            if (input.Any(char.IsLetter))
            {
                throw new FormatException("Cannot make negative a hexadecimal number");
            }
            else if (input == "")
            {
                throw new FormatException("User Input is empty. Add a number to input to negate");
            }

            int number = int.Parse(input);

            userInput.Text = Convert.ToString(number * -1);
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

    // Clears the Entry Contents for Converter
    private void ClearUserInput(object sender, EventArgs e)
    {
        userInput.Text = "";
    }

    // Method just to get the event from page, executes the next method for the actual execution
    private void PerformConversion(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is string op)
            PerformConversion(Convert.ToInt16(op));
    }

    // Executes the conversion chosen by the user
    private async void PerformConversion(int op)
    {
        string input = userInput.Text ?? "";
        try
        {
            if (input == "")
            {
                throw new FormatException("Please introduce a number to convert. Input cannot be null");
            }

            this.operations[op].Validate(input);

            string output;

            output = this.operations[op].Change(input);

            int currentCount = Convert.ToInt16(AppSession.CurrentUser?.UserData[4]);

            // Increment Operations Count by 1
            // ! is to remove the warning, since I'm absolutely certain that value will never be null
            var userData = AppSession.CurrentUser?.UserData;
            userData![4] = Convert.ToString(currentCount + 1);

            Data.UpdateCounter(userData[1], userData[4]);

            await DisplayAlert(this.operations[op].GetName() + ": ", $"{input} ==> {output}", "OK");

        }
        catch (ArgumentOutOfRangeException ex)
        {
            await DisplayAlert("Input Length Error: ", ex.Message, "OK");
            userInput.Text = "";
        }
        catch (FormatException ex)
        {
            await DisplayAlert("Bad Format: ", ex.Message, "OK");
            userInput.Text = "";
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.GetType().Name + ": " + ex.Message, "OK");
            userInput.Text = "";
        }
    }

    // Displays the information of the user using a popup and information from AppSession
    private async void ShowUserInfo(object sender, EventArgs e)
    {
        await Task.Delay(25);

        // Passes current user data and if no current user, then just sets it to null and does not crash the runtime
        string[] data = AppSession.CurrentUser?.UserData ?? Array.Empty<string>();

        // Adds all data to popup "Page"
        var popup = new OperationsPopup(data);

        // Displays popup "Page"
        this.ShowPopup(popup);
    }

    // Empties out AppSession and redirects to Homepage
    private async void LogoutUser(object sender, EventArgs e)
    {
        AppSession.CurrentUser = new User(new string[5]);

        await Shell.Current.GoToAsync("Homepage");
    }

    private void Exit(object sender, EventArgs e)
    {
        if (App.Current != null)
        {
            Application.Current.Quit();
        }
    }
}
