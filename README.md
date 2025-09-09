ColoradoGroupEvaluation
Este é um projeto de teste desenvolvido para o Grupo Colorado. Trata-se de um sistema de cadastro e controle de clientes (CRUD - Create, Read, Update, Delete), implementado com a arquitetura MVC e utilizando .NET Core.

Tecnologias Utilizadas
ASP.NET Core (MVC): Framework web para a construção da aplicação.

Entity Framework Core: ORM (Object-Relational Mapper) para o acesso a dados.

MySQL: Sistema de gerenciamento de banco de dados relacional.

Bootstrap: Framework de frontend para estilização e responsividade da interface.

Funcionalidades
O sistema permite que o usuário realize as seguintes operações:

Cadastrar um novo cliente.

Visualizar a lista de clientes.

Editar informações de um cliente existente.

Excluir um cliente do cadastro.

Instalação e Configuração
Siga os passos abaixo para configurar e rodar o projeto em sua máquina local.

Pré-requisitos
Certifique-se de que você tem os seguintes softwares instalados:

.NET Core SDK 6.0 ou superior: Baixar aqui

MySQL: Servidor MySQL rodando localmente ou acesso a um servidor remoto.

MySQL Workbench (Opcional): Para gerenciamento do banco de dados.

Configuração do Banco de Dados
Crie um novo banco de dados no MySQL com o nome de sua preferência (por exemplo, ColoradoEvaluation).

Abra o arquivo appsettings.json no projeto e atualize a string de conexão (DefaultConnection) com as suas credenciais e o nome do banco de dados.

JSON

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Port=3306;Database=ColoradoEvaluation;Uid=seu_usuario;Pwd=sua_senha;"
}
Abra o terminal na pasta raiz do projeto e execute os comandos para criar as migrações e o banco de dados:

Bash

dotnet ef database update
Rodando a Aplicação
Após a configuração do banco de dados, execute o projeto no terminal:

Bash

dotnet run
A aplicação será iniciada e estará disponível no endereço http://localhost:5000 (ou a porta indicada no console).

Contribuindo
Se você deseja contribuir para este projeto, sinta-se à vontade para abrir uma issue ou enviar um pull request com suas melhorias.
