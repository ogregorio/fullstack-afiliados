namespace FullstackAfiliados.Infra.CrosCutting.Exceptions
{
    // Exception for bad request errors (400 Bad Request)
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }

    // Exception for resource not found (404 Not Found)
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }

    // Exception for forbidden access (403 Forbidden)
    public class ForbiddenException : Exception
    {
        public ForbiddenException(string message) : base(message)
        {
        }
    }

    // Exception for too many requests (429 Too Many Requests)
    public class TooManyRequestsException : Exception
    {
        public TooManyRequestsException(string message) : base(message)
        {
        }
    }

    // Exception for unauthorized access (401 Unauthorized)
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message) : base(message)
        {
        }
    }

    // Exception for service unavailable (503 Service Unavailable)
    public class ServiceUnavailableException : Exception
    {
        public ServiceUnavailableException(string message) : base(message)
        {
        }
    }

    // Exception for method not allowed (405 Method Not Allowed)
    public class MethodNotAllowedException : Exception
    {
        public MethodNotAllowedException(string message) : base(message)
        {
        }
    }
}