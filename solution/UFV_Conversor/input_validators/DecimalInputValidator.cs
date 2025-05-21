namespace UFV_Conversor;

public class DecimalInputValidator : InputValidator
{
    public override void Validate(string input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '-' || !char.IsDigit(input[i]))
            {
                throw new FormatException("Input is not a valid integer.");
            }
        }
    }
}
