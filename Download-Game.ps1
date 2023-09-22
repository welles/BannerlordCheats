Param(
    [Parameter(Mandatory = $False)]
    [ValidateSet("stable", "beta")]
    [String]
    $Branch = "stable"
)

$DepotVersion = Get-Content $PWD\Directory.Build.props | Select-String -Pattern "<DepotName>([\w.-]+)<\/DepotName>" | ForEach-Object { $($_.Matches.Groups[1]).Value }

$GameDirectory = If ($Branch -eq "stable") { "bannerlord-stable" } ElseIf ($Branch -eq "beta") { "bannerlord-beta" } Else { throw "Invalid branch name!" }

$SteamCmdUrl = "https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip";

Write-Host "Downloading game for branch [$Branch ($DepotVersion)] into [$GameDirectory]" -ForegroundColor Cyan

Write-Host "Checking if SteamCMD is installed... " -NoNewline

If (!(Test-Path "$PWD\bin"))
{
    New-Item -Path "$PWD\bin" -Type Directory | Out-Null
}

If (Test-Path "$PWD\bin\steamcmd\steamcmd.exe")
{
    Write-Host "[OK]" -ForegroundColor Green
}
Else
{
    Write-Host "[Not found]" -ForegroundColor Yellow

    Write-Host "Downloading SteamCMD... " -NoNewline

    Invoke-WebRequest -Uri $SteamCmdUrl -OutFile "$PWD\bin\steamcmd.zip" -ErrorAction Stop

    Write-Host "[OK]" -ForegroundColor Green

    Write-Host "Extracting SteamCMD... " -NoNewline

    Expand-Archive -Path "$PWD\bin\steamcmd.zip" -DestinationPath "$PWD\bin\steamcmd" -ErrorAction Stop

    Write-Host "[OK]" -ForegroundColor Green
}

Write-Host "Checking if SteamCMD credentials are there... " -NoNewline

If (Test-Path "$PWD\bin\steamcmd\credentials.txt")
{
    $Credentials = (Get-Content "$PWD\bin\steamcmd\credentials.txt").Split(" ")

    Write-Host "[OK]" -ForegroundColor Green
}
Else
{
    Write-Host "[Not found! Add to `"$PWD\bin\steamcmd\credentials.txt`"]" -ForegroundColor Red

    Return
}

&"$PWD\bin\steamcmd\steamcmd.exe" +force_install_dir "$PWD\bin\$GameDirectory" +login $Credentials[0] $Credentials[1] "+app_update 261550 -beta $DepotVersion validate" +quit
