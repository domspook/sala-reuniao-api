# Sala Reunião API

API RESTful desenvolvida em .NET 8 para gerenciamento de usuários, salas de reunião e reservas. Este projeto tem como objetivo oferecer uma solução simples e eficiente para agendamento de salas corporativas, garantindo controle de acesso, validações de disponibilidade e filtragem de informações.

## 🚀 Tecnologias Utilizadas

- [.NET 8](https://dotnet.microsoft.com/en-us/)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)
- [PostgreSQL](https://www.postgresql.org/)
- [Swagger / Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- Autenticação com [JWT (JSON Web Token)](https://jwt.io/)

## 🧩 Funcionalidades

### 🔐 Autenticação
- Registro e login de usuários
- Autenticação baseada em token JWT
- Proteção de rotas via middleware de autorização

### 👥 Gerenciamento de Usuários
- Criar, editar e excluir usuários
- Cada usuário possui: `Nome`, `Email`, `Senha`, `Cpf`,`Contato`

### 🏢 Gerenciamento de Salas
- Criar, editar e excluir salas
- Cada sala possui: `Nome`, `Capacidade máxima de pessoas`

### 🗓️ Gerenciamento de Reservas
- Criar e cancelar reservas
- Listagem de reservas com filtros
- Validação automática de conflitos de horário
- Reservas devem começar e terminar no mesmo dia

### 🔍 Filtros e Consultas
- Buscar reservas por:
  - Usuário
  - Sala
  - Data
  - Status (ativa ou cancelada)