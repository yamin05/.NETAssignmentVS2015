
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
   ClientId             integer              identity,
   ClientName           varchar(512)         null,
   ClientLocation       varchar(512)         null,
   ClientDistrict       int                  null,
   constraint PK_CLIENTS primary key (ClientId)
)
go

/*==============================================================*/
/* Table: DataDictionary                                        */
/*==============================================================*/
create table DataDictionary (
   DictionaryId         varchar(16)          not null,
   DictionaryType       varchar(32)          null,
   TypeName             varchar(32)          null,
   DataName             varchar(128)         null,
   DataCode             varchar(32)          null,
   IsUsed               int                  null,
   constraint PK_DATADICTIONARY primary key nonclustered (DictionaryId)
)
go

/*==============================================================*/
/* Table: EngineersClients                                      */
/*==============================================================*/
create table EngineersClients (
   EngineersClientsId   integer              identity,
   UserId               integer              null,
   ClientId             integer              null,
   CreateDate           datetime             null,
   constraint PK_ENGINEERSCLIENTS primary key (EngineersClientsId)
)
go

/*==============================================================*/
/* Table: InterventionType                                      */
/*==============================================================*/
create table InterventionType (
   InterventionTypeId   integer              identity,
   InterventionTypeName varchar(512)         null,
   InterventionTypeHour decimal              null,
   InterventionTypeCost decimal              null,
   constraint PK_INTERVENTIONTYPE primary key (InterventionTypeId)
)
go

/*==============================================================*/
/* Table: InterventionUpdate                                    */
/*==============================================================*/
create table InterventionUpdate (
   InterventionUpdateId integer              identity,
   InterventionId       integer              null,
   UserId               integer              null,
   Condition            int                  null,
   ModifyDate           datetime             null,
   constraint PK_INTERVENTIONUPDATE primary key (InterventionUpdateId)
)
go

/*==============================================================*/
/* Table: Interventions                                         */
/*==============================================================*/
create table Interventions (
   InterventionId       integer              identity,
   UserId               integer              null,
   InterventionTypeId   integer              null,
   ClientId             integer              null,
   InterventionCost     decimal              null,
   InterventionHour     decimal              null,
   InterventionComments varchar(5000)        null,
   CreateDate           datetime             null,
   Status               int                  null,
   Operater             int                  null,
   constraint PK_INTERVENTIONS primary key (InterventionId)
)
go

/*==============================================================*/
/* Table: Users                                                 */
/*==============================================================*/
create table Users (
   UserId               integer              identity,
   UserName             varchar(128)         null,
   UserPassword         varchar(128)         null,
   FirstName            varchar(128)         null,
   LastName             varchar(128)         null,
   Roles                int                  null,
   MaximunHours         decimal              null,
   MaximunCosts         decimal              null,
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

