﻿function Sync (
    [Parameter(Position=0,Mandatory=1)]
    [string]$transport,
    [Parameter(Position=1,Mandatory=1)]
    [string]$connectionString
)
{
    robocopy Messaging.SqlServer Messaging.$transport /MIR /FFT /Z /XA:H /W:5 /xf packages.config
	Rename-Item Messaging.$transport\Messaging.SqlServer.sln Messaging.$transport.sln
    
    (dir -Path .\Messaging.$transport -Filter *.config -Recurse) | foreach {  
        Replace $_.FullName "Data Source=\.\\SQLEXPRESS;Initial Catalog=nservicebus;Integrated Security=True" $connectionString
    }
        
    Replace "Messaging.$transport\MyWebClient\Global.asax.cs" "UseTransport<SqlServer>" "UseTransport<$transport>"
    
    (dir -Path .\Messaging.$transport -Filter EndpointConfig.cs -Recurse) | foreach {  
        Replace $_.FullName "SqlServer" $transport
    }
    
    (dir -Path .\Messaging.$transport -Filter *.csproj -Recurse) | foreach {  
        ..\tools\scripts\SyncSamples\msxsl.exe $_.FullName ..\tools\scripts\SyncSamples\TransformProj.xslt -o $_.FullName fileName=$script:baseDir\$transport.xml
    
        Replace $_.FullName "xmlns="""""
	}
}

function Replace(
    [Parameter(Position=0,Mandatory=1)]
    [string]$filename,
    [Parameter(Position=1,Mandatory=1)]
    [string]$find,
    [Parameter(Position=2,Mandatory=0)]
    [string]$replace = ""
)
{
    (Get-Content $filename) | 
    Foreach-Object {
        $_ -replace $find, $replace
    } | 
    Set-Content $filename
}

$script:baseDir = Split-Path (Resolve-Path $MyInvocation.MyCommand.Path)
cd $script:baseDir
cd ..\..\..\Samples
Sync -transport "RabbitMQ" -connectionString "host=localhost"
Sync -transport "Msmq" -connectionString "cache=true"
Sync -transport "ActiveMQ" -connectionString "activemq:tcp://localhost:61616"