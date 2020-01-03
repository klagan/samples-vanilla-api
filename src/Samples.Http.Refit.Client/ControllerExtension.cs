namespace Samples.Http.Client
{
    using Core;
    using System;
    using System.Threading.Tasks;
    using Refit;

    public static class ControllerExtension
    {
        public static async Task<T> RequestAsync<T, TController>(this TController api, Func<TController, Task<T>> action)
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
                throw new Exception($"(HTTP 400) \n\t{string.Join("\n\t", ex.Headers.GetValues(HttpHeaders.ReasonHeader))}");
            }
            catch (ApiException ex) when ((int)ex.StatusCode == 500)
            {
                throw new Exception("(HTTP 500)");
            }
            catch (Exception)
            {
                throw new Exception("you did really bad, man!  You broke it!");
            }
        }
    }
}