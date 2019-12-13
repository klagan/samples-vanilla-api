﻿namespace Samples.Http.Client
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class RunExamples
    {
        private readonly IValuesClient _client;

        public RunExamples(IValuesClient client)
        {
            _client = client;
        }

        public async Task ExecuteAsync()
        {
            // get list through vanilla client
            var result = await _client.Get();
            Console.WriteLine($"result => {result.Count()} items returned");


            // get kam through vanilla client
            var person = await _client.GetPerson("Kam");
            Console.WriteLine($"result => {person.FirstName} {person.LastName}");


            // get kam through a client that handles exceptions generically
            person = await _client.GetPerson( "Kam");
            Console.WriteLine($"result (handled) => {person.FirstName} {person.LastName}");


            // get 404 through a client that handles exceptions generically
            person = await _client.GetPerson("none");
            Console.WriteLine($"result (handled) => Person is null => {person == null}");


            // explicitly handle an exception (dont want to do this - just an example)
            try
            {
                await _client.GetPerson("throw");
            }
            catch
            {
                Console.WriteLine("exception caught and handled");
            }
        }
    }
}