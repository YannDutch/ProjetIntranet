drop table servicesHistoriques
drop table demandeConges
drop table demandeAvance
drop table detailsFrais
drop table notesFrais
drop table missionsCollab
drop table missions
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
MDP VARCHAR (20) not null,
idTypeCollab int FOREIGN KEY REFERENCES typeCollaborateurs(idTypeCollab)
);

CREATE TABLE servicesHistoriques(
idServiceHistorique int PRIMARY KEY IDENTITY(1,1),
dateDebut datetime not null,
dateFin datetime null,
matricule int FOREIGN KEY REFERENCES collaborateurs(matriculeCollab),
idService int FOREIGN KEY REFERENCES servicesCollab(idService)
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
valideN1 bit not null,
valideN2 bit not null,
dateDemande datetime null,
notifications varchar(max),
matriculeCollab int foreign key references collaborateurs(matriculeCollab),
idMission int foreign key references missions(idMission),
lienNoteFrais varchar(max)
);

create table demandeConges(
valideN1 bit not null,
valideN2 bit not null,
dateConges datetime not null,
dateDemande datetime not null,
notifications varchar(max),
matriculeCollab int foreign key references collaborateurs(matriculeCollab),
);
