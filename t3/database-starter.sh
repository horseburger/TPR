#!/bin/bash
sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Passw0rd" \
   -p 127.0.0.1:1433:1433 --name sql1 \
   -d mcr.microsoft.com/mssql/server:2019-GA-ubuntu-16.04

echo "password: Passw0rd"
