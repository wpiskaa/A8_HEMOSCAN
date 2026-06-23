; Script untuk Inno Setup Compiler
; Mengemas berkas biner HemoScan (Release mode), dependensi EPPlus, dan skrip SQL setup.

#define MyAppName "HemoScan"
#define MyAppVersion "1.2"
#define MyAppPublisher "Kelompok A8 PABD - UCP 3"
#define MyAppExeName "HemoScan.exe"

[Setup]
; Gunakan GUID project id HemoScan
AppId={{18BD8EDD-A2F2-4DC0-8F49-5FE9769B8E35}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppVerName={#MyAppName} v{#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\{#MyAppName}
DisableProgramGroupPage=yes
; Output disimpan ke subfolder Output di dalam project
OutputDir=d:\KULIAH\Semester4\Project PABD\UCP\A8_HEMOSCAN\HemoScan\Output
OutputBaseFilename=HemoScan_Setup_v1.2
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "d:\KULIAH\Semester4\Project PABD\UCP\A8_HEMOSCAN\HemoScan\bin\Release\HemoScan.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "d:\KULIAH\Semester4\Project PABD\UCP\A8_HEMOSCAN\HemoScan\bin\Release\EPPlus.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "d:\KULIAH\Semester4\Project PABD\UCP\A8_HEMOSCAN\HemoScan\HemoScan_SQL_Setup.sql"; DestDir: "{app}\SQL"; Flags: ignoreversion
Source: "d:\KULIAH\Semester4\Project PABD\UCP\A8_HEMOSCAN\HemoScan\HemoScan_DataDummy.sql"; DestDir: "{app}\SQL"; Flags: ignoreversion

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent
