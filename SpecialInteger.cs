#pragma warning disable
class SpecialInteger
{
    private int _tryValue;
    private DigitForm _form;
    private SpecialInteger(DigitForm form, int tryValue = 0)
    {
        if (form == DigitForm.Standard)
        {
            _tryValue = tryValue;
        }
        _form = form;
    }
    public SpecialInteger(int value)
    {
        _tryValue = value;
        _form = DigitForm.Standard;
    }
    public static SpecialInteger NaN
    {
        get => new(DigitForm.NaN);
    }
    public void WriteLine()
    {
        Console.WriteLine(ToString());
    }
    public void BufferFill(char[] buffer)
    {
        var s = ToString();
        for (int i = 0; i < s.Length; i++)
        {
            buffer[i] = s[i];
        }
    }
    public static SpecialInteger? operator +(SpecialInteger specialInt1, SpecialInteger specialInt2)
    {
        DigitForm form1 = specialInt1.Form;
        DigitForm form2 = specialInt1.Form;
        if (form1 == DigitForm.Standard && form2 == DigitForm.Standard)
        {
            return new(DigitForm.Standard, specialInt1.TryValue + specialInt2.TryValue);
        }
        if (form1 == DigitForm.NaN || form2 == DigitForm.NaN)
        {
            return new(DigitForm.NaN);
        }
        if (form1 == DigitForm.PositiveInfinity && form2 == DigitForm.PositiveInfinity)
        {
            return new(DigitForm.PositiveInfinity);
        }
        if (form1 == DigitForm.NegativeInfinity && form2 == DigitForm.NegativeInfinity)
        {
            return new(DigitForm.NegativeInfinity);
        }
        if (form1 == DigitForm.PositiveInfinity && form2 == DigitForm.NegativeInfinity)
        {
            return new(DigitForm.Standard);
        }
        if (form1 == DigitForm.NegativeInfinity && form2 == DigitForm.PositiveInfinity)
        {
            return new(DigitForm.Standard);
        }
        return null;
    }
    public static SpecialInteger? operator *(SpecialInteger specialInt1, SpecialInteger specialInt2)
    {
        DigitForm form1 = specialInt1.Form;
        DigitForm form2 = specialInt1.Form;
        if (form1 == DigitForm.Standard && form2 == DigitForm.Standard)
        {
            return new(DigitForm.Standard, specialInt1.TryValue * specialInt2.TryValue);
        }
        if (form1 == DigitForm.NaN || form2 == DigitForm.NaN)
        {
            return new(DigitForm.NaN);
        }
        if (form1 == DigitForm.PositiveInfinity && form2 == DigitForm.PositiveInfinity)
        {
            return new(DigitForm.PositiveInfinity);
        }
        if (form1 == DigitForm.NegativeInfinity && form2 == DigitForm.NegativeInfinity)
        {
            return new(DigitForm.NegativeInfinity);
        }
        if (form1 == DigitForm.PositiveInfinity && form2 == DigitForm.NegativeInfinity)
        {
            return new(DigitForm.NegativeInfinity);
        }
        if (form1 == DigitForm.NegativeInfinity && form2 == DigitForm.PositiveInfinity)
        {
            return new(DigitForm.NegativeInfinity);
        }
        return null;
    }
    public override string? ToString()
    {
        switch (Form)
        {
            case DigitForm.Standard :
            return TryValue.ToString();
            case DigitForm.PositiveInfinity :
            return "Infinity";
            case DigitForm.NegativeInfinity :
            return "-Infinity";
            case DigitForm.NaN :
            return "NaN";
        }
        return null;
    }
    public DigitForm Form
    {
        get => _form;
    }
    public int TryValue
    {
        get => _tryValue;
    }
}