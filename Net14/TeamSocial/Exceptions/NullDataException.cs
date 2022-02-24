using System;
using System.Collections.Generic;
using System.Text;

namespace TeamSocial.Exceptions
{
    [Serializable]
    public class NullDataException : Exception
    {
        public NullDataException() : base() { }
        public NullDataException(string message) : base(message) { }
        public NullDataException(string message, Exception inner) : base(message, inner) { }

    }

    [Serializable]
    public class EmailIsAlreadyExistsException : Exception 
    {
        public EmailIsAlreadyExistsException() : base() { }
        public EmailIsAlreadyExistsException(string message) : base(message) { }
        public EmailIsAlreadyExistsException(string message, Exception inner) : base(message, inner) { }

    }

    [Serializable]
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException() : base() { }
        public InvalidEmailException(string message) : base(message) { }
        public InvalidEmailException(string message, Exception inner) : base(message, inner) { }

    }
}
