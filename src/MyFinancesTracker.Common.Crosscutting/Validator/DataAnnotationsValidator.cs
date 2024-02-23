using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using MyFinancesTracker.Common.Crosscutting.Attributes.ServiceLifetime;
using MyFinancesTracker.Common.Crosscutting.Attributes.Validation;
using MyFinancesTracker.Common.Crosscutting.Extensions;
using MyFinancesTracker.Common.Crosscutting.Interfaces;

namespace MyFinancesTracker.Common.Crosscutting.Validator;

[ScopedLifetime]
public class DataAnnotationsValidator : IDataAnnotationsValidator
{
    public bool TryValidateObject(object obj, ICollection<ValidationResult> results, IDictionary<object, object?>? validationContextItems = null)
    {
        return System.ComponentModel.DataAnnotations.Validator.TryValidateObject(obj, new ValidationContext(obj, null, validationContextItems), results, true);
    }

    public bool TryValidateObjectRecursive<T>(T obj, List<ValidationResult> results, IDictionary<object, object?>? validationContextItems = null)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));

        return TryValidateObjectRecursive(obj, results, new HashSet<object>(), validationContextItems);
    }

    private bool TryValidateObjectRecursive<T>(T obj, List<ValidationResult> results, ISet<object> validatedObjects, IDictionary<object, object?>? validationContextItems = null)
    {
        if (obj == null) throw new ArgumentNullException(nameof(obj));

        //short-circuit to avoid infinit loops on cyclical object graphs
        if (validatedObjects.Contains(obj))
        {
            return true;
        }

        validatedObjects.Add(obj);
        var result = TryValidateObject(obj, results, validationContextItems);

        var properties = obj.GetType().GetProperties().Where(prop => prop.CanRead
                                                                     && prop.GetCustomAttributes(typeof(SkipRecursiveValidationAttribute), false).Length == 0
                                                                     && prop.GetIndexParameters().Length == 0).ToList();

        foreach (var property in properties)
        {
            if (property.PropertyType == typeof(string) || property.PropertyType.IsValueType) continue;

            var value = obj.GetPropertyValue(property.Name);

            if (value == null) continue;

            if (value is IEnumerable asEnumerable)
            {
                foreach (var enumObj in asEnumerable)
                {
                    if (enumObj != null)
                    {
                        result = HandleObjectRecursive(results, validatedObjects, validationContextItems, enumObj, result, property);
                    }
                }
            }
            else
            {
                result = HandleObjectRecursive(results, validatedObjects, validationContextItems, value, result, property);
            }
        }

        return result;
    }

    private bool HandleObjectRecursive(List<ValidationResult> results, ISet<object> validatedObjects, IDictionary<object, object?>? validationContextItems, object value, bool result, PropertyInfo property)
    {
        var nestedResults = new List<ValidationResult>();
        if (!TryValidateObjectRecursive(value, nestedResults, validatedObjects, validationContextItems))
        {
            result = false;
            foreach (var validationResult in nestedResults)
            {
                var property1 = property;
                results.Add(new ValidationResult(validationResult.ErrorMessage, validationResult.MemberNames.Select(x => property1.Name + '.' + x)));
            }
        }

        return result;
    }
}
