CREATE TABLE "Contact"(
	"Id" SERIAL PRIMARY KEY,
    "Name" VARCHAR(50),
    "BirthDate" DATE,
	"Address" VARCHAR(50),
	
	CONSTRAINT no_duplicate_contact UNIQUE ("Name", "Address")
)

CREATE TABLE "Telephone" (
	"Id" SERIAL PRIMARY KEY,
    "Number" VARCHAR(50),
    "ContactId" INT,
    CONSTRAINT fk_contact
      FOREIGN KEY("ContactId") 
	  REFERENCES "Contact"("Id")
);

INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Marcus', '5 Birchwood Circle', '1987-11-19');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Julia', '39 Little Fleur Parkway', '1988-02-16');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Ruthie', '95133 Anhalt Hill', '1985-07-24');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Sheilakathryn', '71 Dennis Alley', '1992-08-20');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Ikey', '087 Del Mar Terrace', '1986-05-23');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Dane', '4725 Charing Cross Center', '1987-11-12');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Carmella', '7039 Grover Trail', '1992-12-06');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Jacky', '6520 Clyde Gallagher Plaza', '1988-05-07');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Hadley', '5 Schmedeman Street', '1994-06-01');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Maria', '0805 Killdeer Terrace', '1990-01-23');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Ellsworth', '86 Vahlen Park', '1994-10-04');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Alexandre', '212 Lakeland Street', '1985-05-01');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Sergio', '2426 Grayhawk Plaza', '1991-01-18');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Ralina', '27125 Melrose Court', '1987-01-06');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Ozzy', '7 Dexter Terrace', '1985-08-14');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Carlin', '21540 Welch Terrace', '1992-10-19');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Adriena', '5 Lillian Point', '1986-07-27');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Maryl', '79 Superior Park', '1990-06-22');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Linet', '03037 Trailsway Way', '1994-06-16');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Cassaundra', '407 Troy Alley', '1985-11-26');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Aundrea', '4 Rowland Court', '1994-03-03');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Sean', '7665 Farragut Drive', '1993-09-14');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Dianemarie', '23511 Gina Point', '1985-02-13');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Carmine', '08219 Toban Court', '1986-01-01');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Jdavie', '3446 Crest Line Lane', '1992-05-22');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Ashla', '84 8th Drive', '1994-11-19');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Tiertza', '0 Messerschmidt Point', '1992-04-10');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Cris', '420 Leroy Circle', '1991-10-24');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Dotty', '25956 Bowman Street', '1987-05-01');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Rhys', '88930 Dwight Street', '1992-08-23');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Saw', '57742 Bowman Alley', '1986-03-18');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Paquito', '8647 Loomis Terrace', '1988-09-30');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Rube', '1253 Larry Street', '1994-07-31');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Laurie', '35788 Cordelia Road', '1993-07-31');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Lynde', '400 Anhalt Plaza', '1991-02-16');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Nestor', '15 Blaine Crossing', '1992-10-11');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Anjanette', '30 Daystar Park', '1987-03-09');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Estelle', '700 Aberg Center', '1986-02-22');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Gibb', '097 Waywood Way', '1991-09-17');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Jodi', '30 Paget Park', '1993-06-13');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Myrtie', '236 Dunning Crossing', '1987-10-08');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Panchito', '6 Springs Road', '1989-01-08');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Deny', '083 Cambridge Center', '1989-11-12');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Stuart', '9 Katie Crossing', '1988-04-22');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Finley', '50916 Banding Terrace', '1994-04-21');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Zacharie', '9800 Raven Crossing', '1990-03-30');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Sig', '6 Bunting Street', '1992-04-24');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Shayne', '0395 Carpenter Drive', '1992-04-18');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Barnabas', '4 Fieldstone Drive', '1993-01-30');
INSERT INTO "Contact" ("Name", "Address", "BirthDate") VALUES ('Mia', '5996 Old Shore Junction', '1993-10-15');

INSERT INTO "Telephone" ("Number", "ContactId") VALUES ('3213878962', 1);
INSERT INTO "Telephone" ("Number", "ContactId") VALUES ('5021565015', 1);
INSERT INTO "Telephone" ("Number", "ContactId") VALUES ('6141023912', 1);
INSERT INTO "Telephone" ("Number", "ContactId") VALUES ('5762837600', 1);
INSERT INTO "Telephone" ("Number", "ContactId") VALUES ('1018019559', 1);
INSERT INTO "Telephone" ("Number", "ContactId") VALUES ('6091250938', 2);
INSERT INTO "Telephone" ("Number", "ContactId") VALUES ('7987198268', 2);
INSERT INTO "Telephone" ("Number", "ContactId") VALUES ('9803789662', 3);
INSERT INTO "Telephone" ("Number", "ContactId") VALUES ('1429086678', 50);
