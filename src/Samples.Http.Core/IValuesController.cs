namespace Samples.Http.Core
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Refit;

    public interface IValuesController
    {
        [Get("/api/values/getPerson/{firstName}")]
        Task<Person> GetPerson([Header("Authorization")]string token, string firstName);

        //[Delete("api/values/{id}")]
        //Task Delete([Header("Authorization")]string token, int id);

        [Get("/api/values/get")]
        Task<IEnumerable<string>> Get([Header("Authorization")]string token);

        [Get("/api/values/get/{id}")]
        Task<string> Get([Header("Authorization")]string token, int id);
    }
}