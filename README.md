# IT Project Calculator

A comprehensive Blazor Web Application for calculating IT project development costs.

## Features

- **User Management**: Create and manage users with role-based access control
  - Global Administrator
  - Commercial Director
  - Accountant
  - HR Manager

- **Workspace Management**: Organize projects into workspaces with controlled access

- **Project Management**: Create and manage projects with resource planning

- **Cost Calculation**: Automatically calculate project costs with:
  - Cost of development
  - Cost of intangible assets (NMA)
  - Commercial proposal costs
  - Tax calculations
  - Margin calculations
  - Net profit calculations

- **Registries**:
  - Executor Registry (Individual entrepreneurs and self-employed)
  - Equipment Registry
  - Customer Registry
  - Employee Registry

- **Document Generation**:
  - NMA (Intangible Asset) Documents
  - Commercial Proposals
  - Export to PDF, Excel, and Word formats

- **Resource Management**: Track and manage all project resources with detailed cost calculations

## Technology Stack

- **Framework**: Blazor WebAssembly
- **Language**: C# .NET 8.0
- **Database**: Entity Framework Core with SQL Server
- **UI**: Bootstrap 5
- **Document Generation**: QuestPDF, ClosedXML, DocumentFormat.OpenXml

## Project Structure

```
project2/
├── ITProjectCalculator.Web/          # Blazor WebAssembly UI
│   ├── Pages/                       # Razor components
│   ├── Components/                  # Reusable components
│   └── wwwroot/                     # Static assets
│
├── ITProjectCalculator.Data/         # Data layer
│   ├── Context/                     # DbContext
│   └── Entities/                    # Database entities
│
├── ITProjectCalculator.Services/    # Business logic
│   ├── Interfaces/                  # Service interfaces
│   └── Implementations/             # Service implementations
│
└── project2.sln                     # Solution file
```

## Getting Started

### Prerequisites

- .NET 8.0 SDK or later
- Visual Studio 2022 or VS Code
- SQL Server (local or cloud)

### Installation

1. Clone the repository
2. Open `project2.sln` in Visual Studio
3. Restore NuGet packages
4. Configure database connection in `appsettings.json`
5. Run migrations: `dotnet ef database update`
6. Run the application

## Configuration

Update `appsettings.json` with your database connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=ITProjectCalculator;Trusted_Connection=true;"
  }
}
```

## Cost Calculation Formulas

### Executor Cost
```
su = ((cez * suz) + ((cez * suz) * ns))
```
Where:
- su = Service cost
- cez = Quantity of measurement units
- suz = Cost per unit
- ns = Tax rate (%)

### Equipment Cost
```
su = (cez * soz)
```
Where:
- su = Service cost
- cez = Quantity of measurement units
- soz = Cost per unit

### Resource Total Cost
```
i = s * (1 + m/100)
```
Where:
- i = Total cost
- s = Cost price
- m = Margin (%)

### Project Cost with Tax
```
isp = sp + (sp * ns)
```
Where:
- isp = Project total cost with tax
- sp = Project total cost without tax
- ns = Tax rate (%)

### Net Profit
```
p = Σ(i - s)
```
Where:
- p = Net profit
- i = Service total cost
- s = Service cost price

## API Endpoints (To be implemented)

- `GET /api/users` - Get all users
- `POST /api/users` - Create user
- `PUT /api/users/{id}` - Update user
- `DELETE /api/users/{id}` - Delete user

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Submit a pull request

## License

MIT License

## Support

For issues and questions, please create an issue in the repository.
