namespace Samples.Http.Client
{
    using System;
    using System.Threading.Tasks;
    using Refit;
    using Core;

    public static class ValuesControllerExtension
    {
        public static async Task<T> RequestAsync<T>(this IValuesController api, Func<IValuesController, Task<T>> action)
        {
            try
            {
                return await action.Invoke(api);
            }
            catch (ApiException ex) when ((int) ex.StatusCode == 404)
            {
                return default;
            }
            catch (ApiException ex) when ((int) ex.StatusCode == 400)
            {
                throw new ArgumentException("you done wrong, man!");
            }
            catch (Exception)
            {
                throw new Exception("you did really bad, man!  You broke it!");
            }
        }
    }
}