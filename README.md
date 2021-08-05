# DESAFIO A

## INTRODUÇÃO

Este documento tem como objetivo definir e especificar os requisitos operacionais da API REST de teste de Desenvolvedor.

Formalmente, podemos definir que o documento contém: “Os serviços e funcionalidades que a API disponibiliza”, informações sobre a arquitetura da aplicação, bem como restrições.

#### VISÃO GERAL DO SISTEMA PROPOSTO

O objetivo é desenvolver algumas APIs get e post para retornar e registrar dados relacionados ao manejo de um pomar de um produtor de frutas usando a tecnologias C#.

## ARQUITETURA


#### Descrição


O Serviço foi desenvolvido utilizando NetCore, ORM Entity Framework com banco de dados Oracle. Buscou-se seguir os princípios do SOLID como melhores práticas de desenvolvimento.


Estruturação de pastas, arquivos e rotas.


#### Tecnologias utilizadas

- [Docker Containers](https://www.docker.com/)
- [NetCore](https://dotnet.microsoft.com/download)
- [Oracle](https://www.oracle.com/index.html)


## INSTALAÇÃO

#### Pré-requisitos

- [Docker](https://www.docker.com/)

Com o Docker instalado, você precisará instalar o Oracle nele. Execute os seguintes comandos:

$ docker pull oracleinanutshell / oracle-xe-11g
$ docker run -d -p 49161: 1521 -e ORACLE_ALLOW_REMOTE = true oracleinanutshell / oracle-xe-11g
$ docker ps

Salve o ID do container criado.
É interessante usar uma ferramenta visual para manipular o banco de dados. Ex: SQL Developer, DBeaver, etc.

Crie um usuário do banco de dados. Crie uma nova conexão de usuário SYSTEM:
Name      SYSTEM-LOCAL
Username  system
Password  oracle
Hostname  localhost
Port      49161
SID       xe

Em seguida, crie um banco de dados e permissões de usuário de acordo com o comando abaixo:
CREATE USER your_user_name IDENTIFIED BY "yourpassword" DEFAULT TABLESPACE TBS_YOUR_TABLE_SPACE QUOTA UNLIMITED ON TBS_YOUR_TABLE_SPACE;
GRANT connect, create session, imp_full_database TO your_user_name;

Criar uma nova conexão com o usuário do aplicativo:
Name      YOUR_USER_NAME-LOCAL
Username  your_user_name
Password  your_password
Hostname  localhost
Port      49161
SID       xe

Execute o contêiner com o comando abaixo, em que CONTAINER_ID é o ID do contêiner:
$ docker start CONTAINER_ID

Para criar as tabelas, relacionamentos e sequences, acesse a pasta do projeto do repositório e execute o comando:
$ dotnet ef --startup-project ../Orchard.API database update

Compile o projeto e todas as suas dependências com o comando abaixo na raiz da pasta do desafio:
$ dotnet build

Finalmente execute a API com o comando abaixo na raiz do projeto API:
$ dotnet run

Inicialização do servidor na porta 5000 para http e 5001 para https

A API localhost é servida pela porta 5000 para http e 5001 para https:
(http://localhost:5000 e https://localhost:5001)

### ENDPOINTS

#### MÉTODOS

###### POST
- /api/Species => Registre uma espécie de árvore,
- /api/TreeGroups => Registre um grupo de árvores,
- /api/Harvest => Registre uma nova colheita,
- /api/Trees => Registre uma árvore.

###### GET
- /api/Species => Liste todas as espécies registradas,
- /api/TreeGroups => Lista todos os grupos de árvores registrados,
- /api/Harvest => Liste todas as colheitas registradas,
- /api/Trees => Listar todas as árvores registradas.

- /api/Species/1 => Liste a espécie registrada com id enviado como parâmetro
- /api/TreeGroups/1 => Lista os treeGroups registrados com id enviado como parâmetro
- /api/Harvest/1 => Lista a colheita registrada com id enviado como parâmetro
- /api/Trees/1 => Liste a árvore cadastrada com id enviado como parâmetro

###### PUT

- /api/Species/1 => Atualiza a espécie registrada com id enviado como parâmetro
- /api/TreeGroups/1 => Atualiza os treeGroups registrados com id enviado como parâmetro
- /api/Harvest/1 => Atualiza a colheita registrada com id enviado como parâmetro
- /api/Trees/1 => Atualiza as árvores cadastradas com id enviado como parâmetro

###### DELETE

- /api/Species/1 => Exclui a espécie registrada com id enviado como parâmetro
- /api/TreeGroups/1 => Exclui o treeGroup registrados com id enviado como parâmetro
- /api/Harvest/1 => Exclui a colheita registrada com id enviado como parâmetro
- /api/Trees/1 => Exclui a árvore cadastrada com id enviado como parâmetro

##### Testes de unidade com xUnit.net 

- Alguns testes não são realizados se o banco de dados estiver desligado, levando em consideração o teste de rotas com acesso a ele.
