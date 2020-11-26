using System;
using System.Runtime.Serialization;

[Serializable]
internal class ErrorEnLaConsultaAlServicorException : Exception
{
    public ErrorEnLaConsultaAlServicorException()
    {
    }

    public ErrorEnLaConsultaAlServicorException(string message) : base(message)
    {
    }

    public ErrorEnLaConsultaAlServicorException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected ErrorEnLaConsultaAlServicorException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}