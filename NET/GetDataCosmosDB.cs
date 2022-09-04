using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Personal_AzureFunctions
{
    public static partial class GetDataCosmosDB
    {
        public class CosmosDBConfig
        {
            public string endpointUri { get; set; } = GetDataCosmosDB.endpointUri;
            public string primaryKey { get; set; } = GetDataCosmosDB.primaryKey;
            public string databaseId { get; set; }
            public string containerId { get; set; }
            public string itemId { get; set; }
        }

        [FunctionName("GetDataCosmosDB")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function , "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            /*log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);*/


            /*//configurations
            const string _endpointUri = "https://mcosmos02.documents.azure.com:443/";
            const string _primaryKey =
                "pzhBpx3tYCnhq4l4uSrGJw6NNvZpzDNZgTi5BcHFtPVn5fCledqrQ9RQVRJP07qEN96Rd3DieTV4R1gWL6a6NQ==";
            const string _databaseId = "portfolio";
            const string _containerId = "mohammad-a-immam";*/


            try
            {

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                CosmosDBConfig config = JsonConvert.DeserializeObject<CosmosDBConfig>(requestBody);
                using (CosmosClient client = new CosmosClient(config.endpointUri, config.primaryKey))
                {
                    var database = client.GetDatabase(config.databaseId);
                    var container = database.GetContainer(config.containerId);
                    var data = await container.ReadItemAsync<object>(config.itemId, new PartitionKey(config.itemId));
                    Console.WriteLine(data);
                    return new OkObjectResult(data.Resource);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new BadRequestObjectResult(e.Message);
            }
        }
    }
}
