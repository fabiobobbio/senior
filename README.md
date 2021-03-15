# DESAFIO A

## INTRODUCTION

This document aims to define and specify the operational requirements of the Developer test REST API that will be developed for the Senior company.

Formally, we can define that the document contains: "The services and features that the API provides", information about the architecture of the application, as well as restrictions.

#### OVERVIEW OF THE PROPOSED SYSTEM


The goal is to develop some API’s get and post to return and record data related to a management of an orchard of a fruit producer using the technologies: C #.

## ARCHITECTURE


#### Description


The Service was developed using Entity Framework with Oracle database.


Structuring of folders, files and routes.


#### Technologies Used

- [Docker Containers](https://www.docker.com/)
- [NetCore](https://dotnet.microsoft.com/download)
- [Oracle](https://www.oracle.com/index.html)


## INSTALLATION

#### Prerequisites

- [Docker](https://www.docker.com/)

With Docker installed, you will need to install Oracle on it. Run the following commands:
$ docker pull oracleinanutshell / oracle-xe-11g
$ docker run -d -p 49161: 1521 -e ORACLE_ALLOW_REMOTE = true oracleinanutshell / oracle-xe-11g
$ docker ps

Save the ID of the created container.
It is interesting to use a visual tool for manipulating the database. Eg: SQL Developer, DBeaver, etc.
Create a Database user. Create a new SYSTEM user connection:
Name      SYSTEM-LOCAL
Username  system
Password  oracle
Hostname  localhost
Port      49161
SID       xe

Soon after, create a database and permissions user according to the command below:
CREATE USER your_user_name IDENTIFIED BY "yourpassword" DEFAULT TABLESPACE TBS_YOUR_TABLE_SPACE QUOTA UNLIMITED ON TBS_YOUR_TABLE_SPACE;
GRANT connect, create session, imp_full_database TO your_user_name;

Creating a new connection with the application user:
Name      YOUR_USER_NAME-LOCAL
Username  your_user_name
Password  your_password
Hostname  localhost
Port      49161
SID       xe

Run the container with the command below where CONTAINER_ID is the container ID:
$ docker start CONTAINER_ID

To create the tables, sequences, access the repository project folder and execute the command:
$ dotnet ef --startup-project ../Orchard.API database update

Compile the project and all its dependencies with the command below at the root of the challenge folder:
$ dotnet build

Finally run the API with the command:
$ dotnet run

Server initialization on port 5000 for http and 5001 for https

Server initialization on port 5000 for http and 5001 for https

The localhost API is served by port 5000 for http and 5001 for https:
(http://localhost:5000)

### ENDPOINTS

#### METHODS

###### POST
- /api/Species => Register a species of tree,
- /api/TreeGroups => Register a group of trees,
- /api/Harvest => Register a new harvest,
- /api/Trees => Register a tree.

###### GET
- /api/Species => List all registered species,
- /api/TreeGroups => List all registered tree groups,
- /api/Harvest => List all registered harvests,
- /api/Trees => List all registered trees.

- /api/Species/1 => List the registered species with id sent as parameter
- /api/TreeGroups/1 => List the registered treeGroups with id sent as parameter
- /api/Harvest/1 => List the registered harvest with id sent as parameter
- /api/Trees/1 => List the registered trees with id sent as parameter

###### PUT

- /api/Species/1 => Updates the registered species with id sent as parameter
- /api/TreeGroups/1 => Updates the registered treeGroups with id sent as parameter
- /api/Harvest/1 => Updates the registered harvest with id sent as parameter
- /api/Trees/1 => Updates the registered trees with id sent as parameter

###### DELETE

- /api/Species/1 => Delete the registered species with id sent as parameter
- /api/TreeGroups/1 => Delete the registered treeGroups with id sent as parameter
- /api/Harvest/1 => Delete the registered harvest with id sent as parameter
- /api/Trees/1 => Delete the registered trees with id sent as parameter

##### Testes com 

- Some tests will not be performed if the database is turned off, taking into account the test of routes with access to it.
