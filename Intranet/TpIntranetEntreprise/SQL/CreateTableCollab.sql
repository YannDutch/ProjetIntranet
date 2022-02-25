Drop table typeCollaborateurs;
Drop table services;
Drop table collaborateurs;

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