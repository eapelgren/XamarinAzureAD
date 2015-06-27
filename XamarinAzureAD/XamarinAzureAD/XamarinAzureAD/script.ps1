param (
    [string]$server = "http://microsoft-apiappc1f91447b91f4dc3834cbde4fca6a49c.azurewebsites.net/"
)
 
# Download swagger metadata
Invoke-WebRequest $server/swagger/docs/v1  -OutFile EntitiesSwagger.json
 
# Generates REST client
..\..\packages\AutoRest.0.9.7\tools\Autorest.exe -Input EntitiesSwagger.json -Namespace XamarinAzureAD.RestServices.XlentRestService -OutputDirectory RestServices/Entities -CodeGenerator CSharp -ClientName XlentRestClient