# gatheringDataApp

A background service application that runs 24/7 on a box PC, collecting real-time production data from heterogeneous databases and synchronizing it across systems.

Built as part of a manufacturing MES project for an automotive parts manufacturer.

---

## Overview

In environments where multiple independent systems operate with different databases, keeping production data in sync is a challenge. This application continuously gathers shop floor data from a MSSQL-based MES database and transfers it into an Oracle-based central database — enabling cross-system data visibility without manual intervention.

---

## Solution Structure

```
gatheringDataApp/
├── ProdGatheringApp/       # Core service — real-time data gathering & DB sync
├── CryptoLib/              # Encryption library for securing DB connection strings
├── CryptoKeyGenerator/     # Utility to generate encryption keys for DB credentials
└── DbConfigEditor/         # GUI tool for operators to manage DB configuration
```

### ProdGatheringApp
The main application. Runs as a persistent process on a box PC on the shop floor. Periodically queries the source database and pushes production records to the target database. Designed to run unattended without user interaction.

### CryptoLib
A shared library for encrypting and decrypting database connection strings. Keeps sensitive credentials out of plain-text config files.

### CryptoKeyGenerator
A standalone utility for generating encryption keys used by CryptoLib. Used during initial setup or when credentials need to be rotated.

### DbConfigEditor
A GUI tool that allows operators to update database connection settings (host, database name, credentials) without directly editing config files. Works with CryptoLib to store settings securely.

---

## Tech Stack

| | |
|---|---|
| Language | C# |
| Framework | .NET Framework |
| Databases | MSSQL, Oracle |
| IDE | Visual Studio |

---

## Background

This project was developed during work on a MES system for KKL, a joint venture in the automotive parts manufacturing industry. The shop floor systems ran on MSSQL while the central management system used Oracle — this app bridges the two, ensuring production actuals are reflected in real time across both environments.
