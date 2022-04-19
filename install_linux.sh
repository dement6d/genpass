#!/bin/bash

cd src
dotnet publish -c Release -r linux-x64 -p:PublishSingleFile=true --self-contained true

sudo mv bin/Release/net6.0/linux-x64/publish/genpass /usr/bin/
sudo chmod +x /usr/bin/genpass

sudo bash -c "echo $'[Desktop Entry]\nName=genpass\nGenericName=Simple Passoworld Genrater\nExec=/usr/bin/genpass\nTerminal=true\nType=Application\nCategories=Utility;\nIcon=genpass\nPath=/usr/bin' > /usr/share/applications/genpass.desktop"

echo ""
echo "genpass installed in /usr/bin/genpass"
