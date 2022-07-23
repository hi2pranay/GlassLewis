# GlassLewis
# Database Scripts
1.	Execute below scripts in Sql server and change the connection string in “appsettings.json”

Connectionstring : Data Source={servername};Initial Catalog=GlassLewisDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False

2.	Create database GlassLewisDB;
3.	UserInfo script

CREATE TABLE [dbo].[UserInfo] (
    [UserId]   INT            IDENTITY (1, 1) NOT NULL,
    [Email]    NVARCHAR (MAX) NOT NULL,
    [Password] NVARCHAR (MAX) NOT NULL);

Insert into [dbo].[UserInfo](Email,Password) values('User1@abc.com','123456');
Insert into [dbo].[UserInfo](Email,Password) values('User2@abc.com','123456');
Insert into [dbo].[UserInfo](Email,Password) values('User3@abc.com','123456');

3.  Company Script 

 CREATE TABLE [dbo].[Company] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (MAX) NOT NULL,
    [Exchange] NVARCHAR (MAX) NOT NULL,
    [Ticker]   NVARCHAR (MAX) NOT NULL,
    [ISIN]     NVARCHAR (MAX) NOT NULL,
    [Website]  NVARCHAR (MAX) NOT NULL
);

INSERT INTO [dbo].[Company](Name,Exchange,Ticker,ISIN,Website) values('Apple Inc.','NASDAQ','AAPL','US0378331005','http://www.apple.com');

INSERT INTO [dbo].[Company](Name,Exchange,Ticker,ISIN,Website) values('British Airways Plc.','Pink Sheets','BAIRY','US1104193065','');

INSERT INTO [dbo].[Company](Name,Exchange,Ticker,ISIN,Website) values('Heineken NV','Euronext Amsterdam','HEIA','NL0000009165','');

INSERT INTO [dbo].[Company](Name,Exchange,Ticker,ISIN,Website) values('Panasonic Corp','Tokyo Stock Exchange','6752','JP3866800000','http://www.panasonic.co.jp');

INSERT INTO [dbo].[Company](Name,Exchange,Ticker,ISIN,Website) values('Porsche Automobil','Deutsche Börse','PAH3','DE000PAH0038','https://www.porsche.com/');

 ———————————————————— Or ——————————————————————

# Visual Studio Database Entity Framework
1.	Open Visual Studio 2022 and open Tools menu—> “Nuget Package Manager” —> “Package Manager Console”
2.	In “Package Manager Console” —> In “Default Project” select “GlassLewis.Infrastructure” project and execute below commands
 a. Add-Migration InitialCreate
 b. update-database -verbose
3. Run the Api project by clicking f5

# UI
1.	Open glasslewis-ui folder in Visual studio code
2.	In terminal type “npm start”

Enter below details
Email : user1@abc.com
Password : 123456



