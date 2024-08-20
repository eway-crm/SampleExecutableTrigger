using Newtonsoft.Json.Linq;
using System;
using System.Reflection;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Guid itemGuid = new Guid(args[1]);

                // Build app name
                var assemblyName = Assembly.GetExecutingAssembly().GetName();
                string appIdentifier = $"{assemblyName.Name}-v{assemblyName.Version.Major}.{assemblyName.Version.Minor}";

                // Create connection
                var connection = new eWayCRM.API.Connection("https://localhost/eWayWSImpala", "api", null, appIdentifier: appIdentifier, accessToken: args[0]);

                Logger.LogDebug($"Adding Note to journal '{itemGuid}'");

                // Save "Hello World!" to journal note
                connection.CallMethod("SaveJournal", JObject.FromObject(new
                {
                    transmitObject = new
                    {
                        ItemGUID = itemGuid,
                        Note = "Hello World!"
                    }
                }));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"ExecutableTrigger failed with exception: {ex.Message}");
            }
        }
    }
}