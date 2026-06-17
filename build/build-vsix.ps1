$projects = @(
    "$PSScriptRoot\..\src\MediatRItemExtensionV2K19\MediatRItemExtensionV2K19.csproj",
    "$PSScriptRoot\..\src\MediatRItemExtensionV2K22\MediatRItemExtensionV2K22.csproj"
)

$vswhere = "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe"

$msbuild = & $vswhere -latest -requires Microsoft.Component.MSBuild `
    -find MSBuild\**\Bin\MSBuild.exe

$vsixDestDir = "$PSScriptRoot\..\vsix"
New-Item -ItemType Directory -Force -Path $vsixDestDir | Out-Null

foreach ($proj in $projects) {
    Write-Host "Build in 'Release' mode. Project: " $proj
    & $msbuild $proj /t:Restore,Build /p:Configuration=Release

    if ($LASTEXITCODE -ne 0) {
        Write-Error "Build failed for project: $proj (exit code $LASTEXITCODE). Skipping copy."
        continue
    }

    $projectName  = [System.IO.Path]::GetFileNameWithoutExtension($proj)
    $manifestPath = "$PSScriptRoot\..\src\$projectName\source.extension.vsixmanifest"

    $nsManager = New-Object System.Xml.XmlNamespaceManager((New-Object System.Xml.NameTable))
    $nsManager.AddNamespace("vsx", "http://schemas.microsoft.com/developer/vsx-schema/2011")

    $xmlDoc = New-Object System.Xml.XmlDocument
    $xmlDoc.Load($manifestPath)
    $identityNode = $xmlDoc.SelectSingleNode("/vsx:PackageManifest/vsx:Metadata/vsx:Identity", $nsManager)
    $version = $identityNode.GetAttribute("Version")

    $builtVsix = "$PSScriptRoot\..\src\$projectName\bin\Release\$projectName.vsix"

    if (-not (Test-Path $builtVsix)) {
        Write-Error "Built .vsix not found at '$builtVsix'. Skipping copy."
        continue
    }

    $destName = "${projectName}_v${version}.vsix"
    $destPath = Join-Path $vsixDestDir $destName

    Write-Host "Copying '$builtVsix' -> '$destPath'"
    Copy-Item -Path $builtVsix -Destination $destPath -Force
}
