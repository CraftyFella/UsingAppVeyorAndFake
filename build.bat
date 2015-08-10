@echo off
if not exist tools md tools
tools\nuget > NUL
if not %errorlevel% EQU 0 (
	echo "Installing nuget..."
    powershell Set-ExecutionPolicy RemoteSigned
	powershell .\installNuget.ps1
)
if not exist tools\fake tools\nuget install Fake -OutputDirectory tools -ExcludeVersion
if not exist tools\nunit.runners tools\nuget install nunit.runners -OutputDirectory tools -ExcludeVersion
tools\fake\tools\fake %*