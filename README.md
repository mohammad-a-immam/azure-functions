# Azure Functions
My custom Azure functions hosted for achieving different purpose. These public repositories have sensative details like access keys and secrets hidden. If reusing these functions, please follow instructions to replace them with your own secrets. These are reusable code to customize and deploy own azure functions.

Note: AZURE_FUCNTION_CODE (authentication) codes are intentionally hidden to prevent any unwanted invokes of the azure functions.

## NodeJS Functions


**1. GitHub OAuth Helper**

### Directory
/NodeJS/GitAccessToken/index.example.html

### Summary/Purpose
GitHub OAuth Code Grant flow does not allow oauth authentication through front end frameworks. In other words, after the authentication code is received from github after a user signs up through the GitHub sign in UI, cannot be exchanged for an access token when the exchange request is made by a browser. GitHub's CORS policy will block it. This azure nodejs function takes in the code received from github and exchanges and returns and access token from the provider.

### Node Version
14

### Instructions to reuse
- Register for a GitHub OAuth app. https://github.com/settings/developers.
- In index.example.js, replace client_id and client_secret with your own credentials.
- rename index.example.js to index.js without changing the directory.
- Use your preferred method to test and deploye the nodejs azure function to portal.
    - https://acloudguru.com/hands-on-labs/deploy-a-function-created-with-azure-functions-core-tools-to-azure
    - https://docs.microsoft.com/en-us/azure/developer/javascript/how-to/develop-serverless-apps
- Use your obtained url to invoke the function as needed.

### Hosted url to invoke:
[GET] https://mfunctions-node-01.azurewebsites.net/api/GitAccessToken?code=AZURE_CODE&gitcode=code`

- ash***2@gmail.com
- gitcode: github's provided code
- code: azure's secret authentication code to allow invoking of the function

---


## .NET Functions

**1. GitHub OAuth Helper**

### Directory
/NET/PersonalAzureFunctions/index.example.html

### Summary/Purpose
This function receives a post request with parameters to retrieve and return
data hosted on azure cosmosdb. You can retrieve data from any permitted database by
providing credentials and endpoints in through the body.

### .NET Version
3.1

### Instructions to reuse
- Make sure you have azure functions core-tools.
- Make sure you have azure development tools module installed for visual studio through VS Installer.
- Open the solution with visual studio.
- Open cosmosDb.example.config.cs and replace the placeholder `endpoint` and `primaryKey` with your azure cosmos db credentials and rename the file to `cosmosDb.config.cs`.
- The solution should be ready for debug/publish through.
Note: publishing profile needs to be created through Visual Studio Publish Tool. It will prompt
you to connect to your azure account and select your resources.

### Hosted url to invoke:
https://mfunctions-node-01.azurewebsites.net/api/GitAccessToken?code=AZURE_CODE&gitcode=code`

- ash***2@gmail.com
- gitcode: github's provided code
- code: azure's secret authentication code to allow invoking of the function

[POST] https://mfunctions-net-02.azurewebsites.net/api/GetDataCosmosDB?code=AZURE_FUNCTION_CODE

JSON Request Body Should contain:

    {
        "endpointUri": {cosmosdb database endpoint: backend will default to my database primary key if id is not provided},
        "primaryKey": {cosmosdb primary key: backend will default to my database primary key if id is not provided}
        "databaseId": {cosmosdb database name},
        "containerId":{cosmosdb container name},
        "itemId": {querying item id}
    }
---

**2. AddItemCosmosDbContainer**

### Directory
/NET/PersonalAzureFunctions/AddItemCosmosDbContainer.cs

### Summary/Purpose
This function receives a post request with parameters to add to an azure cosmos db container.

### .NET Version
3.1

### Instructions to reuse
- Make sure you have azure functions core-tools.
- Make sure you have azure development tools module installed for visual studio through VS Installer.
- Open the solution with visual studio.
- Open cosmosDb.example.config.cs and replace the placeholder endpoint and primaryKey with your azure cosmos db credentials and rename the file to cosmosDb.config.cs.
- The solution should be ready for debug/publish through. Note: publishing profile needs to be created through Visual Studio Publish Tool. It will prompt you to connect to your azure account and select your resources.


### Hosted url to invoke:
ash***2@gmail.com

`[POST]` https://mfunctions-node-01.azurewebsites.net/api/AddItemCosmosDbContainer?code=AZURE_CODE&gitcode=code`


        JSON Request Body Should contain:

        {
            "endpointUri": {cosmosdb database endpoint: backend will default to my database primary key if id is not provided},
            "primaryKey": {cosmosdb primary key: backend will default to my database primary key if id is not provided}
            "databaseId": {cosmosdb database name},
            "containerId":{cosmosdb container name},
            "item": {item object to be added to cosmos}
        }
