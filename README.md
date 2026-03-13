````markdown
# 🚀 processo-seletivo-CSharp API

Sistema de blog desenvolvido em **C# (.NET 8)** com **arquitetura monolítica organizada**, aplicando boas práticas de engenharia de software como **SOLID**, **Entity Framework Core** e **notificações em tempo real via WebSockets (SignalR)**.

---

# 📋 Pré-requisitos

Antes de iniciar, certifique-se de possuir os seguintes itens instalados:

- **.NET 8 SDK** (ou superior)
- **Docker Desktop** (ou OrbStack / Docker Engine)
- **EF Core CLI Tool** (para execução de migrations)

Instale a ferramenta do Entity Framework:

```bash
dotnet tool install --global dotnet-ef
````

---

# 🛠️ Passo a Passo para Executar o Projeto

## 1️⃣ Clonar o repositório

```bash
git clone <url-do-repositorio>
cd processo-seletivo-CSharp
```

---

## 2️⃣ Iniciar a infraestrutura (Banco de Dados)

O projeto utiliza **PostgreSQL executando em container Docker**.

Na raiz do projeto execute:

```bash
docker compose up -d
```

Isso irá iniciar o container do banco de dados necessário para a aplicação.

---

## 3️⃣ Configurar o Banco de Dados (Migrations)

Após o banco estar em execução, é necessário aplicar as migrations para criar as tabelas do sistema.

Caso o comando `dotnet-ef` não seja reconhecido em **Mac/Linux**, execute:

```bash
export PATH="$PATH:$HOME/.dotnet/tools"
```

Restaura dependencia se for necessario
```bash
dotnet restore
```

Depois aplique as migrations:

```bash
dotnet ef database update
```

Isso criará as tabelas de:

* Usuários
* Postagens

---

## 4️⃣ Executar a aplicação

Execute o projeto com:

```bash
dotnet run
```

A API será iniciada em algo semelhante a:

```
http://localhost:5156
```

A porta exata será exibida no **console da aplicação**.

---

# 🔔 Testando as Notificações em Tempo Real

O sistema utiliza **SignalR (WebSockets)** para envio de notificações em tempo real.

Para testar:

1. Abra o arquivo **`index.html`** presente no projeto
2. Abra em qualquer navegador
3. Realize operações de criação de postagens na API

As notificações serão exibidas automaticamente.

---

# 🏗️ Arquitetura e Tecnologias

Este projeto foi estruturado para demonstrar conceitos importantes de **engenharia de software moderna**.

### 📦 Monolito Organizado

Separação clara de responsabilidades:

```
Controllers
Services
Data
Hubs
```

---

### 🧩 Princípios SOLID

Aplicação de boas práticas como:

* **SRP (Single Responsibility Principle)**
  Serviços com responsabilidade única.

* **DIP (Dependency Inversion Principle)**
  Uso de **interfaces e injeção de dependência**.

---

### 🗄️ Entity Framework Core

Utilizado para:

* Mapeamento objeto-relacional (ORM)
* Persistência de dados
* Migrations de banco

---

### 🔌 SignalR

Implementação de **WebSockets** para comunicação **bi-direcional em tempo real**.

Usado para:

* Notificações de novas postagens
* Comunicação servidor → cliente instantânea

---

### 🔐 Autenticação JWT

Uso de **JSON Web Token** para autenticação segura da API.

Permite:

* Registro de usuários
* Login
* Proteção de endpoints de criação/edição de postagens

---

# 🧪 Como Testar a API

O projeto possui um arquivo de testes utilizando **REST Client** do VS Code.

### Passos:

1. Instale a extensão **REST Client** no VS Code
2. Abra o arquivo:

```
BlogMonolito.http
```

3. Execute as requisições disponíveis:

* Registro de usuário
* Login
* CRUD de postagens

---

# 📚 Objetivo do Projeto

Este projeto foi desenvolvido com foco em demonstrar:

* Estrutura de **API profissional em .NET**
* **Arquitetura organizada em monólito**
* Uso de **SignalR para comunicação em tempo real**
* Implementação de **boas práticas de engenharia de software**
* Integração com **PostgreSQL via Docker**

---

# 👨‍💻 Autor - Matheus Pini

Projeto desenvolvido para fins de **estudo, demonstração técnica e portfólio**.
