//using BookStore.Domain.BaseTypes;
//using BookStore.WebApi.Extensions;
//using BookStore.WebApi.Responses;
//using BookStore.WebApi.Shared;
//using Microsoft.AspNetCore.Mvc.Filters;
//using System.Reflection;

//namespace BookStore.WebApi.ActionFilters
//{
//    public class ResultFilter : IActionFilter
//    {

//        private readonly IPropertyChecker propertyChecker;
//        public ResultFilter(IPropertyChecker propertyChecker)
//        {
//            this.propertyChecker = propertyChecker;
//        }
//        public void OnActionExecuting(ActionExecutingContext context)
//        {
//        }

//        public void OnActionExecuted(ActionExecutedContext context)
//        {
//            if (context.Result is ObjectResult objectResult && objectResult.Value is not null)
//            {
//                var resultType = objectResult.Value.GetType();
                
//                if (resultType.IsGenericType && resultType.GetGenericTypeDefinition() == typeof(Result<>))
//                {
//                    var genericArgument = resultType.GetGenericArguments().First();
//                    var handler = typeof(ResultFilter).GetMethods(
//                        BindingFlags.NonPublic | BindingFlags.Instance
//                    ).First(x => x.Name == nameof(HandleResult) && x.IsGenericMethodDefinition);

//                    var genericHandler = handler?.MakeGenericMethod(genericArgument);

//                    var result = Convert.ChangeType(objectResult.Value, typeof(Result<>).MakeGenericType(genericArgument));

//                    var objectFieldsProperty = resultType.GetProperty(nameof(Result.ObjectFields));
//                    var objectFieldsValue = objectFieldsProperty?.GetValue(result);

//                    var linksProperty = resultType.GetProperty(nameof(Result.Links));
//                    var linksValue = linksProperty?.GetValue(result);

//                    context.Result = (IActionResult?)genericHandler?.Invoke(this, [result, objectFieldsValue, linksValue]);

//                }
//                else if (objectResult.Value is Result result)
//                {
//                    context.Result = HandleResult(result);
//                }
//            }
//        }

//        private IActionResult HandleResult(Result result)
//        {
//            return result.IsSuccess ? new NoContentResult() : Problem(result);
//        }

//        private IActionResult HandleResult<T>(Result<T> result, string? fields, IEnumerable<LinkDto> links)
//        {
           
//            if (result.IsSuccess)
//            {
//                #region if T is a collection
//                if (typeof(T).IsGenericType && typeof(IEnumerable<>)
//                                        .MakeGenericType(typeof(T).GetGenericArguments().First())
//                                        .IsAssignableFrom(typeof(T)))
//                {

//                    var genericArgument = typeof(T).GetGenericArguments().First();
//                    if (!propertyChecker.TypeHasProperties(genericArgument, fields))
//                    {
//                        var error = Result.Failure(Error.Problem(
//                            "InvalidFields",
//                            "Some fields requested for data shaping does not exist."
//                        ));

//                        return Problem(error);
//                    }

//                    var shapeDataMethod = typeof(IEnumerableExtensions).GetMethod(
//                                                    nameof(IEnumerableExtensions.ShapeData), 
//                                                    BindingFlags.Public | BindingFlags.Static)
//                                            ?.MakeGenericMethod(genericArgument);

//                    if (shapeDataMethod is not null)
//                    {
//                        var shapedData = shapeDataMethod.Invoke(null, [result.Value, fields]);

//                        var returnData = new
//                        {
//                            value = shapedData,
//                            links = links
//                        };
                        
//                        return new OkObjectResult(returnData);
                        
//                        //var resultWithLinks = resultToReturn?.Select(expando =>
//                        //{
//                        //    var dict = (IDictionary<string, object?>)expando;
//                        //    dict.Add("links", links);
//                        //    return dict;
//                        //}).ToList();

//                    }
//                    else
//                    {
//                        var error = Result.Failure(Error.Problem(
//                            "ShapeDataMissing",
//                            "ShapeData extension method could not be found."
//                        ));
//                        return Problem(error);
//                    }

//                }
//                #endregion

//                #region T is not a collection

//                if (!propertyChecker.TypeHasProperties<T>(fields))
//                {
//                    var error = Result.Failure(Error.Problem(
//                        "InvalidFields",
//                        "Some fields requested for data shaping does not exist."
//                    ));

//                    return Problem(error);
//                }

//                var dataToReturn = result.Value.ShapeData(fields) as IDictionary<string, object?>;
//                dataToReturn.Add("links", links);

//                return new OkObjectResult(dataToReturn);
//                #endregion
//            }

//            return Problem(result);
//        }

        
//    }
//}
