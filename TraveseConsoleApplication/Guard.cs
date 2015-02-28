using System;

namespace ConsoleApplication
{
    public static class Guard
    {
        public static void ArgumentIsNotNull(object value, string argument)
        {
            if (value == null)
                throw new ArgumentNullException(argument);
        }

        public static void StringIsNotNullOrEmpty(string value, string argument)
        {
            if (value == null || string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(argument);
        }
    }
}