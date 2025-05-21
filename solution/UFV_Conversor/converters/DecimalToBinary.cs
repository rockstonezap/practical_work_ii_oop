namespace UFV_Conversor;

public class DecimalToBinary : Conversion
{
    public DecimalToBinary(string name, string definition) : base(name, definition, new DecimalInputValidator()) { }

    public override string Change(string input)
    {
        int number = Int32.Parse(input);
        string binaryString = "";

        while (number > 0)
        {
            int remainder = number % 2;
            binaryString = remainder + binaryString;
            number /= 2;
        }

        return binaryString;
    }
}
