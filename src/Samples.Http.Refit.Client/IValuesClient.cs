using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using Samples.Http.Core;

namespace Samples.Http.Client
{
    public interface IValuesClient// : IValuesController
    {
        Task<Person> GetPerson(string firstName);

        //[Delete("api/values/{id}")]
        //Task Delete([Header("Authorization")]string token, int id);

        Task<IEnumerable<string>> Get();

        Task<string> Get(int id);
    }
}