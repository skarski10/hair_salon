#Hair Salon
**C# third week Friday code review for Epicodus, 02.24.17**
###By Kory Skarbek
##Description
The program will be able to add a list of the stylists, and for each stylist, add clients who see that stylist. The stylists work independently, so each client only belongs to a single stylist.

##Specs

Check to see if stylist table database is empty
* **Input:** ""
* **Output:** true

Program recognizes two stylist instances as equal if they have the same name
* **Input:** Rick, Rick
* **Output:** true

Program will save entries into the stylist table
* **Input:** Morty
* **Output:** Morty

Program will return true if a stylist has a unique id and has been saved to an object
* **Input:** Summer
* **Output:** true

Program will return true if the stylist item has been found in the database
* **Input:** Mr. MeeSeeks
* **Output:** true

Check to see if client table database is empty
* **Input:** ""
* **Output:** true

Program recognizes two client instances as equal if they have the same name
* **Input:** Birdperson, Birdperson
* **Output:** true

Program will save entries into the client table
* **Input:** Squanchy
* **Output:** Squanchy

Program will return true if a client has a unique id and has been saved to an object
* **Input:** Tammy
* **Output:** true

Program will return true if the client item has been found in the database
* **Input:** Jerry Smith
* **Output:** true

Program will be able to edit single client entries.
* **Input:** Bird Person
* **Output:** Birdperson

Program will be able to delete single client entries.
* **Input:** Beth Smith
* **Output:** (no entry)

Program will be able to edit single stylist entries.
* **Input:** Ricky
* **Output:** Rick

Program will be able to delete single stylist entries.
* **Input:** Morty
* **Output:** (no entry)

##Setup
* Open up the terminal.
* Clone this repository.
* Compile program
* Go to localhost:5004
#### Importing databases with SSMS
* Open SSMS
* Select File > Open > File and select your .sql file.
* If the database does not already exist, add the following lines to the top of the script file
* CREATE DATABASE hair_salon
* GO
* Save the file.
* Click ! Execute.
* Verify that the database has been created and the schema and/or data imported.

##Technologies Used
C#
HTML
CSS
Bootstrap

##Legal
Copyright(c) 2017 Kory Skarbek
This software is licensed under the MIT license.
