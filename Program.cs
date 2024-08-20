using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello World!");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"ExecutableTrigger failed with exception: {ex.Message}");
            }
        }
    }
}