---
applicable: SharePoint Online
external help file: PnP.PowerShell.dll-Help.xml
Module Name: PnP.PowerShell
online version: https://docs.microsoft.com/powershell/module/sharepoint-pnp/grant-pnptenantserviceprincipalpermission
schema: 2.0.0
title: Grant-PnPTenantServicePrincipalPermission
---

# Grant-PnPTenantServicePrincipalPermission

## SYNOPSIS

**Required Permissions**

* SharePoint: Access to the SharePoint Tenant Administration site
* Microsoft Graph API : Directory.ReadWrite.All

Explicitly grants a specified permission to the "SharePoint Online Client Extensibility Web Application Principal" service principal for SPFx solutions.

## SYNTAX

```powershell
Grant-PnPTenantServicePrincipalPermission -Scope <String> [-Resource <String>] [-Connection <PnPConnection>]
 [<CommonParameters>]
```

## DESCRIPTION

## EXAMPLES

### EXAMPLE 1
```powershell
Grant-PnPTenantServicePrincipalPermission -Scope "Group.Read.All"
```

This will explicitly grant the Group.Read.All permission on the Microsoft Graph resource

## PARAMETERS

### -Scope
The scope to grant the permission for

```yaml
Type: String
Parameter Sets: (All)

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Resource
The resource to grant the permission for. Defaults to "Microsoft Graph"

```yaml
Type: String
Parameter Sets: (All)

Required: True
Position: Named
Default value: Microsoft Graph
Accept pipeline input: False
Accept wildcard characters: False
```

### -Connection
Optional connection to be used by the cmdlet. Retrieve the value for this parameter by either specifying -ReturnConnection on Connect-PnPOnline or by executing Get-PnPConnection.

```yaml
Type: PnPConnection
Parameter Sets: (All)

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## RELATED LINKS

[Microsoft 365 Patterns and Practices](https://aka.ms/m365pnp)