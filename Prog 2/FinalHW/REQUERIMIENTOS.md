# Requerimientos del Proyecto - Sistema de Gestión de Estaciones de Autobús

## 📋 Descripción General
Sistema completo para la gestión de estaciones de autobús, implementado con arquitectura Clean Architecture usando .NET 9 y Blazor Server.

## 🏗️ Arquitectura del Sistema

### Estructura de Proyectos
- **BusStationAPI.API** - API REST con Swagger
- **BusStationAPI.Domain** - Entidades y interfaces del dominio
- **BusStationAPI.Application** - Lógica de negocio y DTOs
- **BusStationAPI.Infrastructure** - Acceso a datos y Entity Framework
- **FinalHW2.5** - Aplicación Blazor Server (Frontend)

## 🎯 Funcionalidades Principales

### 1. API REST (BusStationAPI.API)
#### Endpoints Requeridos:
- `GET /api/BusStations` - Obtener todas las estaciones
- `GET /api/BusStations/{id}` - Obtener estación por ID
- `POST /api/BusStations` - Crear nueva estación
- `PUT /api/BusStations/{id}` - Actualizar estación existente
- `DELETE /api/BusStations/{id}` - Eliminar estación
- `GET /health` - Health check con estado de BD

#### Características Técnicas:
- Documentación automática con Swagger UI
- Manejo de errores con respuestas HTTP apropiadas
- CORS configurado para comunicación con Blazor
- Migraciones automáticas de base de datos

### 2. Frontend Blazor (FinalHW2.5)
#### Páginas Requeridas:
- **Lista de Estaciones** - Visualización de todas las estaciones
- **Formulario de Estación** - Crear/editar estaciones
- **Navegación** - Menú de navegación intuitivo

#### Funcionalidades:
- Operaciones CRUD completas desde la interfaz
- Validaciones en tiempo real
- Interfaz responsive con Bootstrap
- Comunicación con API mediante HttpClient

## 📊 Modelo de Datos

### Entidad BusStation
```csharp
public class BusStation
{
    public int Id { get; set; }                    // Clave primaria
    public string Name { get; set; }               // Nombre (requerido, 3-255 chars)
    public string City { get; set; }               // Ciudad (requerido, 2-100 chars)
    public string Address { get; set; }            // Dirección (requerido, 5-500 chars)
    public string Phone { get; set; }              // Teléfono (requerido, formato válido)
    public DateTime CreatedAt { get; set; }        // Fecha de creación
    public DateTime? UpdatedAt { get; set; }       // Fecha de actualización
}
```

## 🔧 Requisitos Técnicos

### Framework y Versiones
- **.NET 9** - Framework principal
- **ASP.NET Core Web API** - Para la API REST
- **Blazor Server** - Para el frontend
- **Entity Framework Core 9.0** - ORM para base de datos
- **SQL Server** - Base de datos principal

### Paquetes NuGet Principales
- `Swashbuckle.AspNetCore 6.5.0` - Documentación Swagger
- `Microsoft.EntityFrameworkCore.Design 9.0.0`
- `Microsoft.EntityFrameworkCore.SqlServer`
- `Bootstrap 5` - Framework CSS
- `Bootstrap Icons` - Iconografía

### Configuración de Base de Datos
- **Connection String**: Configurada en `appsettings.json`
- **Migraciones**: Aplicación automática al iniciar la API
- **Retry Policy**: Configurado para reconexión automática
- **Auditoría**: Timestamps automáticos (CreatedAt/UpdatedAt)

## 📋 Validaciones Requeridas

### Validaciones de Entrada
- **Nombre**: Obligatorio, 3-255 caracteres
- **Ciudad**: Obligatorio, 2-100 caracteres
- **Dirección**: Obligatorio, 5-500 caracteres
- **Teléfono**: Obligatorio, formato válido, 7-20 caracteres

### Manejo de Errores
- Respuestas HTTP estándar (200, 201, 404, 400, 500)
- Mensajes de error descriptivos en español
- Validación tanto en API como en Frontend

## 🚀 Características de Producción

### Seguridad y CORS
- Configuración CORS específica para puertos de desarrollo
- Manejo seguro de conexiones de base de datos
- Validación de entrada en múltiples capas

### Monitoreo
- Health check endpoint con información de estado
- Logging integrado con ASP.NET Core
- Contador de registros en health check

### Escalabilidad
- Arquitectura Clean separada en capas
- Inyección de dependencias configurada
- Patrón Repository para acceso a datos
- DTOs para transferencia de datos

## 🛠️ Configuración de Desarrollo

### Puertos por Defecto
- **API**: `https://localhost:7002` / `http://localhost:5002`
- **Blazor**: `https://localhost:7172` / `http://localhost:5181`
- **Swagger UI**: Disponible en la raíz de la API

### Base de Datos
- Migraciones automáticas en startup
- Seeding de datos opcional
- Conexión resiliente con retry policy

## ✅ Criterios de Aceptación

### Funcionales
- ✅ CRUD completo de estaciones de autobús
- ✅ Interfaz web intuitiva y responsive
- ✅ API REST documentada con Swagger
- ✅ Validaciones completas en frontend y backend
- ✅ Manejo apropiado de errores

### Técnicos
- ✅ Arquitectura Clean implementada
- ✅ Base de datos SQL Server funcional
- ✅ Comunicación entre Blazor y API
- ✅ Migraciones automáticas de BD
- ✅ Health check operativo
- ✅ Documentación Swagger accesible

## 📝 Notas de Implementación
- El proyecto sigue principios de Clean Architecture
- Separación clara entre capas de dominio, aplicación e infraestructura
- Uso de DTOs para separar modelos de dominio de transferencia
- Implementación de patrones Repository y Service
- Frontend reactivo con Blazor Server
- Configuración de desarrollo lista para uso inmediato