# Loan Platform

This is a digital loan platform designed to help individuals who lend money manage their loans, track transactions, and access comprehensive reports.

## 🚀 Features

- **Loan Management**: Create, update, and track loan details.
- **Transaction Tracking**: Record payments and disbursements.
- **Reporting**: Generate detailed reports on loan performance and transactions.
- **Modern UI**: Built with Blazor and MudBlazor for a responsive and intuitive user experience.

## 🛠️ Tech Stack

- **Framework**: .NET 10.0
- **UI**: Blazor Web App
- **Component Library**: MudBlazor
- **Database**: Entity Framework Core (In-memory for development)
- **Architecture**: Clean Architecture with Domain, Application, and Infrastructure layers.

## 📂 Project Structure

```
Loan-Platform/
├── Domain/             # Business entities and interfaces
├── Application/        # Application logic and use cases
├── Infrastructure/     # Data access and external services
├── Web/                # Blazor Web App (UI)
│   ├── Components/     # UI Components (Layout, Pages, Shared)
│   ├── Services/       # Client-side services
│   └── wwwroot/        # Static assets
└── Loan-Platform.sln   # Solution file
```

## ⚙️ Setup & Installation

1.  **Clone the repository** (if not already done).
2.  **Restore NuGet packages**:
    ```bash
    dotnet restore
    ```
3.  **Run the application**:
    ```bash
    dotnet run --project Web/Web.csproj
    ```

## 🎨 UI Theme

The application uses a custom theme with a "Tropical" aesthetic, featuring a palette of deep teals, muted greens, and ash greys.

- **Primary**: `#52796f` (Deep Teal)
- **Secondary**: `#84a98c` (Muted Teal)
- **Background**: `#f4f6f3` (Ash Grey 900)

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## 📄 License

This project is licensed under the MIT License.
