namespace Samples.Http.Core
{
    public static class Http400Reasons
    {
        public static string ArgumentMissing => "Parameter value was missing in request";

        public static string ArgumentOutOfRange => "Parameter value was out of range in request";

        public static string ArgumentErrorTest1 => "my custom header message - love kam";

        public static string ArgumentErrorTest2 => "another customer header message - love kam";
    }
}