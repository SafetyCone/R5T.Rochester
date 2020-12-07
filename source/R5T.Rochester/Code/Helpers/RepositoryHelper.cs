using System;
using System.Threading.Tasks;

using R5T.Magyar;


namespace R5T.Rochester
{
    public static class RepositoryHelper
    {
        public static string GetElementWithKeyNotFoundExceptionMessage(string elementTypeName, string keyTypeName, string keyValueString)
        {
            var message = $"No {elementTypeName} exists with the {keyTypeName} value '{keyValueString}'.";
            return message;
        }

        public static string GetElementWithKeyNotFoundExceptionMessage<TElement, TKey>(string keyValueString)
        {
            var elementTypeName = nameof(TElement);
            var keyTypeName = nameof(TKey);

            var message = RepositoryHelper.GetElementWithKeyNotFoundExceptionMessage(elementTypeName, keyTypeName, keyValueString);
            return message;
        }

        public static string GetElementWithKeyNotFoundExceptionMessage<TElement, TKey>(TKey keyValue)
        {
            var keyValueString = keyValue.ToString();

            var message = RepositoryHelper.GetElementWithKeyNotFoundExceptionMessage<TElement, TKey>(keyValueString);
            return message;
        }

        public static InvalidOperationException GetElementWithKeyNotFoundException<TElement, TKey>(TKey keyValue)
        {
            var message = RepositoryHelper.GetElementWithKeyNotFoundExceptionMessage<TElement, TKey>(keyValue);

            var exception = new InvalidOperationException(message);
            return exception;
        }

        public static async Task<TElement> GetElementFromExists<TElement, TKey>(Func<TKey, Task<WasFound<TElement>>> existsAction, TKey keyValue)
        {
            var wasFound = await existsAction(keyValue);
            if(wasFound)
            {
                return wasFound.Result;
            }
            else
            {
                throw RepositoryHelper.GetElementWithKeyNotFoundException<TElement, TKey>(keyValue);
            }
        }
    }
}
