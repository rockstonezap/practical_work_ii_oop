namespace UFV_Conversor
{
    public class BinaryToDecimal : Conversion
    {
        public BinaryToDecimal(string name, string definition) : base(name, definition, new BinaryInputValidator()) { }

        public override string Change(string input)
        {
            int newNumber = 0;
            int pos = 0;
            int currentbit = input.Length - 1;

            while (currentbit >= 0)
            {
                if (input[pos] == '1')
                {
                    newNumber += (int)Math.Pow(2, currentbit);
                }

                currentbit--;
                pos++;
            }

            return Convert.ToString(newNumber);
        }
    }
}