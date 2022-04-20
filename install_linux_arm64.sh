#!/bin/bash

cd src
dotnet publish -c Release -r linux-arm64 -p:PublishSingleFile=true --self-contained true
sudo mv bin/Release/net6.0/linux-arm64/publish/genpass /usr/bin/
sudo chmod +x /usr/bin/genpass