using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BomBiEn.Infrastructure.Domain
{
    public class DomainException : Exception
    {
        public IEnumerable<DomainExceptionError> Errors { get; private set; } = Enumerable.Empty<DomainExceptionError>();

        public HttpStatusCode StatusCode { get; private set; } = HttpStatusCode.InternalServerError;

        public DomainException(DomainExceptionError error)
        {
            Errors = new DomainExceptionError[] { error };
        }

        public DomainException(HttpStatusCode statusCode, DomainExceptionError error)
            : this(error)
        {
            StatusCode = statusCode;
        }

        public DomainException(HttpStatusCode statusCode, IEnumerable<DomainExceptionError> errors)
            : this(errors)
        {
            StatusCode = statusCode;
        }

        public DomainException(IEnumerable<DomainExceptionError> errors)
        {
            Errors = errors;
        }
    }
}