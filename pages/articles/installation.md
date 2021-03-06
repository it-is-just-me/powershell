# Installing PnP PowerShell

You can run the following commands to install the PowerShell cmdlets:

```powershell
Install-Module -Name "PnP.PowerShell" -AllowPrerelease
```

This will work on Windows / Linux / MacOS.

## Using PnP PowerShell in the Azure Cloud Shell

Open the Azure Cloud Shell at https://shell.azure.com

Select PowerShell as your shell and enter

```powershell
Install-Module -Name "PnP.PowerShell" -AllowPrerelease
```

As the Azure Cloud Shell retains its settings and installed modules, the next time you open the Azure Cloud Shell PnP PowerShell will be available for you to use.