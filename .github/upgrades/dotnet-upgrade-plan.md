# .NET 10 Upgrade Plan

## Execution Steps

Execute steps below sequentially one by one in the order they are listed.

1. Validate that a .NET 10 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 10 upgrade.
3. Upgrade AFK Assist.csproj

## Settings

This section contains settings and data used by execution steps.

### Project upgrade details

This section contains details about each project upgrade and modifications that need to be done in the project.

#### AFK Assist.csproj modifications

Project conversion:
  - Project file needs to be converted from .NET Framework format to SDK-style format

Project properties changes:
  - Target framework should be changed from `net481` to `net10.0-windows`

Other changes:
  - Windows Forms application will be migrated to modern .NET
  - All Windows Forms features including SendKeys will continue to work
  - Project will use modern SDK-style project format
