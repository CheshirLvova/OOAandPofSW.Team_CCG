![Banner.png](./docs/src/Banner.png)
___
# Team_CCG

## Team members:
  * Nazarii Horban
  * Sofiia Kovalchuk

## Project Overview
**TⓤO EMIT** is a click-and-point game where you need to solve puzzles in the shortest possible time. Check your ranking in the standings, discover new levels and don't forget about time.

## Project Description
  1. [Functional specifications, Identity Management and UML diagrams](./docs/FunctionalSpecification.md)
  2. [Architecture requirements](./docs/Architecture.md)

## Storage
We used Microsoft SQL Server for Debug. Microsoft SQL Server is a relational database management system (RDBMS) that supports a wide variety of transaction processing, business intelligence and analytics applications in corporate IT environments.

![Server.png](https://commons.bmstu.wiki/images/a/a2/Microsofttt.png)

However for the deployment we used Azure SQL Storage. Azure SQL Database is a fully managed platform as a service (PaaS) database engine that handles most of the database management functions such as upgrading, patching, backups, and monitoring without user involvement. Azure SQL Database is always running on the latest stable version of the SQL Server database engine and patched OS with 99.99% availability. PaaS capabilities that are built into Azure SQL Database enable us to focus on the domain-specific database administration and optimization activities.

![Azure.png](https://assets-global.website-files.com/5a1eb87c9afe1000014a4c7d/5d2eeb5d136a2e8373580725_azure.png)

## Resiliency model
Using Resilient Entity Framework Core SQL Connections and Transactions users retry on failure logic 10 retries every 30 seconds.

## Security model
For security model were added:
*	Cross-Site Request Forgery (CSRF) (with using Html.AntiForgeryToken () before forms);
*	Login secure (password has to have at least 1 uppercase leter, 1 lowercase letter and 1 number);
*	Authentication and Authorization using Microsoft.AspNetCore.Authentication and System.Security.Claims;
*	Data encryption (passwords hashed with MD5 algorithm before being saved to database);
*	Cleaning cookies on logout;
*	Using ssl (https);
*	Using LINQ on for access to the database for protection from SQL injection

## Hosted Service. Telemetry. Monitoring
Retry attempts are logged as unstructured trace messages through a .NET TraceSource. We configured a TraceListener to capture the events and write them to a suitable destination log.
Created hosted service to monitor app status and send mail in case of problems.


