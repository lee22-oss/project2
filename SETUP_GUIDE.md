# 🚀 Руководство по установке и запуску

## Системные требования

- **Windows 10+**, **macOS** или **Linux**
- **.NET 8.0 SDK** или новее ([скачать](https://dotnet.microsoft.com/download/dotnet/8.0))
- **Visual Studio 2022** (Community, Professional или Enterprise)
  - Или **VS Code** с расширением C#
- **SQL Server** (LocalDB входит в Visual Studio)
- **Git**

---

## Шаг 1: Установка .NET SDK

### Windows

1. Перейдите на https://dotnet.microsoft.com/download/dotnet/8.0
2. Скачайте **Windows (x64)** installer
3. Запустите установщик и следуйте инструкциям
4. Проверьте установку:

```bash
dotnet --version
```

### macOS

```bash
brew install dotnet-sdk-8.0
```

### Linux (Ubuntu/Debian)

```bash
wget https://dot.net/v1/dotnet-install.sh
sudo bash dotnet-install.sh --version 8.0
```

---

## Шаг 2: Клонирование репозитория

```bash
git clone https://github.com/lee22-oss/project2.git
cd project2
```

---

## Шаг 3: Откройте проект в Visual Studio

### Способ 1: Через Visual Studio 2022

1. Откройте **Visual Studio 2022**
2. Нажмите **"Open a project or solution"**
3. Перейдите в папку `project2`
4. Выберите файл **`project2.sln`**
5. Нажмите **Open**

### Способ 2: Через командную строку

```bash
cd project2
start project2.sln  # Windows
# или
open project2.sln   # macOS
```

---

## Шаг 4: Восстановление NuGet пакетов

### В Visual Studio

1. **Меню** → **Tools** → **NuGet Package Manager** → **Package Manager Console**
2. Выполните:

```powershell
Update-Package
```

ИЛИ нажмите **"Restore NuGet Packages"** в Solution Explorer

### Через командную строку

```bash
dotnet restore
```

---

## Шаг 5: Проверьте строку подключения БД

1. Откройте файл **`appsettings.json`** в корне проекта
2. Проверьте строку подключения (по умолчанию она уже настроена для LocalDB):

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=ITProjectCalculator;Integrated Security=true;TrustServerCertificate=True"
  }
}
```

**Если у вас SQL Server Express:**

```json
"DefaultConnection": "Server=localhost;Database=ITProjectCalculator;Integrated Security=true;TrustServerCertificate=True"
```

**Если у вас Azure SQL или облако:**

```json
"DefaultConnection": "Server=YOUR_SERVER.database.windows.net;Database=ITProjectCalculator;User Id=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=True"
```

---

## Шаг 6: Создание и обновление базы данных

### В Visual Studio (Package Manager Console)

```powershell
Add-Migration InitialCreate
Update-Database
```

### Или через командную строку

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

## Шаг 7: Запуск приложения

### В Visual Studio

1. Выберите в Solution Explorer проект **`ITProjectCalculator.Web`** как Startup Project
   - Кликните правой кнопкой → **"Set as Startup Project"**

2. Нажмите **F5** или кнопка **"Run"** (зеленая стрелка)

3. Приложение откроется в браузере на `https://localhost:5001`

### Через командную строку

```bash
cd ITProjectCalculator.Web
dotnet run
```

Приложение будет доступно по адресу:
- **HTTPS:** https://localhost:5001
- **HTTP:** http://localhost:5000

---

## Шаг 8: Первый вход

1. Когда откроется приложение, нажмите **"Login"** или перейдите по ссылке `/login`
2. Используйте любой email (система в dev режиме)
3. После входа вы получите доступ ко всем функциям

---

## Решение проблем

### Проблема: "Cannot connect to database"

**Решение:**

```bash
# Проверьте SQL Server status (Windows)
sqllocaldb info mssqllocaldb

# Запустите SQL Server
sqllocaldb start mssqllocaldb
```

### Проблема: "NuGet packages not found"

```bash
dotnet nuget add source https://api.nuget.org/v3/index.json --name nuget.org
dotnet restore
```

### Проблема: "Port 5001 is already in use"

Измените порт в `launchSettings.json`:

```json
"https": "https://localhost:5002"  // вместо 5001
```

### Проблема: SSL Certificate Error

```bash
dotnet dev-certs https --trust
```

---

## 📁 Структура проекта

```
project2/
├── ITProjectCalculator.Web/              # Blazor UI
│   ├── Pages/
│   │   ├── Index.razor                  # Главная
│   │   ├── Users.razor                  # Управление пользователями
│   │   └── Workspaces.razor             # Управление рабочими областями
│   ├── Components/                      # Переиспользуемые компоненты
│   ├── wwwroot/                         # Статические файлы
│   ├── _Imports.razor                   # Глобальные импорты
│   ├── App.razor                        # Корневой компонент
│   ├── MainLayout.razor                 # Основной макет
│   ├── NavMenu.razor                    # Навигационное меню
│   ├── Program.cs                       # Точка входа
│   └── ITProjectCalculator.Web.csproj   # Файл проекта
│
├── ITProjectCalculator.Data/             # Data Layer
│   ├── Context/
│   │   └── ApplicationDbContext.cs      # DbContext
│   ├── Entities/                        # Модели БД
│   │   ├── User.cs
│   │   ├── Workspace.cs
│   │   ├── Project.cs
│   │   ├── Executor.cs
│   │   ├── Equipment.cs
│   │   ├── Customer.cs
│   │   └── CompanySettings.cs
│   └── ITProjectCalculator.Data.csproj
│
├── ITProjectCalculator.Services/         # Business Logic
│   ├── Interfaces/                      # Контракты сервисов
│   │   ├── IAuthenticationService.cs
│   │   ├── IUserService.cs
│   │   ├── IProjectService.cs
│   │   ├── ICostCalculationService.cs
│   │   ├── IDocumentGenerationService.cs
│   │   └── ...
│   ├── AuthenticationService.cs         # Реализации
│   ├── UserService.cs
│   ├── CostCalculationService.cs
│   └── ITProjectCalculator.Services.csproj
│
├── project2.sln                         # Solution файл
├── appsettings.json                     # Конфигурация
└── README.md
```

---

## 🔧 Разработка

### Добавление новой страницы

1. Создайте файл в `Pages/`
2. Пример файла `MyPage.razor`:

```razor
@page "/mypage"
@using ITProjectCalculator.Services.Interfaces
@inject IUserService UserService

<h1>My Page</h1>

@code {
    protected override async Task OnInitializedAsync()
    {
        // Логика инициализации
    }
}
```

### Добавление нового сервиса

1. Создайте интерфейс в `ITProjectCalculator.Services/Interfaces/`
2. Создайте реализацию в `ITProjectCalculator.Services/`
3. Зарегистрируйте в `Program.cs`:

```csharp
builder.Services.AddScoped<IMyService, MyService>();
```

---

## 📝 Полезные команды

```bash
# Восстановить пакеты
dotnet restore

# Построить проект
dotnet build

# Запустить проект
dotnet run

# Создать миграцию
dotnet ef migrations add MigrationName

# Применить миграции
dotnet ef database update

# Откатить базу
dotnet ef database update 0

# Опубликовать
dotnet publish -c Release
```

---

## 🌐 Развертывание

### На Azure

1. Установите Azure CLI
2. Выполните:

```bash
az login
az webapp create --resource-group myGroup --plan myPlan --name myApp --runtime "dotnetcore:8.0"
```

### На собственном сервере

```bash
dotnet publish -c Release
# Скопируйте содержимое папки /bin/Release/net8.0/publish на сервер
```

---

## 📞 Поддержка

Если у вас возникли проблемы:

1. Проверьте логи консоли
2. Посмотрите Visual Studio **Output** окно
3. Создайте Issue в GitHub репозитории

---

**Готово! Теперь вы можете начать разработку!** 🎉
