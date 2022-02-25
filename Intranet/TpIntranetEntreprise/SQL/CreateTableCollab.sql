--tables


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

CREATE TABLE demandeAvance(
ValideN1 bit not null,
ValideN2 bit not null,
dateDemande datetime null,
notifications varchar(max),
matriculeCollab int FOREIGN KEY REFERENCES collaborateurs(matriculeCollab),
idMission int FOREIGN KEY REFERENCES missions(idmission),
lienNoteFrais varchar(max)
);

CREATE TABLE demandeConges(
ValideN1 bit not null,
ValideN2 bit not null,
DateConges datetime not null,
DateDemande datetime not null,
notifications varchar(max),
MatriculeCollab int FOREIGN KEY REFERENCES collaborateurs(matriculeCollab),
);
