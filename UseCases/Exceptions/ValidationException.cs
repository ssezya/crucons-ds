using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace UseCases.Exceptions
{
    public class ValidationException : Exception
    {
        public IDictionary<string, string[]> Failures { get; }

        public ValidationException() : base("One or more validation failures have occurred.")
        {
            Failures = new Dictionary<string, string[]>();
        }

        public ValidationException(ICollection<ValidationFailure> failures) : this()
        {
            var propertyNames = failures
                .Select(s => s.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(w => w.PropertyName == propertyName)
                    .Select(s => s.ErrorMessage)
                    .ToArray();

                Failures.Add(propertyName, propertyFailures);
            }
        }
    }
}
