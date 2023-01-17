namespace ContineroTest.Common.Exceptions;

using System;
using System.Runtime.Serialization;

[Serializable]
public class ConversionFailedException : Exception
{
    public ConversionFailedException()
    {
    }

    public ConversionFailedException(string message)
        : base(message)
    {
    }

    public ConversionFailedException(string message, Exception inner)
        : base(message, inner)
    {
    }

    protected ConversionFailedException(SerializationInfo info, StreamingContext context) 
        : base(info, context)
    {
    }
}