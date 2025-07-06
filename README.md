# MiniInvestmentWalletApi
Focus: C# (.NET Core), Clean Architecture, Domain-Driven Design, CQRS, REST API
# 💼 Mini Investment Wallet API

A backend-only API built using **ASP.NET Core (.NET 8)** following Clean Architecture and Domain-Driven Design (DDD) principles. It simulates a fintech wallet platform for investor account creation, wallet funding, and investing in static opportunities.

> ⚠️ **.NET 7 is no longer supported**, so this project targets **.NET 8** to ensure long-term stability and support.
> See [.NET Support Policy](https://dotnet.microsoft.com/en-us/platform/support/policy/dotnet-core) for details.

---

## 🔧 Tech Stack

- ASP.NET Core 8
- Entity Framework Core with PostgreSQL
- Clean Architecture
- MediatR (CQRS pattern)
- Domain-Driven Design (DDD)
- Dependency Injection
- Swagger for API documentation

---

## 📂 Project Structure

MiniInvest/

├── MiniInvest.API # API layer (Controllers, Swagger, DI) 

├── MiniInvest.Application # CQRS Commands, Queries, Handlers, Interfaces

├── MiniInvest.Domain # Core business entities (Investor, Investment, etc.)

├── MiniInvest.Infrastructure # EF Core DbContext, PostgreSQL, Repository implementation

└── MiniInvestmentWalletApi.sln # Solution file


Recommended credentials:
Username: postgres, Password: 123qwe




Run Migrations: 
dotnet ef database update --startup-project ./MiniInvest.API


Run the API: 
dotnet run --project ./MiniInvest.API


Example API Requests
1. Create Investor
POST /api/investors

{
  "name": "Ahmed Emad",
  "email": "ahmed@test.com"
}
🟢 Response: 200 OK with investorId (GUID)



2. Fund Wallet
POST /api/investors/{investorId}/fund

{
  "amount": 5000
}
🟢 Response: 200 OK



 3. Make Investment
POST /api/investors/{investorId}/invest

{
  "opportunityId": "11111111-1111-1111-1111-111111111111",
  "amount": 2000
}
🟢 Response: 200 OK



4. Get Wallet Balance
GET /api/investors/{investorId}/balance

🟢 Response:
1500.0




5. Get Investment History
GET /api/investors/{investorId}/history

🟢 Response:
[
  {
    "id": "investment-id-guid",
    "investorId": "investor-guid",
    "opportunity": {
      "id": "1111...",
      "name": "Real Estate Fund",
      "minimumAmount": 1000
    },
    "amount": 2000,
    "date": "2025-07-05T21:00:00Z"
  }
]
