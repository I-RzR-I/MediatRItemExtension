$projects = @(
    "..\src\MediatRItemExtensionV2K19\MediatRItemExtensionV2K19.csproj",
    "..\src\MediatRItemExtensionV2K19\MediatRItemExtensionV2K22.csproj"
)

$vswhere = "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe"

$msbuild = & $vswhere -latest -requires Microsoft.Component.MSBuild `
    -find MSBuild\**\Bin\MSBuild.exe
	
foreach ($proj in $projects) {
	Write-Host "Build in 'Release' mode. Project: " $proj
    & $msbuild $proj /t:Restore,Build /p:Configuration=Release
}