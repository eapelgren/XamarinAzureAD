param (
    [string]$server = "https://microsoft-apiapp745d3ca9013d4894bebef4e0a6f85f8e.azurewebsites.net"
)
 
# Download swagger metadata
Invoke-WebRequest $server/swagger/docs/v1  -OutFile EntitiesSwagger.json
 
# Generates REST client
..\..\packages\AutoRest.0.9.7\tools\Autorest.exe -Input EntitiesSwagger.json -Namespace XamarinAzureAD.RestServices.SipEntities -OutputDirectory RestServices/SipEntities -CodeGenerator CSharp -ClientName SipEntitiesClient