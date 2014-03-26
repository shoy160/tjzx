/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2014/3/26 14:29:11                           */
/*==============================================================*/


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
            from  sysobjects
           where  id = object_id('MedicalPackage')
            and   type = 'U')
   drop table MedicalPackage
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
            from  sysobjects
           where  id = object_id('Reservation')
            and   type = 'U')
   drop table Reservation
go

/*==============================================================*/
/* Table: MedicalPackage                                        */
/*==============================================================*/
create table MedicalPackage (
   PackageId            int                  identity,
   CategoryId           int                  not null,
   Name                 char(200)            not null,
   MarketPrice          decimal(18,2)        not null,
   Price                decimal(18,2)        not null,
   [Type]               tinyint              not null,
   ForTheCrowd          char(350)            not null,
   Feature              char(300)            not null,
   Recommends           char(500)            not null,
   Details              text                 not null,
   Popularity           int                  not null,
   CreateOn             datetime             not null,
   [State]              tinyint              not null,
   Sort                 int                  not null,
   CreatorId            int                  not null,
   Creator              char(120)            null,
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
/* Table: News                                                  */
/*==============================================================*/
create table News (
   NewsId               int                  identity,
   [Type]               tinyint              not null,
   Title                char(300)            not null,
   Content              text                 not null,
   CreateOn             datetime             not null,
   Creator              char(120)            not null,
   CreatorId            int                  not null,
   Clicks               int                  null,
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
   Name                 char(150)            not null,
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
   PackageId            int                  not null,
   [Type]               tinyint              not null,
   Name                 char(150)            not null,
   Company              char(120)            null,
   [Address]            char(200)            null,
   Mobile               char(15)             not null,
   Email                char(150)            not null,
   ReservationDate      datetime             not null,
   Remark               char(600)            null,
   CreateOn             datetime             not null,
   CreatorIp            char(20)             not null,
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

alter table MedicalPackage
   add constraint FK_MEDICALP_RELATIONS_PACKAGEC foreign key (CategoryId)
      references PackageCategory (CategoryId)
go

alter table Reservation
   add constraint FK_RESERVAT_RELATIONS_MEDICALP foreign key (PackageId)
      references MedicalPackage (PackageId)
go

