& dotnet restore
& dotnet build
& cd Preparation.ConsoleApp
& dotnet run -t "$PSScriptRoot/Preparation.ConsoleApp/template.json" -o "$PSScriptRoot/Automation.ConsoleApp/Services/AutomationService.cs" -d "$PSScriptRoot"
& cd ..
& dotnet restore
& dotnet build
& cd Automation.ConsoleApp