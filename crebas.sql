/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     2019/7/17 9:30:18                            */
/*==============================================================*/

use localization;

drop table if exists Beacon;

drop table if exists Device;

drop table if exists Map;

drop table if exists Position;

drop table if exists User;

/*==============================================================*/
/* Table: Beacon                                                */
/*==============================================================*/
create table Beacon
(
   BeaconID             int not null auto_increment,
   MapID                int,
   MacAddress           varchar(20) not null,
   primary key (BeaconID)
);

/*==============================================================*/
/* Table: Device                                                */
/*==============================================================*/
create table Device
(
   DeviceID             int not null auto_increment,
   MacAddress           varchar(20) not null,
   primary key (DeviceID)
);

/*==============================================================*/
/* Table: Map                                                   */
/*==============================================================*/
create table Map
(
   MapID                int not null auto_increment,
   MapName              varchar(20) not null,
   MapImage             longblob not null,
   primary key (MapID)
);

/*==============================================================*/
/* Table: Position                                              */
/*==============================================================*/
create table Position
(
   UserID               int,
   MapID                int,
   LocationX            int,
   LocationY            int,
   Timestamp            bigint
);

/*==============================================================*/
/* Table: User                                                  */
/*==============================================================*/
create table User
(
   UserID               int not null auto_increment,
   DeviceID             int,
   UserName             varchar(20) not null,
   PassWord             varchar(20) not null,
   primary key (UserID)
);

alter table Beacon add constraint FK_Reference_4 foreign key (MapID)
      references Map (MapID) on delete cascade on update cascade;

alter table Position add constraint FK_Reference_2 foreign key (UserID)
      references User (UserID) on delete cascade on update cascade;

alter table Position add constraint FK_Reference_3 foreign key (MapID)
      references Map (MapID) on delete cascade on update cascade;

alter table User add constraint FK_Reference_1 foreign key (DeviceID)
      references Device (DeviceID) on delete cascade on update cascade;

