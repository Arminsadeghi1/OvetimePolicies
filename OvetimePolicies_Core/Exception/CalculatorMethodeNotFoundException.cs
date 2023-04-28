namespace OvetimePolicies_Core.Exception;

using System;

sealed public class CalculatorMethodeNotFoundException : Exception
{
    public CalculatorMethodeNotFoundException()
    {

    }
    public CalculatorMethodeNotFoundException(string message) : base(message)
    {

    }
}
