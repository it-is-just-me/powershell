---
applicable: SharePoint Online
external help file: PnP.PowerShell.dll-Help.xml
Module Name: PnP.PowerShell
online version: https://docs.microsoft.com/powershell/module/sharepoint-pnp/remove-pnpuser
schema: 2.0.0
title: Remove-PnPUser
---

# Remove-PnPUser

## SYNOPSIS
Removes a specific user from the site collection User Information List

## SYNTAX

```powershell
Remove-PnPUser [-Identity] <UserPipeBind> [-Force]  [-Web <WebPipeBind>]
 [-Connection <PnPConnection>] [<CommonParameters>]
```

## DESCRIPTION
This command will allow the removal of a specific user from the User Information List

## EXAMPLES

### EXAMPLE 1
```powershell
Remove-PnPUser -Identity 23
```

Remove the user with Id 23 from the User Information List of the current site collection

### EXAMPLE 2
```powershell
Remove-PnPUser -Identity i:0#.f|membership|user@tenant.onmicrosoft.com
```

Remove the user with LoginName i:0#.f|membership|user@tenant.onmicrosoft.com from the User Information List of the current site collection

### EXAMPLE 3
```powershell
Get-PnPUser | ? Email -eq "user@tenant.onmicrosoft.com" | Remove-PnPUser
```

Remove the user with e-mail address user@tenant.onmicrosoft.com from the User Information List of the current site collection

### EXAMPLE 4
```powershell
Remove-PnPUser -Identity i:0#.f|membership|user@tenant.onmicrosoft.com -Confirm:$false
```

Remove the user with LoginName i:0#.f|membership|user@tenant.onmicrosoft.com from the User Information List of the current site collection without asking to confirm the removal first

## PARAMETERS

### -Confirm
Specifying the Confirm parameter will allow the confirmation question to be skipped

```yaml
Type: SwitchParameter
Parameter Sets: (All)

Required: False
Position: Named
Default value: None
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

### -Force
Specifying the Force parameter will skip the confirmation question

```yaml
Type: SwitchParameter
Parameter Sets: (All)

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity
User ID or login name

```yaml
Type: UserPipeBind
Parameter Sets: (All)

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Web
This parameter allows you to optionally apply the cmdlet action to a subweb within the current web. In most situations this parameter is not required and you can connect to the subweb using Connect-PnPOnline instead. Specify the GUID, server relative url (i.e. /sites/team1) or web instance of the web to apply the command to. Omit this parameter to use the current web.

```yaml
Type: WebPipeBind
Parameter Sets: (All)

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## RELATED LINKS

[Microsoft 365 Patterns and Practices](https://aka.ms/m365pnp)