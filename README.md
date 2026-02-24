# 🐉 DnD 5.5e Sheet Manager API

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat&logo=dotnet&logoColor=white)]()
[![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=c-sharp&logoColor=white)]()
[![EFCore](https://img.shields.io/badge/Entity_Framework_Core-0078D4?style=flat&logo=.net&logoColor=white)]()
[![MySQL](https://img.shields.io/badge/MySQL-4479A1?style=flat&logo=mysql&logoColor=white)]()
[![Tests](https://img.shields.io/badge/Tests-52_Passing-success)]()

------------------------------------------------------------------------

## 📖 Overview

Enterprise-level RESTful API for managing **Dungeons & Dragons 5.5e**
character sheets.

Built with modern backend architecture principles, the project
demonstrates:

-   Clean Architecture
-   Domain-Driven Design (DDD)
-   SOLID principles
-   Automated Testing
-   Robust Validation Layer
-   Production-ready structure

------------------------------------------------------------------------

# 🏗 Architecture

The solution follows a layered architecture pattern:

    API → Application → Domain → Infrastructure → Tests

### 🔹 Domain Layer

-   Aggregate Root: `Character`
-   Value Objects:
    -   AbilityScores
    -   Skills (+ Expertise)
    -   SavingThrows
    -   SpellSlots
    -   ArmorClass
    -   DamageResistances
    -   Conditions
    -   Entities:
        -   Feature
        -   Attack
        -   CharacterItem
        -   CharacterSpell
        -   CharacterResource

------------------------------------------------------------------------

# ⚙ Core Features

## Character System

-   Level (1--20)
-   Automatic proficiency scaling
-   Hit Points (current/max)
-   Hit Dice system
-   Passive Perception
-   Initiative
-   Speed
-   Custom Armor Class calculation

## Combat Engine

-   Melee and ranged attacks
-   Finesse support
-   Attack bonus calculation
-   Spell Save DC
-   Spell Attack Bonus

## Magic System

-   Spell Slots (1--9)
-   Slot consumption & restoration
-   Spellbook management
-   Long/Short Rest recovery rules

## Resource Management

-   Class features with usage limits
-   Short/Long rest reset rules
-   Currency system (CP, SP, EP, GP, PP)
-   Inventory with automatic weight tracking

## Conditions & Damage

-   14+ conditions supported
-   Exhaustion levels (0--6)
-   Damage resistances, immunities, vulnerabilities
-   Automatic damage calculation logic

------------------------------------------------------------------------

# 🛡 Validation Layer

All DTOs implement strict validation using Data Annotations.

Examples:

-   Character level range validation (1--20)
-   Ability scores range (1--30)
-   Damage dice regex validation (NdN+N format)
-   Required string length constraints
-   Enum-based validation for feature sources and rest types

------------------------------------------------------------------------

# 🧪 Automated Testing

  Category            Tests    Status
  ------------------- -------- ------------------
  DTO Validation      15       ✅
  Character Logic     13       ✅
  AbilityScores       10       ✅
  SpellSlots          5        ✅
  DamageResistances   5        ✅
  Features            4        ✅
  **Total**           **52**   **100% Passing**

------------------------------------------------------------------------

# 🚀 Running the Project

### 1️⃣ Clone Repository

``` bash
git clone https://github.com/VictoRGBC/DnDSheetManager.git
```

### 2️⃣ Apply Migrations

``` bash
dotnet ef database update --project Infrastructure --startup-project API
```

### 3️⃣ Run API

``` bash
dotnet run --project API
```

### 4️⃣ Access Documentation

    https://localhost:7252/scalar/v1

------------------------------------------------------------------------

# 📈 Technical Highlights

-   Repository Pattern implementation
-   Service Layer abstraction
-   Separation of concerns
-   AsNoTracking for read performance
-   Circular reference handling
-   JSON serialization configuration
-   Clean dependency injection setup

------------------------------------------------------------------------

# 👨‍💻 Author

Victor Gabriel Barros\
Backend Developer (.NET / C#)

GitHub: https://github.com/VictoRGBC

------------------------------------------------------------------------

# 📄 License

MIT License

------------------------------------------------------------------------

⭐ Enterprise-Level Backend Project\
Demonstrating real-world architecture and production standards.
