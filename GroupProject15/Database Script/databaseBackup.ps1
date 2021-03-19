docker stop custdb
docker rm custdb
docker stop MyLocalRegistry
docker rm MyLocalRegistry
docker pull mcr.microsoft.com/mssql/server:2019-latest
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Kgt25%a8" -p 1433:1433  --name custdb -d mcr.microsoft.com/mssql/server:2019-latest
docker exec -u 0 -it custdb mkdir /backups
cd "C:\Users\George\Documents\University\Group Design Practical\db_backup"
docker cp testdb.bak custdb:/backups
Start-Sleep -Seconds 30
docker exec -it custdb /opt/mssql-tools/bin/sqlcmd -S "localhost" -U "SA" -P "Kgt25%a8" `
-Q `
@"
 RESTORE DATABASE testdb FROM DISK = '/backups/testdb.bak' 
         WITH MOVE 'testdb' TO '/var/opt/mssql/data/testdb.mdf', 
              MOVE 'testdb_log' TO '/var/opt/mssql/data/testdb_Log.ldf'
"@
docker run -d -p 5000:5000  --restart=always --name MyLocalRegistry registry:2
docker commit custdb MyLocalRegistry:5000/custdb-image