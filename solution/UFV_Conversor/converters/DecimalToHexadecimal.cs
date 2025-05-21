namespace UFV_Conversor;

public class DecimalToHexadecimal : Conversion
{
    public DecimalToHexadecimal(string name, string definition) : base(name, definition, new DecimalInputValidator()) { }

    public override string Change(string input)
    {
        string hexString = "";
        int number = Int32.Parse(input);
        char[] hexChars = "0123456789ABCDEF".ToCharArray();

        while (number > 0)
        {
            int remainder = number % 16;
            hexString = hexChars[remainder] + hexString;
            number /= 16;
        }

        return hexString;
    }
}
