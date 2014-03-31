/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2014/3/31 17:10:50                           */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Consulting') and o.name = 'FK_CONSULTI_RELATIONS_MEMBER')
alter table Consulting
   drop constraint FK_CONSULTI_RELATIONS_MEMBER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MedicalPackage') and o.name = 'FK_MEDICALP_RELATIONS_PACKAGEC')
alter table MedicalPackage
   drop constraint FK_MEDICALP_RELATIONS_PACKAGEC
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Reservation') and o.name = 'FK_RESERVAT_RELATIONS_MEDICALP')
alter table Reservation
   drop constraint FK_RESERVAT_RELATIONS_MEDICALP
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Consulting')
            and   name  = 'Relationship_3_FK'
            and   indid > 0
            and   indid < 255)
   drop index Consulting.Relationship_3_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Consulting')
            and   type = 'U')
   drop table Consulting
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MedicalPackage')
            and   name  = 'Relationship_1_FK'
            and   indid > 0
            and   indid < 255)
   drop index MedicalPackage.Relationship_1_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MedicalPackage')
            and   type = 'U')
   drop table MedicalPackage
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Member')
            and   type = 'U')
   drop table Member
go

if exists (select 1
            from  sysobjects
           where  id = object_id('News')
            and   type = 'U')
   drop table News
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PackageCategory')
            and   type = 'U')
   drop table PackageCategory
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Reservation')
            and   name  = 'Relationship_2_FK'
            and   indid > 0
            and   indid < 255)
   drop index Reservation.Relationship_2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Reservation')
            and   type = 'U')
   drop table Reservation
go

/*==============================================================*/
/* Table: Consulting                                            */
/*==============================================================*/
create table Consulting (
   ConsultingId         int                  identity,
   MemberId             int                  null,
   Title                varchar(200)         not null,
   Content              text                 not null,
   Contact              varchar(100)         null,
   Mobile               varchar(20)          null,
   State                tinyint              not null,
   DeelSituation        varchar(600)         null,
   DeelTime             datetime             null,
   CreateOn             datetime             not null,
   CreatorIp            varchar(20)          not null,
   constraint PK_CONSULTING primary key nonclustered (ConsultingId)
)
go

/*==============================================================*/
/* Index: Relationship_3_FK                                     */
/*==============================================================*/
create index Relationship_3_FK on Consulting (
MemberId ASC
)
go

/*==============================================================*/
/* Table: MedicalPackage                                        */
/*==============================================================*/
create table MedicalPackage (
   PackageId            int                  identity,
   CategoryId           int                  not null,
   Name                 varchar(200)         not null,
   Sex                  tinyint              not null,
   MarketPrice          decimal(18,2)        not null,
   Price                decimal(18,2)        not null,
   [Type]               tinyint              not null,
   ForTheCrowd          varchar(350)         not null,
   Feature              varchar(300)         not null,
   Recommends           varchar(500)         not null,
   Details              text                 not null,
   Popularity           int                  not null,
   CreateOn             datetime             not null,
   [State]              tinyint              not null,
   Sort                 int                  not null,
   CreatorId            int                  not null,
   Creator              varchar(120)         null,
   constraint PK_MEDICALPACKAGE primary key nonclustered (PackageId)
)
go

if exists (select 1 
from sys.extended_properties 
where major_id = object_id('MedicalPackage') 
and minor_id = 0 and name = 'MS_Description') 
begin 
declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description', 
'user', @CurrentUser, 'table', 'MedicalPackage' 
 
end 

select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description', 
'体检套餐', 
'user', @CurrentUser, 'table', 'MedicalPackage'
go

/*==============================================================*/
/* Index: Relationship_1_FK                                     */
/*==============================================================*/
create index Relationship_1_FK on MedicalPackage (
CategoryId ASC
)
go

/*==============================================================*/
/* Table: Member                                                */
/*==============================================================*/
create table Member (
   MemberId             int                  identity,
   IdNumber             varchar(18)          not null,
   RealName             varchar(20)          not null,
   UserName             varchar(50)          not null,
   Mobile               varchar(20)          null,
   PassWord             varchar(120)         not null,
   Ticket               varchar(50)          null,
   LastLoginTime        datetime             null,
   LastLoginIp          varchar(30)          null,
   UserLevel            tinyint              not null,
   CreateOn             datetime             not null,
   State                tinyint              not null,
   constraint PK_MEMBER primary key nonclustered (MemberId)
)
go

/*==============================================================*/
/* Table: News                                                  */
/*==============================================================*/
create table News (
   NewsId               int                  identity,
   [Type]               tinyint              not null,
   Title                varchar(300)         not null,
   Content              text                 not null,
   CreateOn             datetime             not null,
   Creator              varchar(120)         not null,
   CreatorId            int                  not null,
   Views                int                  null,
   Comefrom             varchar(150)         null,
   Author               varchar(120)         null,
   [State]              tinyint              not null,
   constraint PK_NEWS primary key nonclustered (NewsId)
)
go

if exists (select 1 
from sys.extended_properties 
where major_id = object_id('News') 
and minor_id = 0 and name = 'MS_Description') 
begin 
declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description', 
'user', @CurrentUser, 'table', 'News' 
 
end 

select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description', 
'新闻资讯类', 
'user', @CurrentUser, 'table', 'News'
go

/*==============================================================*/
/* Table: PackageCategory                                       */
/*==============================================================*/
create table PackageCategory (
   CategoryId           int                  identity,
   Name                 varchar(150)         not null,
   Sort                 int                  not null,
   [State]              tinyint              null,
   constraint PK_PACKAGECATEGORY primary key nonclustered (CategoryId)
)
go

/*==============================================================*/
/* Table: Reservation                                           */
/*==============================================================*/
create table Reservation (
   ReservationId        int                  identity,
   PackageId            int                  null,
   [Type]               tinyint              not null,
   Name                 varchar(150)         not null,
   Company              varchar(120)         null,
   [Address]            varchar(200)         null,
   Mobile               varchar(20)          not null,
   Email                varchar(150)         not null,
   ReservationDate      datetime             not null,
   Remark               varchar(600)         null,
   CreateOn             datetime             not null,
   CreatorIp            varchar(20)          not null,
   [State]              tinyint              not null,
   constraint PK_RESERVATION primary key nonclustered (ReservationId)
)
go

if exists (select 1 
from sys.extended_properties 
where major_id = object_id('Reservation') 
and minor_id = 0 and name = 'MS_Description') 
begin 
declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description', 
'user', @CurrentUser, 'table', 'Reservation' 
 
end 

select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description', 
'预约信息表', 
'user', @CurrentUser, 'table', 'Reservation'
go

/*==============================================================*/
/* Index: Relationship_2_FK                                     */
/*==============================================================*/
create index Relationship_2_FK on Reservation (
PackageId ASC
)
go

alter table Consulting
   add constraint FK_CONSULTI_RELATIONS_MEMBER foreign key (MemberId)
      references Member (MemberId)
go

alter table MedicalPackage
   add constraint FK_MEDICALP_RELATIONS_PACKAGEC foreign key (CategoryId)
      references PackageCategory (CategoryId)
go

alter table Reservation
   add constraint FK_RESERVAT_RELATIONS_MEDICALP foreign key (PackageId)
      references MedicalPackage (PackageId)
go

