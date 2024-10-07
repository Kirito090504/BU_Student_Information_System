# Baliuag University Student Information System

This repository contains the source files for the Baliuag University Student
Information System, a project for the _Developing .NET Solutions_ (WAM1) class.

## Requirements

To start contributing, you should have the following in your development
environment:

- Visual Studio 2019/2022
- .NET Framework v4.8
- XAMPP v8.2.12 or Podman v5.2.3

## Setup (Server via Podman)

Set up the MySQL server using the Podman Compose configuration file.

```powershell
cd .\Server
podman-compose up -d
```

Navigate to <http://localhost:32512> and login with the following credentials:

| Property | Value     |
| -------- | --------- |
| Server   | `db`      |
| Username | `root`    |
| Password | \<empty\> |

Create a new database with the name `bu_student_information_system` and import
the `db_schema.sql` file.

## Setup (Server via XAMPP)

Run XAMPP and start Apache and MySQL. Navigate to <http://localhost/phpmyadmin>
and create a new database with the name `bu_student_information_system` and
import the `db_schema.sql` file.
