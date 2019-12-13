namespace Samples.Http.Client
{
    public class MyToken
    {

        public static implicit operator MyToken(string token)
        {
            return new MyToken {Value = token};
        }

        public string Value { get; private set; }
    }
}