
if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EngineersClients') and o.name = 'FK_ENGINEER_CLIENTS_E_CLIENTS')
alter table EngineersClients
   drop constraint FK_ENGINEER_CLIENTS_E_CLIENTS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('EngineersClients') and o.name = 'FK_ENGINEER_USERS_ENG_USERS')
alter table EngineersClients
   drop constraint FK_ENGINEER_USERS_ENG_USERS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('InterventionUpdate') and o.name = 'FK_INTERVEN_INTER_INT_INTERVEN')
alter table InterventionUpdate
   drop constraint FK_INTERVEN_INTER_INT_INTERVEN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('InterventionUpdate') and o.name = 'FK_INTERVEN_USERS_INT_USERS')
alter table InterventionUpdate
   drop constraint FK_INTERVEN_USERS_INT_USERS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Interventions') and o.name = 'FK_INTERVEN_CLIENTS_I_CLIENTS')
alter table Interventions
   drop constraint FK_INTERVEN_CLIENTS_I_CLIENTS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Interventions') and o.name = 'FK_INTERVEN_INTERTYPE_INTERVEN')
alter table Interventions
   drop constraint FK_INTERVEN_INTERTYPE_INTERVEN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Interventions') and o.name = 'FK_INTERVEN_INTERVENT_USERS')
alter table Interventions
   drop constraint FK_INTERVEN_INTERVENT_USERS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Clients')
            and   type = 'U')
   drop table Clients
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DataDictionary')
            and   type = 'U')
   drop table DataDictionary
go

if exists (select 1
            from  sysobjects
           where  id = object_id('EngineersClients')
            and   type = 'U')
   drop table EngineersClients
go

if exists (select 1
            from  sysobjects
           where  id = object_id('InterventionType')
            and   type = 'U')
   drop table InterventionType
go

if exists (select 1
            from  sysobjects
           where  id = object_id('InterventionUpdate')
            and   type = 'U')
   drop table InterventionUpdate
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Interventions')
            and   type = 'U')
   drop table Interventions
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Users')
            and   type = 'U')
   drop table Users
go

/*==============================================================*/
/* Table: Clients                                               */
/*==============================================================*/
create table Clients (
   ClientId             int             identity,
   ClientName           nvarchar(512)         null,
   ClientLocation       nvarchar(512)         null,
   ClientDistrict       int                  null,
   constraint PK_CLIENTS primary key (ClientId)
)
go

/*==============================================================*/
/* Table: EngineersClients                                      */
/*==============================================================*/
create table EngineersClients (
   EngineersClientsId   int              identity,
   UserId               nvarchar(128)        null,
   ClientId             int              null,
   CreateDate           datetime             null,
   constraint PK_ENGINEERSCLIENTS primary key (EngineersClientsId)
)
go

/*==============================================================*/
/* Table: InterventionType                                      */
/*==============================================================*/
create table InterventionType (
   InterventionTypeId   int              identity,
   InterventionTypeName nvarchar(512)         null,
   InterventionTypeHours decimal(10,2)              null,
   InterventionTypeCost decimal(10,2)              null,
   constraint PK_INTERVENTIONTYPE primary key (InterventionTypeId)
)
go

/*==============================================================*/
/* Table: InterventionUpdate                                    */
/*==============================================================*/
create table InterventionUpdate (
   InterventionUpdateId int              identity,
   InterventionId       int              null,
   UserId               nvarchar(128)             null,
   Condition            int                  null,
   ModifyDate           datetime             null,
   InterventionComments nvarchar(4000)        null,
   constraint PK_INTERVENTIONUPDATE primary key (InterventionUpdateId)
)
go

/*==============================================================*/
/* Table: Interventions                                         */
/*==============================================================*/
create table Interventions (
   InterventionId       int              identity,
   UserId               nvarchar(128)              null,
   InterventionTypeId   int              null,
   ClientId             int             null,
   InterventionCost     decimal(10,2)              null,
   InterventionHours     decimal(10,2)              null,
   CreateDate           datetime             null,
   Status               int                  null,
  Operator          NVARCHAR(128)           NULL,
   constraint PK_INTERVENTIONS primary key (InterventionId)
)
go

/*==============================================================*/
/* Table: Users                                                 */
/*==============================================================*/
create table Users (
   UserId               nvarchar(128)        not null,
   MaximumHours         decimal(10,2)              null,
   MaximumCost         decimal(10,2)              null,
   District             int                  null,
   constraint PK_USERS primary key (UserId)
)
go

alter table EngineersClients
   add constraint FK_ENGINEER_CLIENTS_E_CLIENTS foreign key (ClientId)
      references Clients (ClientId)
go

alter table EngineersClients
   add constraint FK_ENGINEER_USERS_ENG_USERS foreign key (UserId)
      references Users (UserId)
go

alter table InterventionUpdate
   add constraint FK_INTERVEN_INTER_INT_INTERVEN foreign key (InterventionId)
      references Interventions (InterventionId)
go

alter table InterventionUpdate
   add constraint FK_INTERVEN_USERS_INT_USERS foreign key (UserId)
      references Users (UserId)
go

alter table Interventions
   add constraint FK_INTERVEN_CLIENTS_I_CLIENTS foreign key (ClientId)
      references Clients (ClientId)
go

alter table Interventions
   add constraint FK_INTERVEN_INTERTYPE_INTERVEN foreign key (InterventionTypeId)
      references InterventionType (InterventionTypeId)
go

alter table Interventions
   add constraint FK_INTERVEN_INTERVENT_USERS foreign key (UserId)
      references Users (UserId)
go
IF EXISTS(SELECT 1 FROM sys.views WHERE name='Report_TotalCostsByEngineer')
DROP VIEW Report_TotalCostsByEngineer
GO
create view Report_TotalCostsByEngineer
as
select u.userid,isnull(I.TotalHours,0) TotalHours, isnull(I.TotalCosts,0) TotalCosts  from 
(select * from users ) u left join
(select userid, sum(InterventionHours) TotalHours, sum(InterventionCost) TotalCosts 
from interventions where status=3 group by userid) I on u.userid=i.userid



Go

IF EXISTS(SELECT 1 FROM sys.views WHERE name='Report_AverageCostsByEngineer')
DROP VIEW Report_AverageCostsByEngineer
GO
create view Report_AverageCostsByEngineer
as
select u.userid,isnull(I.AverageHours,0) AverageHours, isnull(I.AverageCosts,0) AverageCosts  from 
(select * from users ) u left join 
(select userid, Convert(decimal(10,2),sum(InterventionHours)/count(InterventionHours)) AverageHours, 
Convert(decimal(10,2),sum(InterventionCost)/count(InterventionCost)) AverageCosts 
from interventions where status=3 group by userid) I on u.userid=i.userid


GO

IF EXISTS(SELECT 1 FROM sys.views WHERE name='Report_CostsByDistrict')
DROP VIEW Report_CostsByDistrict
GO
create view Report_CostsByDistrict
as
select D.DistrictId, D.DistrictName,isnull(sum(I.InterventionCost),0) Costs,isnull(sum(I.InterventionHours),0) Hours from (
select '0' DistrictId, 'Urban Indonesia' DistrictName
union all
select '1','Rural Indonesia'
union all
select '2', 'Urban Papua New Guinea'
union all
select '3', 'Rural Papua New Guinea'
union all
select '4', 'Sydney'
union all
select '5', 'Rural New South Wales' ) D left join 
(select I.InterventionCost,I.InterventionHours,I.Status,C.ClientDistrict from Interventions I inner join Clients C on I.ClientId=C.ClientId where I.Status=3
) I on I.ClientDistrict=D.DistrictId group by D.DistrictId,D.DistrictName

GO
IF EXISTS(SELECT 1 FROM sys.views WHERE name='Report_MonthlyCostsforDistrict')
DROP VIEW Report_MonthlyCostsforDistrict
GO
create view Report_MonthlyCostsforDistrict
as
select D.DistrictId,D.DistrictName,m.Year, M.Month, 
isnull(sum(I.InterventionCost),0) MonthlyCosts, isnull(sum(I.InterventionHours),0) MonthlyHours from (
select '0' DistrictId, 'Urban Indonesia' DistrictName
union all
select '1','Rural Indonesia'
union all
select '2', 'Urban Papua New Guinea'
union all
select '3', 'Rural Papua New Guinea'
union all
select '4', 'Sydney'
union all
select '5', 'Rural New South Wales' ) D cross join 
(
select '2017' "Year",'01' "Month" union all select '2017' y,'02' union all select '2017' y,'03' union all select '2017' y,'04' 
union all select '2017' y,'05' union all select '2017' y,'06' union all select '2017' y,'07' union all select '2017' y,'08' 
union all select '2017' y,'09' union all select '2017' y,'10' union all select '2017' y,'11' union all select '2017' y,'12' ) M 
left join (select I.InterventionCost,I.InterventionHours,I.CreateDate,I.Status,C.ClientDistrict from Interventions I inner join Clients C on I.ClientId=C.ClientId 
where I.Status=3 ) I on I.ClientDistrict=D.DistrictId and month(I.CreateDate)=M.Month and year(I.CreateDate)=M.Year
group by D.DistrictId,D.DistrictName,m.Year, M.Month
