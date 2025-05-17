namespace UFV_Conversor;

public partial class ConverterPage : ContentPage
{
    protected ConverterProcess converterProcess;

    public ConverterPage()
    {
        InitializeComponent();

        converterProcess = new ConverterProcess();
    }

    private async void GoToPrivacyPolicy(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("PrivacyPolicy");
    }

    private void AddNewElement(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is string value)
            AddNewElement(value);
    }

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

    private void ClearUserInput(object sender, EventArgs e)
    {
        userInput.Text = "";
    }

    private async void PerformConversion(int op, string input)
    {
        string output = converterProcess.PerformConversion(op, input);

        await DisplayAlert("Output: ", output, "OK");
    }

    private void Exit(object sender, EventArgs e)
    {
        if (App.Current != null)
        {
            Application.Current.Quit();
        }
    }
}
