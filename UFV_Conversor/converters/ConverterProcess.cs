namespace UFV_Conversor;

public class ConverterProcess
{
    private List<Conversion> operations;

    public ConverterProcess()
    {

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

    public int Exit()
    {
        return this.operations.Count + 1;
    }
    public int GetNumberOperations()
    {
        return this.operations.Count;
    }

    public List<Conversion> GetList()
    {
        return this.operations;
    }

    public string PerformConversion(int op, string input)
    {

        this.operations[op - 1].Validate(input);

        if (this.operations[op - 1].NeedBitSize())
        {
            int bits = 16; // Modify later

            return this.operations[op - 1].Change(input, bits);
        }

        return this.operations[op - 1].Change(input);
    }
}