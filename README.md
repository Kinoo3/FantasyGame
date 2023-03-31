# FantasyGame
## Desafio técnico - Sydy

Api de um fantasy game para o desafio técnico da Sydy tecnologia para vaga de dev


A api utiliza de .net core, EF core (code-first), SQLServer, swagger.
Além disso, utiliza dos design patterns Repository/UnitOfWork.


Instruções:
<ul>
<li>Clone o repositório</li>
<li>Restaure as bibliotecas via prompt (dotnet restore) ou através do visual studio</li>
<li>Mude a ConnectionString no arquivo appsetings.json, conforme necessário para apontar para o banco SQLServer local</li>
<li>Use o comando Update-database para aplicar as migrações ao banco de dados</li>
<li>Build & Run o projeto, a página inicial a ser carregada é a página do swagger contendo os endpoints da aplicação</li>
</ul>


Estrutura de arquivos:
- Database: Contém o dbcontext da aplicação
- Endpoints: Contém as controllers, arquivos de regras de negócios, entre outros para atender aos endpoints
- Migrations: Contém as alterações do banco de dados via EF core
- Models:  
Data: As entidades do domínio da aplicação, e a Camada de Acesso a Dados (DAL), que contém o UnitOfWork e os Repositorys para acessar os dados  
Root: InputModels e OutputModels que definem como a aplicação recebe e retorna dados

- Utils: Contém classes que exercem funções generalizadas que podem ser usadas ao longo de toda aplicação
