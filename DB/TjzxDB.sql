/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2014/5/7 11:42:03                            */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Album') and o.name = 'FK_ALBUM_RELATIONS_ALBUMGRO')
alter table Album
   drop constraint FK_ALBUM_RELATIONS_ALBUMGRO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Consulting') and o.name = 'FK_CONSULTI_RELATIONS_MEMBER')
alter table Consulting
   drop constraint FK_CONSULTI_RELATIONS_MEMBER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Diseases') and o.name = 'FK_DISEASES_RELATIONS_DISEASES')
alter table Diseases
   drop constraint FK_DISEASES_RELATIONS_DISEASES
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
           where  id    = object_id('Album')
            and   name  = 'Relationship_4_FK'
            and   indid > 0
            and   indid < 255)
   drop index Album.Relationship_4_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Album')
            and   type = 'U')
   drop table Album
go

if exists (select 1
            from  sysobjects
           where  id = object_id('AlbumGroup')
            and   type = 'U')
   drop table AlbumGroup
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Assessment')
            and   type = 'U')
   drop table Assessment
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
           where  id    = object_id('Diseases')
            and   name  = 'Relationship_6_FK'
            and   indid > 0
            and   indid < 255)
   drop index Diseases.Relationship_6_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Diseases')
            and   type = 'U')
   drop table Diseases
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DiseasesDepartment')
            and   type = 'U')
   drop table DiseasesDepartment
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Manager')
            and   type = 'U')
   drop table Manager
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
           where  id = object_id('MedicalReport')
            and   type = 'U')
   drop table MedicalReport
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
            from  sysobjects
           where  id = object_id('PackageCollection')
            and   type = 'U')
   drop table PackageCollection
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Region')
            and   type = 'U')
   drop table Region
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

if exists (select 1
            from  sysobjects
           where  id = object_id('SystemLog')
            and   type = 'U')
   drop table SystemLog
go

/*==============================================================*/
/* Table: Album                                                 */
/*==============================================================*/
create table Album (
   AlbumId              int                  identity,
   GroupId              int                  not null,
   Picture              varchar(300)         not null,
   Name                 varchar(200)         not null,
   [Description]        text                 null,
   CreatorId            int                  not null,
   [State]              tinyint              not null,
   Sort                 int                  null,
   Creator              varchar(30)          not null,
   CreateOn             datetime             not null,
   constraint PK_ALBUM primary key nonclustered (AlbumId)
)
go

/*==============================================================*/
/* Index: Relationship_4_FK                                     */
/*==============================================================*/
create index Relationship_4_FK on Album (
GroupId ASC
)
go

/*==============================================================*/
/* Table: AlbumGroup                                            */
/*==============================================================*/
create table AlbumGroup (
   GroupId              int                  identity,
   GroupName            varchar(200)         not null,
   [State]              tinyint              not null,
   Sort                 int                  null,
   constraint PK_ALBUMGROUP primary key nonclustered (GroupId)
)
go

/*==============================================================*/
/* Table: Assessment                                            */
/*==============================================================*/
create table Assessment (
   AssessmentId         int                  identity,
   MedicalNum           varchar(30)          not null,
   RiskAssessment       varchar(600)         null,
   AnomalyIndex         varchar(600)         null,
   BehaviorPatterns     varchar(600)         null,
   MainProblem          varchar(600)         null,
   CreatorId            int                  not null,
   Creator              varchar(30)          not null,
   CreateOn             datetime             not null,
   constraint PK_ASSESSMENT primary key nonclustered (AssessmentId)
)
go

/*==============================================================*/
/* Table: Consulting                                            */
/*==============================================================*/
create table Consulting (
   ConsultingId         int                  identity,
   MemberId             int                  null,
   Title                varchar(200)         not null,
   [Content]            text                 not null,
   Contact              varchar(100)         null,
   Mobile               varchar(20)          null,
   [State]              tinyint              not null,
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
/* Table: Diseases                                              */
/*==============================================================*/
create table Diseases (
   DiseasesId           int                  identity,
   DiseasesDepartmentId int                  not null,
   DiseasesName         varchar(60)          not null,
   DiseasesDescription  text                 not null,
   Sort                 int                  null,
   [State]              tinyint              not null,
   CreateOn             datetime             not null,
   CreatorId            int                  not null,
   Creator              varchar(50)          not null,
   constraint PK_DISEASES primary key nonclustered (DiseasesId)
)
go

if exists (select 1 
from sys.extended_properties 
where major_id = object_id('Diseases') 
and minor_id = 0 and name = 'MS_Description') 
begin 
declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description', 
'user', @CurrentUser, 'table', 'Diseases' 
 
end 

select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description', 
'疾病', 
'user', @CurrentUser, 'table', 'Diseases'
go

/*==============================================================*/
/* Index: Relationship_6_FK                                     */
/*==============================================================*/
create index Relationship_6_FK on Diseases (
DiseasesDepartmentId ASC
)
go

/*==============================================================*/
/* Table: DiseasesDepartment                                    */
/*==============================================================*/
create table DiseasesDepartment (
   DiseasesDepartmentId int                  identity,
   DiseasesDepartmentName varchar(50)          not null,
   [Sort]               int                  null,
   [State]              tinyint              not null,
   constraint PK_DISEASESDEPARTMENT primary key nonclustered (DiseasesDepartmentId)
)
go

if exists (select 1 
from sys.extended_properties 
where major_id = object_id('DiseasesDepartment') 
and minor_id = 0 and name = 'MS_Description') 
begin 
declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description', 
'user', @CurrentUser, 'table', 'DiseasesDepartment' 
 
end 

select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description', 
'疾病分科', 
'user', @CurrentUser, 'table', 'DiseasesDepartment'
go

/*==============================================================*/
/* Table: Manager                                               */
/*==============================================================*/
create table Manager (
   ManagerId            int                  identity,
   UserName             varchar(30)          not null,
   [PassWord]           varchar(100)         not null,
   RealName             varchar(50)          null,
   Mobile               varchar(20)          null,
   [Role]               int                  null,
   Ticket               varchar(100)         null,
   LastLoginTime        datetime             null,
   LastLoginIp          varchar(30)          null,
   CreateOn             datetime             not null,
   [State]              tinyint              null,
   constraint PK_MANAGER primary key nonclustered (ManagerId)
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
/* Table: MedicalReport                                         */
/*==============================================================*/
create table MedicalReport (
   ReportId             int                  identity,
   MedicalNumber        varchar(100)         not null,
   MedicalDate          datetime             not null,
   ReportContent        text                 not null,
   constraint PK_MEDICALREPORT primary key nonclustered (ReportId)
)
go

/*==============================================================*/
/* Table: Member                                                */
/*==============================================================*/
create table Member (
   MemberId             int                  identity,
   IdNumber             varchar(18)          null,
   RealName             varchar(20)          null,
   UserName             varchar(50)          not null,
   Mobile               varchar(20)          null,
   [PassWord]           varchar(120)         not null,
   Ticket               varchar(100)         null,
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
   CreateOn             datetime             not null,
   constraint PK_PACKAGECATEGORY primary key nonclustered (CategoryId)
)
go

/*==============================================================*/
/* Table: PackageCollection                                     */
/*==============================================================*/
create table PackageCollection (
   PackageCollectId     int                  identity,
   MemberId             int                  not null,
   PackageId            int                  not null,
   CreateOn             datetime             not null,
   constraint PK_PACKAGECOLLECTION primary key nonclustered (PackageCollectId)
)
go

if exists (select 1 
from sys.extended_properties 
where major_id = object_id('PackageCollection') 
and minor_id = 0 and name = 'MS_Description') 
begin 
declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description', 
'user', @CurrentUser, 'table', 'PackageCollection' 
 
end 

select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description', 
'套餐收藏', 
'user', @CurrentUser, 'table', 'PackageCollection'
go

/*==============================================================*/
/* Table: Region                                                */
/*==============================================================*/
create table Region (
   RegionId             int                  identity,
   RegionCode           varchar(100)         not null,
   RegionName           varchar(100)         not null,
   ParentId             int                  not null,
   RegionLevel          int                  not null,
   RegionOrder          int                  not null,
   RegionNameEn         varchar(100)         not null,
   RegionShortNameEn    varchar(15)          not null,
   [State]              tinyint              not null,
   constraint PK_REGION primary key nonclustered (RegionId)
)
go

if exists (select 1 
from sys.extended_properties 
where major_id = object_id('Region') 
and minor_id = 0 and name = 'MS_Description') 
begin 
declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description', 
'user', @CurrentUser, 'table', 'Region' 
 
end 

select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description', 
'全国的省市区域', 
'user', @CurrentUser, 'table', 'Region'
go

/*==============================================================*/
/* Table: Reservation                                           */
/*==============================================================*/
create table Reservation (
   ReservationId        int                  identity,
   PackageId            int                  null,
   [Type]               tinyint              not null,
   Name                 varchar(150)         not null,
   IdNumber             varchar(20)          null,
   Company              varchar(120)         null,
   [Address]            varchar(200)         null,
   Mobile               varchar(20)          not null,
   Email                varchar(150)         not null,
   ReservationDate      datetime             not null,
   Remark               varchar(600)         null,
   MemberId             int                  null,
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

/*==============================================================*/
/* Table: SystemLog                                             */
/*==============================================================*/
create table SystemLog (
   LogId                int                  not null,
   LogTitle             varchar(300)         not null,
   LogDescription       varchar(600)         null,
   LogContent           text                 not null,
   LogType              tinyint              not null,
   LogLevel             tinyint              not null,
   CreatorId            int                  not null,
   Creator              varchar(150)         not null,
   CreateOn             datetime             not null,
   CreatorIp            varchar(20)          not null,
   constraint PK_SYSTEMLOG primary key nonclustered (LogId)
)
go

alter table Album
   add constraint FK_ALBUM_RELATIONS_ALBUMGRO foreign key (GroupId)
      references AlbumGroup (GroupId)
go

alter table Consulting
   add constraint FK_CONSULTI_RELATIONS_MEMBER foreign key (MemberId)
      references Member (MemberId)
go

alter table Diseases
   add constraint FK_DISEASES_RELATIONS_DISEASES foreign key (DiseasesDepartmentId)
      references DiseasesDepartment (DiseasesDepartmentId)
go

alter table MedicalPackage
   add constraint FK_MEDICALP_RELATIONS_PACKAGEC foreign key (CategoryId)
      references PackageCategory (CategoryId)
go

alter table Reservation
   add constraint FK_RESERVAT_RELATIONS_MEDICALP foreign key (PackageId)
      references MedicalPackage (PackageId)
go

