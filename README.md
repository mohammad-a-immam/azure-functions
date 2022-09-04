# Azure Functions
My custom Azure functions hosted for achieving different purpose. These public repositories have sensative details like access keys and secrets hidden. If reusing these functions, please follow instructions to replace them with your own secrets. These are reusable code to customize and deploy own azure functions.

## NodeJS Functions


**1. GitHub OAuth Helper**

### Directory
/NodeJS/GitAccessToken/index.example.html

### Summary/Purpose
GitHub OAuth Code Grant flow does not allow oauth authentication through front end frameworks. In other words, after the authentication code is received from github after a user signs up through the GitHub sign in UI, cannot be exchanged for an access token when the exchange request is made by a browser. GitHub's CORS policy will block it. This azure nodejs function takes in the code received from github and exchanges and returns and access token from the provider.

### Instructions to reuse
- Register for a GitHub OAuth app. https://github.com/settings/developers.
- In index.example.js, replace client_id and client_secret with your own credentials.
- rename index.example.js to index.js without changing the directory.
- Use your preferred method to test and deploye the nodejs azure function to portal.
    - https://acloudguru.com/hands-on-labs/deploy-a-function-created-with-azure-functions-core-tools-to-azure
    - https://docs.microsoft.com/en-us/azure/developer/javascript/how-to/develop-serverless-apps
- Use your obtained url to invoke the function as needed.

### Hosted url to invoke:
https://mfunctions-node-01.azurewebsites.net/api/GitAccessToken?code=AZURE_CODE&gitcode=code`
- gitcode: github's provided code
- code: azure's secret authentication code to allow invoking of the function

---