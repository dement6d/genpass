#!/bin/bash

cd src
dotnet publish -c Release -r linux-x64 -p:PublishSingleFile=true --self-contained true

sudo mv bin/Release/net6.0/linux-x64/publish/genpass /usr/bin/
sudo chmod +x /usr/bin/genpass
echo ""
echo "genpass installed in /usr/bin/genpass"
