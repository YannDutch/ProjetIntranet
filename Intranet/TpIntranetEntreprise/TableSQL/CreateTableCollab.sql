drop table if exists servicesHistoriques;
drop table if exists demandeConges;
drop table if exists demandeAvance;
drop table if exists detailsFrais;
drop table if exists notesFrais;
drop table if exists missionsCollab;
drop table if exists missions;
drop table if exists collaborateurs;
drop table if exists servicesCollab;
drop table if exists typeCollaborateurs;

CREATE TABLE typeCollaborateurs(
idTypeCollab int identity(1,1),
nomTypeCollab varchar(100)  PRIMARY KEY not null
);

CREATE TABLE servicesCollab(
idService int PRIMARY KEY IDENTITY(1,1),
nomService varchar (100) not null
);

CREATE TABLE collaborateurs(
matriculeCollab int PRIMARY KEY IDENTITY(1,1),
nom varchar(100) not null,
prenom varchar(100) not null,
dateNaissance datetime not null,
MDP VARCHAR (20) not null,
idService int FOREIGN KEY REFERENCES servicesCollab(idService) null ,
nomTypeCollab varchar(100) FOREIGN KEY REFERENCES typeCollaborateurs(nomTypeCollab) null,
);

CREATE TABLE servicesHistoriques(
idServiceHistorique int PRIMARY KEY IDENTITY(1,1),
dateDebut datetime not null,
dateFin datetime null,
matriculeCollab int FOREIGN KEY REFERENCES collaborateurs(matriculeCollab),
idService int FOREIGN KEY REFERENCES servicesCollab(idService),
);

Create Table missions(
idMission int PRIMARY KEY IDENTITY(1,1),
nomMission varchar(50) not null,
dateCreation datetime null,
descriptions varchar(max) null,
dateDebut datetime null,
dateFin datetime null,
isActive bit not null,
idService  int FOREIGN KEY REFERENCES servicesCollab(idService)
);

create table missionsCollab(
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
valideN1 bit not null,
valideN2 bit not null,
sommeTotal decimal null,
sommeAvance decimal null,
sommeDue decimal null,
notifications varchar(max),
saisieTermine bit not null,
matriculeCollab int FOREIGN KEY REFERENCES collaborateurs(matriculeCollab),
idMission int FOREIGN KEY REFERENCES missions(idMission)
);

CREATE TABLE detailsFrais(
idDetailsFrais int not null,
typeFrais varchar(50) not null,
dateDepense datetime not null,
descriptionDesFrais varchar(max),
imageFrais image, 
idNoteFrais int foreign key references notesFrais(idNoteFrais)
);

create table demandeAvance(
valideN1 bit null,
valideN2 bit null,
dateDemande datetime null,
notifications varchar(max),
etat bit null,
matriculeCollab int foreign key references collaborateurs(matriculeCollab),
nomMission varchar(50) not null foreign key references missions(nomMission),
lienNoteFrais varchar(max)
);

create table demandeConges(
valideN1 bit not null,
valideN2 bit not null,
dateConges datetime not null,
etat bit null,
dateDemande datetime not null,
nom varchar(100) foreign key references collaborateurs(nom),
notifications varchar(max),
matriculeCollab int foreign key references collaborateurs(matriculeCollab),
);
