using System;

namespace ProductsCleanArch.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"{name} {key} was not found.")
        {
        }
    }
}