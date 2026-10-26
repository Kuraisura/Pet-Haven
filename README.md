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

## Screenshot and module walkthrough

Expand a screen below to see the capture and an explanation of the module, its visible controls, and its role in the application.

<details open>
<summary><strong>01 · Startup loading screen</strong></summary>

Pet Haven branding and a progress bar introduce the Windows application. This screen precedes account entry and the shop-management workspace.

<p><img src="screenshots/1.png" alt="Startup loading screen" width="960"></p>

</details>

<details>
<summary><strong>02 · Staff login</strong></summary>

Username and password fields open the staff session. The split layout keeps shop branding beside the login form; the screenshot documents the interface rather than the strength of its authentication.

<p><img src="screenshots/2.png" alt="Staff login" width="960"></p>

</details>

<details>
<summary><strong>03 · Main workspace and daily sales</strong></summary>

Navigation provides access to dashboard, customer, employee, product, and billing modules. A daily-report area displays the current sales total and a reset action, giving staff a persistent operational summary.

<p><img src="screenshots/3.png" alt="Main workspace and daily sales" width="960"></p>

</details>

<details>
<summary><strong>04 · Inventory category summary</strong></summary>

Dog, cat, fish, and bird cards display category counts with a refresh control. This dashboard gives staff a quick view of the animal-category records represented in the inventory.

<p><img src="screenshots/4.png" alt="Inventory category summary" width="960"></p>

</details>

<details>
<summary><strong>05 · Customer registration and editing</strong></summary>

A customer list sits behind a modal collecting name, address, and phone number. Save, Update, and Cancel support adding or revising customer records used by the sales workflow.

<p><img src="screenshots/5.png" alt="Customer registration and editing" width="960"></p>

</details>

<details>
<summary><strong>06 · Product registration and stock fields</strong></summary>

The product modal captures name, type, animal category, quantity, and price. Its actions maintain the inventory records that cashiers select during billing.

<p><img src="screenshots/6.png" alt="Product registration and stock fields" width="960"></p>

</details>

<details>
<summary><strong>07 · Bill composition and checkout</strong></summary>

Selected products appear with quantity, unit price, line totals, and transaction number. Add Product, quantity controls, removal actions, and Check Out let the cashier assemble and review a sale.

<p><img src="screenshots/7.png" alt="Bill composition and checkout" width="960"></p>

</details>

<details>
<summary><strong>08 · Daily total after a sale</strong></summary>

The billing list is empty while the daily-report total has increased compared with the previous capture. It illustrates the post-sale workspace and updated summary; a receipt document itself is not shown.

<p><img src="screenshots/8.png" alt="Daily total after a sale" width="960"></p>

</details>

---

Project by [Mark Crysler Baddo](https://github.com/Kuraisura) · [Portfolio](https://kuraisler.xyz)
