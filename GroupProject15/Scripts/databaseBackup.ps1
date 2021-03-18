docker stop custdb
docker rm custdb
docker stop MyLocalRegistry
docker rm MyLocalRegistry
docker pull microsoft/mssql-server-linux:latest
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Kgt25%a8" -p 1433:1433  --name custdb -d microsoft/mssql-server-linux:latest
docker exec -it custdb mkdir /backups
cd d:\GroupDesignProject\BackupFiles
docker cp todoDatabase.bak custdb:/backups
docker exec -it custdb /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "Kgt25%a8" `
-Q `
@"
 RESTORE DATABASE TodoDatabase FROM DISK = '/backups/todoDatabase.bak' 
         WITH MOVE 'Todo' TO '/var/opt/mssql/data/TodoDatabase.mdf', 
              MOVE 'Todo_log' TO '/var/opt/mssql/data/TodoDatabase_Log.ldf'
"@
docker run -d -p 5000:5000  --restart=always --name MyLocalRegistry registry:2
docker commit custdb MyLocalRegistry:5000/custdb-image