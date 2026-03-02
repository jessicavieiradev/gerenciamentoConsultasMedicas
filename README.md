# 🏥 sistemaAgendamentoMedico

![Status](https://img.shields.io/badge/Status-Em%20Desenvolvimento-orange?style=for-the-badge)
![.NET Version](https://img.shields.io/badge/.NET-10.0-512bd4?style=for-the-badge&logo=dotnet)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![JWT](https://img.shields.io/badge/JWT-black?style=for-the-badge&logo=json-web-tokens)

API robusta desenvolvida para a gestão de agendamentos em clínicas médicas, focada em segurança, escalabilidade e separação clara de responsabilidades.

---

## 🚀 Tecnologias e Frameworks

* **Linguagem & Core:** `C#` com `ASP.NET 10`.
* **Banco de Dados:** `Microsoft SQL Server`.
* **Acesso a Dados:** `Entity Framework Core`.
* **Segurança:** `JSON Web Token (JWT)`.
* **Log & Monitoramento:** `Serilog`.
* **Documentação:** `Swagger (OpenAPI)`.

## 📂 Arquitetura do Sistema

O projeto está organizado para seguir boas práticas de **Injeção de Dependência** e **Desacoplamento**:

| Camada | Descrição |
| :--- | :--- |
| **`Controllers`** | Exposição dos Endpoints e controle de rotas. |
| **`Services`** | Camada onde reside toda a regra de negócio. |
| **`Interfaces`** | Contratos que garantem o desacoplamento via Injeção de Dependência. |
| **`Entities`** | Modelagem das tabelas do banco de dados. |
| **`DTOs`** | Objetos de transferência de dados (Data Transfer Objects). |
| **`Configurations`** | Configurações globais. |
| **`Data`** | Contexto do banco de dados e persistência (EF Core). |
| **`Enums`** | Definição de tipos enumerados para consistência de dados. |

## 🛠 Status do Desenvolvimento (Core Features)

* **⚡ Autenticação Base:** Fluxo de Login para Pacientes já operacional, realizando a emissão e validação de Tokens JWT.
* **📊 Observabilidade:** Implementação de Logs estruturados via **Serilog** em fase de refinamento para monitoramento de erros.
* **🗄 Camada de Dados:** Integração com SQL Server consolidada, utilizando Migrations para evolução constante do schema.
* **🛡 Segurança e Tipagem:** Uso de **DTOs** e **Interfaces** implementado para garantir que a API seja extensível e segura desde o início.
* **📖 Documentação Ativa:** Swagger configurado e atualizado automaticamente a cada novo endpoint desenvolvido.

## ⚙️ Como Iniciar

1.  **Clone o projeto:**
    ```bash
    git clone https://github.com/jessicavieiradev/gerenciamentoConsultasMedicas.git
    ```

2.  **Configuração:**
    Ajuste a sua Connection String no arquivo `appsettings.json`.

3.  **Banco de Dados:**
    ```bash
    dotnet ef database update
    ```

4.  **Execução:**
    ```bash
    dotnet run
    ```
