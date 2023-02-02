
## Reference
https://learn.microsoft.com/en-us/dotnet/core/extensions/windows-service

## Commands

### Publish

dotnet publish --output "C:\custom\publish\directory"

### Create a windows service

sc.exe create ".NET Joke Service" binpath="C:\Path\To\dotnet.exe C:\Path\To\App.WindowsService.dll"
### Start service
sc.exe start ".NET Joke Service"