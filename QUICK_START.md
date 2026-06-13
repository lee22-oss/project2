# IT Project Calculator - Быстрый старт

## 🚀 Шаги для запуска приложения

### Шаг 1: Откройте PowerShell в папке проекта

```bash
cd C:\Users\ARTELPC\project2
```

### Шаг 2: Очистите кэш и пересоберите

```bash
# Полная очистка
dotnet clean

# Очистить NuGet кэш
dotnet nuget locals all --clear

# Восстановить пакеты (БЕЗ кэша)
dotnet restore --no-cache

# Пересобрать проект
dotnet build
```

**Дождитесь сообщения: `Build succeeded`** ✅

---

### Шаг 3: Откройте Visual Studio 2022

1. **File → Open → Solution** → выберите **`project2.sln`**
2. **Дождитесь загрузки проекта**

---

### Шаг 4: Создайте базу данных

**В Visual Studio:**

1. **Tools → NuGet Package Manager → Package Manager Console**
2. Убедитесь, что в выпадающем меню выбран проект **`ITProjectCalculator.Data`**
3. Выполните команды:

```powershell
Add-Migration InitialCreate
Update-Database
```

**Если выпадет ошибка, выполните эту команду:**

```powershell
Update-Database -ContextTypeName ApplicationDbContext
```

✅ **База данных готова!**

---

### Шаг 5: Запустите приложение

1. В **Solution Explorer** нажмите правую кнопку на **`ITProjectCalculator.Web`**
2. Выберите **"Set as Startup Project"**
3. Нажмите **F5** или кнопку **Run** (зеленая стрелка) в верхней части Visual Studio

**Приложение откроется на:** `https://localhost:5001` 🎉

---

## 🔧 Если что-то не работает

### Ошибка при миграции БД

```powershell
# Удалите последнюю миграцию
Remove-Migration

# Попробуйте снова
Add-Migration InitialCreate
Update-Database
```

### Ошибка "Port 5001 is already in use"

Измените порт в файле `ITProjectCalculator.Web\Properties\launchSettings.json`:

```json
"https": "https://localhost:5002"
```

### Все еще ошибки?

Закройте Visual Studio и выполните в PowerShell:

```bash
cd C:\Users\ARTELPC\project2
dotnet clean
rmdir bin, obj -Recurse -Force
dotnet restore --no-cache
dotnet build
```

---

## 📝 Информация о входе

**В тестовом режиме приложение позволяет войти с любым email:**

- Нажмите **"Login"**
- Введите любой email
- Вы будете залогинены как администратор

---

## ✨ Основные возможности

✅ Управление пользователями
✅ Рабочие области
✅ Управление проектами
✅ Расчет стоимости проектов
✅ Реестры (Исполнители, Оборудование, Заказчики)
✅ Генерация документов (PDF, Excel, Word)

---

## 📚 Дополнительная информация

- **Документация Blazor:** https://learn.microsoft.com/en-us/aspnet/core/blazor/
- **Entity Framework Core:** https://learn.microsoft.com/en-us/ef/core/
- **Репозиторий:** https://github.com/lee22-oss/project2

---

**Если возникли проблемы, проверьте окно "Output" в Visual Studio для подробных ошибок!** 🔍
