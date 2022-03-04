drop table if exists servicesPersonnes;
drop table if exists demandeConges;
drop table if exists demandeAvance;
drop table if exists detailsFrais;
drop table if exists notesFrais;
drop table if exists missionCollab;
drop table if exists missions;
drop table if exists collaborateurs;
drop table if exists typeCollaborateurs;
drop table if exists typeServices;
drop table if exists notifications;

create table notifications(
titre varchar(100) primary key not null,
idNotifications int not null,
validN1 bit not null,
validN2 bit not null,
);

CREATE TABLE typeCollaborateurs(
idTypeCollab int not null,
nomTypeCollab varchar(100)  PRIMARY KEY not null
);

CREATE TABLE typeServices(
idTypeService int  not null,
nomTypeService varchar(100) PRIMARY KEY not null
);

CREATE TABLE collaborateurs(
matriculeCollab int PRIMARY KEY IDENTITY(1,1),
nom varchar(100) not null,
prenom varchar(100) not null,
dateNaissance datetime not null,
MDP VARCHAR (20) not null,
nomServicePersonne varchar(100) FOREIGN KEY REFERENCES typeServices(nomTypeService) null ,
nomTypeCollab varchar(100) FOREIGN KEY REFERENCES typeCollaborateurs(nomTypeCollab) null,
);

CREATE TABLE servicesPersonnes(
idServicePersonne int PRIMARY KEY IDENTITY(1,1),
dateDebut datetime not null,
dateFin datetime null,
matriculeCollab int FOREIGN KEY REFERENCES collaborateurs(matriculeCollab),
nomServicePersonne varchar(100) FOREIGN KEY REFERENCES typeServices(nomTypeService),
);

Create Table missions(
idMission int PRIMARY KEY IDENTITY(1,1),
nomMission varchar(50) not null,
dateCreation datetime null,
descriptions varchar(max) null,
dateDebut datetime null,
dateFin datetime null,
etat bit not null,
idServicePersonne  int FOREIGN KEY REFERENCES servicesPersonnes(idServicePersonne)
);

create table missionCollab(
nomMission varchar(20),
dateDebut datetime not null,
dateFin datetime null,
nbDemiesJournees int null,
matriculeCollab int FOREIGN KEY REFERENCES collaborateurs(matriculeCollab),
idMission int FOREIGN KEY REFERENCES missions(idMission)
);

Create Table notesFrais(
idNoteFrais int PRIMARY KEY IDENTITY(1,1),
nomNoteFrais varchar(30) not null,
dateSaisie datetime not null,
dateEnvoie datetime null,
sommeTotal decimal null,
sommeAvance decimal null,
sommeDue decimal null,
saisieTermine bit not null,
matriculeCollab int FOREIGN KEY REFERENCES collaborateurs(matriculeCollab),
idMission int FOREIGN KEY REFERENCES missions(idMission)
);

CREATE TABLE detailsFrais(
idDetailsFrais int primary key identity(1,1) not null,
typeFrais varchar(50) not null,
dateDepense datetime not null,
descriptionDesFrais varchar(max),
imageFrais image, 
idNoteFrais int foreign key references notesFrais(idNoteFrais)
);

create table demandeAvance(
idDemandeAvance int primary key identity(1,1),
dateDemande datetime null,
etat bit null,
matriculeCollab int foreign key references collaborateurs(matriculeCollab),
nomDemande varchar(50) not null,
lienNoteFrais varchar(max)
);

create table demandeConges(
idDemandeConges int primary key identity(1,1),
dateConges datetime not null,
etat bit null,
dateDemande datetime not null,
nomDemande varchar(100) not null,
matriculeCollab int foreign key references collaborateurs(matriculeCollab),
);

