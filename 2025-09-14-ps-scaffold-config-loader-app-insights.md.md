#ps #powershell #template #script-scaffold #config-loader #bootstrap #dotnet #app-insights #az-204

## PowerShell scaffold: config loader + path setup + validation
Purpose: Base pattern for update scripts—resolves repo root, loads `config.ps1`, validates required keys, prints context.

### Snippet
```powershell
# 01-add-application-insights.ps1
# Adds Application Insights to both API and Blazor App projects
# Configures packages, Program.cs files, and appsettings.json for local development

[CmdletBinding()]
param(
    [string]$ConfigPath = $null
)

# Get absolute paths based on script location
$ScriptRoot = Split-Path -Parent $MyInvocation.MyCommand.Path
$RepoRoot = Resolve-Path (Join-Path $ScriptRoot "..\..")

# Set default config path using absolute path
if (-not $ConfigPath) {
    $ConfigPath = Join-Path $RepoRoot "scripts\common\config.ps1"
}

# Load configuration
if (-not (Test-Path $ConfigPath)) {
    Write-Error "Configuration file not found at: $ConfigPath"
    exit 1
}

Write-Host "Loading configuration from: $ConfigPath" -ForegroundColor Green
. $ConfigPath

# Validate required configuration variables from Config object
if (-not $script:Config) {
    Write-Error "Configuration object not found. Ensure config.ps1 exports `$script:Config hashtable."
    exit 1
}

$requiredConfigKeys = @('ApiProjectFolder', 'WebProjectFolder', 'AppInsightsConnectionStringKey')
foreach ($key in $requiredConfigKeys) {
    if (-not $script:Config.ContainsKey($key)) {
        Write-Error "Required configuration key '$key' not found in Config object"
        exit 1
    }
}

# Extract configuration values from the Config object and convert to absolute paths
$ApiProjectFolder = Join-Path $RepoRoot $script:Config.ApiProjectFolder
$WebProjectFolder = Join-Path $RepoRoot $script:Config.WebProjectFolder
$AppInsightsConnectionStringKey = $script:Config.AppInsightsConnectionStringKey
$BuildConfiguration = $script:Config.BuildConfiguration

# Set default package version if not specified in config
$AppInsightsPackageVersion = if ($script:Config.ContainsKey('AppInsightsPackageVersion')) { 
    $script:Config.AppInsightsPackageVersion 
} else { 
    "2.22.0" 
}

Write-Host "=== Adding Application Insights to .NET 9 Solution ===" -ForegroundColor Cyan
Write-Host "Repository Root: $RepoRoot" -ForegroundColor Gray
Write-Host "API Project: $ApiProjectFolder" -ForegroundColor Yellow
Write-Host "Web Project: $WebProjectFolder" -ForegroundColor Yellow
Write-Host "Package Version: $AppInsightsPackageVersion" -ForegroundColor Yellow
```
