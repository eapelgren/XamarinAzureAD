param (
<<<<<<< HEAD
    [string]$server = "http://microsoft-apiappc1f91447b91f4dc3834cbde4fca6a49c.azurewebsites.net/"
=======
    [string]$server = "https://microsoft-apiapp745d3ca9013d4894bebef4e0a6f85f8e.azurewebsites.net"
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
)
 
# Download swagger metadata
Invoke-WebRequest $server/swagger/docs/v1  -OutFile EntitiesSwagger.json
 
# Generates REST client
<<<<<<< HEAD
..\..\packages\AutoRest.0.9.7\tools\Autorest.exe -Input EntitiesSwagger.json -Namespace XamarinAzureAD.RestServices.XlentRestService -OutputDirectory RestServices/Entities -CodeGenerator CSharp -ClientName XlentRestClient
=======
..\..\packages\AutoRest.0.9.7\tools\Autorest.exe -Input EntitiesSwagger.json -Namespace MobileApi.RestServices.SipEntities -OutputDirectory RestServices/SipEntities -CodeGenerator CSharp -ClientName SipEntitiesClient
>>>>>>> b8b21d09c1adf0a6f1affae1746fb8b84f7e688d
