& cd Preparation.ConsoleApp
Write-Host "Restoring Packages"
& dotnet restore
Write-Host "Builing preparation app"
& dotnet build
Write-Host "Running preparation app"
& dotnet run -- -t "$PSScriptRoot/Preparation.ConsoleApp/template.json" -o "$PSScriptRoot/Automation.ConsoleApp/Services/AutomationService.cs" -d "$PSScriptRoot"
& cd ..
& dotnet restore
& dotnet build
& cd Automation.ConsoleApp