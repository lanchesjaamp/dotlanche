using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotLanches.Domain.Exceptions
{
    public class ClienteAlreadyExistsException : Exception
    {
        private const string MessageTemplate = "cliente {0} already exists!";

        public ClienteAlreadyExistsException(string propertyName) : base(string.Format(MessageTemplate, propertyName))
        {
        }
    }
}
