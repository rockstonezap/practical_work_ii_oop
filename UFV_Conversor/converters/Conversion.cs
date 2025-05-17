namespace UFV_Conversor;

public abstract class Conversion
{
    protected string name;
    protected string definition;
    protected InputValidator validator;

    public Conversion(string name, string definition, InputValidator validator)
    {

        this.name = name;
        this.definition = definition;
        this.validator = validator;
    }

    public abstract string Change(string input);

    public string GetName()
    {
        return this.name;
    }

    public string GetDefinition()
    {
        return this.definition;
    }

    public void Validate(string input)
    {
        this.validator.Validate(input);
    }
}
