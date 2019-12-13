namespace Samples.Http.Client
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Core;

    public class ValuesClient : IValuesClient
    {
        private readonly IValuesController _api;

        private readonly MyToken _token;

        public ValuesClient(IValuesController controller, MyToken token)
        {
            _api = controller;
            _token = token;
        }

        public async Task<IEnumerable<string>> Get()
        {
            return await _api.RequestAsync(controller => controller.Get(_token.Value));
        }

        public async Task<string> Get(int id)
        {
            return await _api.RequestAsync(controller => controller.Get(_token.Value, id));
        }

        public async Task<Person> GetPerson(string firstName)
        {
            return await _api.RequestAsync(controller => controller.GetPerson(_token.Value, firstName));
        }

        // this is explicit and would have to be done on every method if we didn't use the .RequestAsync extension method
        //public async Task<Person> GetPerson(string token, string firstName)
        //{
        //    try
        //    {
        //        return await _api.GetPerson(_cachedToken, firstName);
        //    }
        //    catch (ApiException ex) when ((int) ex.StatusCode == 404)
        //    {
        //        return new Person();
        //        // use a common exception dto model
        //        //var error = await ex.GetContentAsAsync<>();
        //    }
        //    catch (ApiException ex) when ((int) ex.StatusCode == 400)
        //    {
        //        throw new ArgumentException("you done wrong, man!");
        //        // use a common exception dto model
        //        //var error = await ex.GetContentAsAsync<>();
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception("you did really bad, man!  You broke it!");
        //    }
        //}
    }
}