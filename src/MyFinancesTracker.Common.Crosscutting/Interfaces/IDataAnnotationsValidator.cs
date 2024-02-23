using System.ComponentModel.DataAnnotations;

namespace MyFinancesTracker.Common.Crosscutting.Interfaces;

public interface IDataAnnotationsValidator
{
    bool TryValidateObject(object obj, ICollection<ValidationResult> results, IDictionary<object, object?>? validationContextItems = null);
    bool TryValidateObjectRecursive<T>(T obj, List<ValidationResult> results, IDictionary<object, object?>? validationContextItems = null);
}
