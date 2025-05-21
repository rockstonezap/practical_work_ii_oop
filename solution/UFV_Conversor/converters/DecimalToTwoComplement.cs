namespace UFV_Conversor;

public class DecimalToTwoComplement : Conversion
{
    private int size = 16;

    public DecimalToTwoComplement(string name, string definition) : base(name, definition, new DecimalInputValidator()) { }

    public void SetSize(int size)
    {
        this.size = size;
    }

    public override string Change(string input)
    {
        int number = Int32.Parse(input);
        string binaryString = "";

        int minVal = -(1 << (size - 1)); // min number
        int maxVal = (1 << (size - 1)) - 1; // max number

        if (number < minVal || number > maxVal)
            throw new ArgumentOutOfRangeException(nameof(number), $"Number must fit within {size} bits.");

        // Left Side: Change into bit representation, Right Side: get max uint and substract 1, then with &, keep ones from number and leave rest as 0
        uint unsignedValue = (uint)number & ((1u << size) - 1);

        binaryString = Convert.ToString(unsignedValue, 2).PadLeft(size, '0');

        return binaryString;
    }
}