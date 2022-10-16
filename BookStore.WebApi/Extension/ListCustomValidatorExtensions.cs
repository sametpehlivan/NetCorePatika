using BookStore.WebApi.Entities;
using FluentValidation;

namespace BookStore.WebApi.Extensions;

public static class ListCustomValidatorExtensions
{
    public static IRuleBuilderOptions<T, IList<TElement>> ListMustContainMoreThan<T,TElement>(this IRuleBuilder<T, IList<TElement>> ruleBuilder , int num)
    {
        return ruleBuilder.Must(list => list.Count > num);
    }
    
}