# Radius Core
Thank you for your interest in the Radius HMI Core Application. ___We take pull requests!___

## Introduction
Radius Core is a component of the Radius HMI application. The Radius Core is what provides the gateway to other Radius Plugins, interface, and/or any other external component.

![Radius HMI Core](https://github.com/Radius-HMI/RadiusCore/blob/master/Documents/Images/RadiusUserOverviewCore.png)

## Installation
### Prerequisites
* Microsoft .Net Framework 4.5.2
* SQL Server 2014 or Higher
* IIS 7 or Higher

### Installation Steps
1. Create __RadiusData__ database in SQL Server.
2. Run __RadiusDB.sql__ on Database to create SQL objects.
3. Modify __DefaultConnection__ Conection String in Web.config to match the database configuration.
4. Deploy project to IIS

## How to Contribute
* Documentation needs to be fleshed out.
* The application needs to transition to ASP.Net Core
* SQL code needs to transition to stored procedures
* External components independent of the Core project needed:
  * Web Interface
  * Plugins
    * IO
    * Aggregation
    * Historical
    * Alarming
