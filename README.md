# FunSueClient

# FunSueClient

[![.NET](https://img.shields.io/badge/.NET-6.0%2F7.0-blue?logo=dotnet)](https://dotnet.microsoft.com/)
[![Visual Studio](https://img.shields.io/badge/Visual%20Studio-2022+-purple?logo=visual-studio)](https://visualstudio.microsoft.com/)
[![Platform](https://img.shields.io/badge/Platform-Windows-lightgrey?logo=windows)](https://microsoft.com/windows)
[![License](https://img.shields.io/badge/License-Insert%20License%20Here-blue.svg)](#)

---

## Overview

**FunSueClient** is a .NET solution composed of multiple projects:

- **FunSueClient** — likely the main client library
- **FunSueClientConsole** — a console application
- **FunSueClientWPF** — a WPF (Windows Presentation Foundation) desktop application

The solution is intended to be built with **Visual Studio 2022** or newer.

---

## Project Structure

| Project | Type | Description |
| :--- | :--- | :--- |
| FunSueClient | Class Library (likely) | Core logic or API client functionality |
| FunSueClientConsole | Console Application | Command-line interface or test client |
| FunSueClientWPF | WPF Desktop Application | Graphical user interface |

---

## Requirements

- **Visual Studio 2022** or later
- **.NET 6.0** or **.NET 7.0** SDK
- **Windows OS** (required for WPF applications)

---

## Getting Started

### 1. Clone the Repository

```bash
git clone <repository-url>
```

### 2. Open the Solution

Open the `FunSueClient.sln` file in **Visual Studio 2022**.

### 3. Restore Dependencies

```bash
dotnet restore
```

---

## Build and Run

### Run Console Application

1. Set **FunSueClientConsole** as the startup project.
2. Press **F5** in Visual Studio, or run:

```bash
dotnet run --project FunSueClientConsole/FunSueClientConsole.csproj
```

### Run WPF Application

1. Set **FunSueClientWPF** as the startup project.
2. Press **F5** to launch the GUI.

---

## Solution Configurations

- `Debug | Any CPU` — for development and testing
- `Release | Any CPU` — for production builds
