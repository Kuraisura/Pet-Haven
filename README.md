# Pet Haven

A Windows pet-shop POS project for managing products, customers, billing, and printable receipts.

**Windows** · **School Project** · 2024

[Portfolio](https://kuraisler.xyz)

## Purpose

Pet Haven models the daily counter workflow of a pet shop: maintain product and customer records, prepare a sale, calculate payment and change, and retain transaction information. It brings these related activities into one desktop interface.

## Intended users

Pet-shop cashiers and administrators managing product inventory, customer information, and cash sales in a small-shop scenario.

## Main capabilities

- Maintain employee, product, and customer records.
- Browse inventory by product or animal category.
- Build a bill and calculate cash payment and change.
- Review transactions and generate PDF receipts with QR codes.

## How it was built

### Desktop workflow

C# Windows Forms on .NET Framework 4.7.2 implements separate screens for inventory, customer management, billing, and transactions.

### Database access

ADO.NET SqlConnection and SqlCommand operations connect forms to SQL Server LocalDB. The database stores the core shop records.

### Receipts and interface

iTextSharp and QRCoder create branded PDF receipts and transaction codes. Guna.UI2 provides styled Windows controls.

## Technology stack

| Responsibility | Technologies |
| --- | --- |
| Windows application | C#, .NET Framework 4.7.2, Windows Forms |
| Database | SQL Server LocalDB, ADO.NET |
| Interface | Guna.UI2 |
| Receipts | iTextSharp, QRCoder |

## Project scope and current state

A school desktop project demonstrating a pet-shop POS workflow. It requires a Windows environment and configured LocalDB database; its login and transaction flows should be reviewed before real business use.

## Source guide

- [`Pet Haven/`](Pet%20Haven/)
- [`Pet Haven/DbConnect.cs`](Pet%20Haven/DbConnect.cs)
- [`Pet Haven/BillingForm.cs`](Pet%20Haven/BillingForm.cs)

## Development setup

Open the project under Pet Haven/ in Visual Studio on Windows with the .NET desktop workload and .NET Framework 4.7.2 targeting pack. Restore NuGet packages and configure SQL Server LocalDB for your development machine. Verify the schema with sample data before trying billing and receipt workflows.

## Screenshots

<table>
<tr>
<td align="center"><img src="screenshots/1.png" alt="Application launch" width="440"><br>Application launch</td>
<td align="center"><img src="screenshots/2.png" alt="Employee authentication" width="440"><br>Employee authentication</td>
</tr>
</table>

<details>
<summary>View all 8 screenshots</summary>

### 1. Application launch

![Application launch](screenshots/1.png)

### 2. Employee authentication

![Employee authentication](screenshots/2.png)

### 3. Manager dashboard

![Manager dashboard](screenshots/3.png)

### 4. Inventory snapshot

![Inventory snapshot](screenshots/4.png)

### 5. Customer onboarding

![Customer onboarding](screenshots/5.png)

### 6. Product catalog management

![Product catalog management](screenshots/6.png)

### 7. Point-of-Sale checkout

![Point-of-Sale checkout](screenshots/7.png)

### 8. Post-sale confirmation

![Post-sale confirmation](screenshots/8.png)

</details>

---

Project by [Mark Crysler Baddo](https://github.com/Kuraisura) · [Portfolio](https://kuraisler.xyz)
