namespace ContineroTest.Common.Exceptions;

using System;
using System.Runtime.Serialization;

[Serializable]
public class RestReadFailedException : Exception
{
    public RestReadFailedException()
    {
    }

    public RestReadFailedException(string message)
        : base(message)
    {
    }

    public RestReadFailedException(string message, Exception inner)
        : base(message, inner)
    {
    }

    protected RestReadFailedException(SerializationInfo info, StreamingContext context) 
        : base(info, context)
    {
    }
}