# 💼 Mini Investment Wallet API

A backend-only API built using **ASP.NET Core (.NET 8)** that follows Clean Architecture and Domain-Driven Design (DDD).
It simulates a simplified fintech platform for:

* 🧑 Investor account creation
* 💳 Wallet funding
* 💼 Investing in static opportunities
* 📈 Tracking wallet balance and investment history

> ⚠️ **.NET 7 is no longer supported**, so this project targets **.NET 8** for long-term stability.
> See [.NET Support Policy](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core) for official info.

---

## 🔧 Tech Stack

* **.NET 8 (ASP.NET Core Web API)**
* **Entity Framework Core** with **PostgreSQL**
* **Clean Architecture**
* **CQRS** with [MediatR](https://github.com/jbogard/MediatR)
* **Domain-Driven Design (DDD)**
* **Dependency Injection**
* **Swagger/OpenAPI** for testing

---

## 📁 Project Structure

```
MiniInvest/
🔺 MiniInvest.API           # API layer (Controllers, Swagger, DI)
🔺 MiniInvest.Application   # CQRS Commands, Queries, Handlers, Interfaces
🔺 MiniInvest.Domain        # Domain entities (Investor, Investment, Opportunity)
🔺 MiniInvest.Infrastructure# EF Core DbContext, Repositories, Configs
🔺 MiniInvestmentWalletApi.sln
```

---

## 📌 Static Investment Opportunities

These are hardcoded in the domain layer:

| ID                                     | Name             | Minimum Amount |
| -------------------------------------- | ---------------- | -------------- |
| `11111111-1111-1111-1111-111111111111` | Real Estate Fund | 1000           |
| `22222222-2222-2222-2222-222222222222` | Tech Growth Fund | 1500           |
| `33333333-3333-3333-3333-333333333333` | SME Sukuk        | 800            |

---

## 🚀 Getting Started

### ✅ Requirements

* [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
* [PostgreSQL](https://www.enterprisedb.com/downloads/postgres-postgresql-downloads)

### 🛠 Recommended PostgreSQL Credentials

```text
Username: postgres
Password: 123qwe
Port: 5432
Database: MiniInvestDb
```

---

## ⚙️ Run the Project

### 1️⃣ Apply Database Migrations

```bash
dotnet ef database update --startup-project ./MiniInvest.API
```

### 2️⃣ Start the API

```bash
dotnet run --project ./MiniInvest.API
```

Swagger UI will be available at:
👉 `https://localhost:{port}/swagger`

---

## 📬 API Endpoints & Examples

### 1. 🧑 Create Investor

```http
POST /api/investors
Content-Type: application/json
```

**Request:**

```json
{
  "name": "Ahmed Emad",
  "email": "ahmed@test.com"
}
```

**Response:**

```json
{
  "investorId": "GUID"
}
```

---

### 2. 💳 Fund Wallet

```http
POST /api/investors/{investorId}/fund
```

**Request:**

```json
{
  "amount": 5000
}
```

**Response:** `200 OK`

```json
{ "message": "Wallet funded successfully." }
```

---

### 3. 💼 Make Investment

```http
POST /api/investors/{investorId}/invest
```

**Request:**

```json
{
  "opportunityId": "11111111-1111-1111-1111-111111111111",
  "amount": 2000
}
```

**Response:** `200 OK`

```json
{ "message": "Investment completed successfully." }
```

---

### 4. 💰 Get Wallet Balance

```http
GET /api/investors/{investorId}/balance
```

**Response:**

```json
{
  "balance": 1500.0
}
```

---

### 5. 📈 Get Investment History

```http
GET /api/investors/{investorId}/history
```

**Response:**

```json
[
  {
    "id": "investment-id-guid",
    "investorId": "investor-guid",
    "opportunity": {
      "id": "11111111-1111-1111-1111-111111111111",
      "name": "Real Estate Fund",
      "minimumAmount": 1000
    },
    "amount": 2000,
    "date": "2025-07-05T21:00:00Z"
  }
]
```

---

## 🔪 API Testing

Use:

* [Swagger UI](https://localhost:{port}/swagger)
* Or tools like Postman

---
