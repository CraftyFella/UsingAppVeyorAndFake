 $webclient = New-Object Net.WebClient
 $webclient.Proxy = [Net.WebRequest]::DefaultWebProxy
 $webClient.Proxy.Credentials = [Net.CredentialCache]::DefaultCredentials
 $webclient.DownloadFile('https://nuget.org/nuget.exe', 'tools\nuget.exe')