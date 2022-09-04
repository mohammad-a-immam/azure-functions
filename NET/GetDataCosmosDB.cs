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
