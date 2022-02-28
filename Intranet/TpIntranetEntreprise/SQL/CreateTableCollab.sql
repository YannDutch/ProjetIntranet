drop table servicesHistoriques
drop table demandeconges
drop table demandeavance
drop table DetailsFrais
drop table NotesFrais
drop table MissionsCollab
drop table Missions
drop table collaborateurs
drop table servicesCollab
drop table typeCollaborateurs

CREATE TABLE typeCollaborateurs(
idTypeCollab int PRIMARY KEY IDENTITY(1,1),
nomTypeCollab varchar(100) not null
);

CREATE TABLE servicesCollab(
idService int PRIMARY KEY IDENTITY(1,1),
nomService varchar(100) not null
);

CREATE TABLE collaborateurs(
matriculeCollab int PRIMARY KEY IDENTITY(1,1),
nom varchar(100) not null,
prenom varchar(100) not null,
dateNaissance datetime not null,
mdp varchar(20) not null,
idTypeCollab int FOREIGN KEY REFERENCES typeCollaborateurs(idTypeCollab)
);

CREATE TABLE servicesHistoriques(
idServiceHistorique int PRIMARY KEY IDENTITY(1,1),
dateDebut datetime not null,
dateFin datetime null,
matricule int FOREIGN KEY REFERENCES collaborateurs(matriculeCollab),
idService int FOREIGN KEY REFERENCES servicesCollab(idService)
);

Create Table Missions(
idMission int PRIMARY KEY IDENTITY(1,1),
nomMission varchar(50) not null,
dateCreation datetime null,
contenu varchar(max) null,
dateDebut datetime null,
dateFin datetime null,
IsActive bit not null,
idService  int FOREIGN KEY REFERENCES servicesCollab(idService)
);

create table MissionsCollab(
dateDebut datetime not null,
dateFin datetime null,
nbDemiesJournees int null,
matriculeCollab int FOREIGN KEY REFERENCES collaborateurs(matriculeCollab),
idMission int FOREIGN KEY REFERENCES Missions(idMission)
);

Create Table NotesFrais(
idNoteFrais int PRIMARY KEY IDENTITY(1,1),
nomNoteFrais varchar(30) not null,
dateSaisie datetime not null,
dateenvoie datetime null,
ValideN1 bit not null,
ValideN2 bit not null,
sommeTotal decimal null,
sommeAvance decimal null,
sommeDue decimal null,
notifications varchar(max),
SaisieTermine bit not null,
MatriculeCollab int FOREIGN KEY REFERENCES collaborateurs(matriculeCollab),
idMission int FOREIGN KEY REFERENCES Missions(idmission)
);

CREATE TABLE DetailsFrais(
idDetailsFrais int not null,
typeFrais varchar(50) not null,
dateDepense datetime not null,
descriptionDesFrais varchar(max),
imageFrais image, 
idNoteFrais int foreign key references NotesFrais(idNoteFrais)
);

create table demandeavance(
validen1 bit not null,
validen2 bit not null,
datedemande datetime null,
notifications varchar(max),
matriculecollab int foreign key references collaborateurs(matriculecollab),
idmission int foreign key references missions(idmission),
liennotefrais varchar(max)
);

create table demandeconges(
validen1 bit not null,
validen2 bit not null,
dateconges datetime not null,
datedemande datetime not null,
notifications varchar(max),
matriculecollab int foreign key references collaborateurs(matriculecollab),
);
