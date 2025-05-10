# VerificacionReportesNivel3

Este es un proyecto ASP.NET Core 7 con Blazor WebAssembly (ASP.NET Core Hosted) y SQL Server. Permite:

- Verificar si un texto contiene el nombre de un cliente.
- Guardar los resultados de cada verificación.
- Visualizar estadísticas de verificaciones.
- Consultar historial de compras y productos más costosos.
- Mostrar clientes sin compras.
- Ejecutar procedimientos SQL y consumirlos vía API REST.

---

## 🚀 Tecnologías utilizadas

- ASP.NET Core 7
- Blazor WebAssembly
- Entity Framework Core
- SQL Server Developer Edition
- Swagger / Postman para pruebas

---

## 📂 Estructura del proyecto

- `VerificacionReportesNivel3.Client` → Frontend Blazor
- `VerificacionReportesNivel3.Server` → Backend Web API
- `VerificacionReportesNivel3.Shared` → Clases compartidas (DTOs / modelos)

---

## ⚙️ Requisitos

- Visual Studio 2022 o superior
- .NET SDK 7.0
- SQL Server (local o remoto)
- SSMS (SQL Server Management Studio) para cargar los scripts

---

## 🛠️ Instalación

### 1. Clona el repositorio

```bash
git clone https://github.com/tuusuario/VerificacionesReportesNivel3.git
cd VerificacionesReportesNivel3
