using System;
using System.Threading.Tasks;

using R5T.Magyar;


namespace R5T.Rochester.Extensions
{
    public static class IRepositoryExtensions
    {
        public static Task<TElement> GetElementFromExists<TElement, TKey>(this IRepository repository, Func<TKey, Task<WasFound<TElement>>> existsAction, TKey keyValue)
        {
            return RepositoryHelper.GetElementFromExists<TElement, TKey>(existsAction, keyValue);
        }
    }
}
