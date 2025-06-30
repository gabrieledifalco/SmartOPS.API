# SmartOPS.API (WORK IN PROGRESS)

SmartOPS is a lightweight .NET-based backend application that simulates **Job execution** for **Supply Chain Management** in small-to-medium-sized businesses.

## Overview

The system is designed with a **multi-tenancy** approach (shared database and shared schema) to manage operations for multiple companies, ensuring data isolation per tenant.

Each **Job** represents a high-level supply chain task (e.g., Inventory Sync, Shipment Scheduling, Order Processing), and is composed of **MicroJobs**, which simulate fast, atomic subtasks.

## Authentication

The application implements **JWT token-based authentication**, with three user roles:

- **Viewer**:  
  - Can view all jobs related to their company.  
  - Has read-only access to scheduled, running, completed, or failed jobs.

- **Operator**:  
  - Inherits Viewer permissions.  
  - Can trigger new jobs and monitor execution progress.

- **Admin**:  
  - Has full access to manage users and all company-related jobs.  
  - Can create/edit/delete users and control job scheduling rules.

## Purpose

This project is intended as a **demonstration for portfolio purposes**, showcasing:

- Role-based access control
- Multi-tenancy logic
- Token-based secure API design
- Strategic decomposition of complex jobs into micro-executions

## Technologies

- .NET 8 (Web API)
- Entity Framework Core
- JWT Authentication
- SQL Server / SQLite (depending on configuration)
