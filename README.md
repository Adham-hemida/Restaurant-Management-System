# 🍽️ Restaurant Management System API

## 📖 Introduction
The **Restaurant Management System API** is a comprehensive backend solution for managing **restaurants**, built with **ASP.NET Core Web API** and following **Clean Architecture** principles.  

---
## 🚀 Features
- **Authentication & Authorization**
  - Secure login with JWT and Refresh Tokens
  - **Claims-based Authorization relies on permissions rather than fixed roles, making the system more flexible and scalable.**
  - Password reset & account management
- **User & Role Management**
  - The system provides full user and role management integrated with the claims-based permission system.
    Administrators can manage users, assign permissions, and control account statuses. Roles serve as permission bundles, but access is still enforced at the permission level.
- **Orders Management**
  - Create , get , update, and deliver orders
  - Manage order items and their statuses
- **Invoices**
  - Generate invoices linked to orders
  - Update payment methods and statuses
- **Menu & Categories**
  - Manage categories and menu items with file uploads (images)
  - Rate menu items
- **Tables**
  - Manage restaurant tables
  - Assign orders to tables
- **Dashboard**
  - Daily revenue reports
  - Orders by status
  - Top selling menu items
- **File Management**
  - Upload and download Images for menu items and other entities
- **Background Jobs**
  - Hangfire integration for scheduled jobs (e.g., sending notifications)
- **System Monitoring**
  - Health checks
  - Rate limiting per endpoint

---

## 🚀 Tech Stack

## 🛠️ Tech Stack
- **.NET 9 / ASP.NET Core Web API**
- **SQL Server**
- **Entity Framework Core**
- **CQRS with MediatR**
- **Clean Architecture**
- **Mapster (object mapping)**
- **Hangfire (Background Jobs)**
- **Solid Principles**
- **JWT Authentication & Claims-based Authorization  relies on permissions**
- **Health Check**
- **Rate Limiting**
- **Options Pattern**
- **Result Pattern** → Standardized responses across the API  
- **Scalar for API documentation**

---
### **Auth Endpoints** (`/Auth`)

| Method | Endpoint                     | Description             |
| ------ | ---------------------------- | ----------------------- |
| POST   | `/Auth`                      | Login                   |
| POST   | `/Auth/refresh`              | Refresh JWT token       |
| POST   | `/Auth/revoke-refresh-token` | Revoke refresh token    |
| POST   | `/Auth/forget-password`      | Start password reset    |
| POST   | `/Auth/reset-password`       | Complete password reset |

---
### **Profile Endpoints** (`/me`)

| Method | Endpoint              | Description              |
| ------ | --------------------- | ------------------------ |
| GET    | `/me`                 | Get current user profile |
| PUT    | `/me/info`            | Update profile info      |
| PUT    | `/me/change-password` | Change user password     |

---

### 👥Admin User Management (`/api/Users`)

| Method | Endpoint                       | Description        | Permission Required        |
| ------ | ------------------------------ | ------------------ | -------------------------- |
| GET    | `/api/Users/{id}`              | Get user by ID     | `Permissions.GetUsers`     |
| POST   | `/api/Users`                   | Create new user    | `Permissions.AddUsers`     |
| PUT    | `/api/Users/{id}`              | Update user        | `Permissions.UpdateUsers`  |
| PUT    | `/api/Users/{id}/toggle-status`| Toggle user status | `Permissions.UpdateUsers`  |
| PUT    | `/api/Users/{id}/unlock`       | Unlock user        | `Permissions.UpdateUsers`  |

---

### 🛡️ Roles (`/api/Roles`)

| Method | Endpoint                             | Description            | Permission Required       |
| ------ | ------------------------------------ | ---------------------- | ------------------------- |
| GET    | `/api/Roles?includeDisabled={bool}`  | Get all roles          | `Permissions.GetRoles`    |
| GET    | `/api/Roles/{id}`                    | Get role by ID         | `Permissions.GetRoles`    |
| POST   | `/api/Roles`                         | Create new role        | `Permissions.AddRoles`    |
| PUT    | `/api/Roles/{id}`                    | Update role            | `Permissions.UpdateRoles` |
| PUT    | `/api/Roles/{id}/toggle-status`      | Enable/Disable (Toggle) role status     | `Permissions.UpdateRoles` |

---

### 📊 Dashboard (`/api/Dashboards`)

| Method | Endpoint                        | Description                     | Permission Required     |
| ------ | ------------------------------- | ------------------------------- | ----------------------- |
| GET    | `/api/Dashboards/daily-revenue?date={date}` | Get daily revenue report        | `Permissions.Results`   |
| GET    | `/api/Dashboards/orders-by-status?date={date}` | Get daily orders grouped by status | `Permissions.Results`   |
| GET    | `/api/Dashboards/top-menu-items?date={date}` | Get top menu items for the day  | `Permissions.Results`   |

---

### 🖼️ File Uploads (`/api/Files`)

| Method | Endpoint                                   | Description                 | Permission Required       |
| ------ | ------------------------------------------ | --------------------------- | ------------------------- |
| POST   | `/api/Files/{menuItemId}/upload-image`     | Upload image for menu item  | `Permissions.UploadFiles` |

---

### 🍽️ Menu Categories (`/api/MenuCategories`)

| Method | Endpoint                              | Description                               | Permission Required              |
| ------ | ------------------------------------- | ----------------------------------------- | -------------------------------- |
| GET    | `/api/MenuCategories/{id}`            | Get menu category by ID                   | `Permissions.GetMenuCategories`  |
| GET    | `/api/MenuCategories/{id}/WithItems`  | Get menu category with its menu items     | `Permissions.GetMenuCategories`  |
| GET    | `/api/MenuCategories`                 | Get all menu categories (with filters)    | `Permissions.GetMenuCategories`  |
| POST   | `/api/MenuCategories`                 | Create new menu category                  | `Permissions.AddMenuCategories`  |
| PUT    | `/api/MenuCategories/{id}`            | Update menu category                      | `Permissions.UpdateMenuCategories` |
| PUT    | `/api/MenuCategories/{id}/toggleStatus` | Enable/Disable (toggle) menu category   | `Permissions.UpdateMenuCategories` |

---

### 🍔 Menu Items (`/api/MenuCategories/{menuCategoryId}/MenuItems`)

| Method | Endpoint                                                                 | Description                          | Permission Required        |
| ------ | ------------------------------------------------------------------------ | ------------------------------------ | -------------------------- |
| GET    | `/api/MenuCategories/{menuCategoryId}/MenuItems/{menuItemId}`            | Get menu item by ID                  | `Permissions.GetMenuItems` |
| GET    | `/api/MenuCategories/{menuCategoryId}/MenuItems/{menuItemId}/with-images` | Get menu item with its images        | `Permissions.GetMenuItems` |
| GET    | `/api/MenuCategories/{menuCategoryId}/MenuItems`                         | Get all menu items in a category     | `Permissions.GetMenuItems` |
| POST   | `/api/MenuCategories/{menuCategoryId}/MenuItems`                         | Create new menu item                 | `Permissions.AddMenuItems` |
| PUT    | `/api/MenuCategories/{menuCategoryId}/MenuItems/{menuItemId}`            | Update menu item                     | `Permissions.UpdateMenuItems` |
| PUT    | `/api/MenuCategories/{menuCategoryId}/MenuItems/{menuItemId}/change-price` | Change menu item price               | `Permissions.UpdateMenuItems` |
| PUT    | `/api/MenuCategories/{menuCategoryId}/MenuItems/{menuItemId}/toggleStatus` | Enable/Disable (toggle) menu item    | `Permissions.UpdateMenuItems` |

---

### 🧾 Orders (`/api/Orders`)

| Method | Endpoint                               | Description                          | Permission Required               |
| ------ | -------------------------------------- | ------------------------------------ | --------------------------------- |
| GET    | `/api/Orders/{id}`                     | Get order by ID                      | `Permissions.GetOrders`           |
| GET    | `/api/Orders`                          | Get all orders (with filters)        | `Permissions.GetOrders`           |
| GET    | `/api/Orders/table/{tableId}`          | Get orders by table ID               | `Permissions.GetOrders`           |
| POST   | `/api/Orders`                          | Create new order (rate-limited)      | `Permissions.AddOrders`           |
| PUT    | `/api/Orders/{id}/toggle-delivered`    | Toggle order delivery status         | `Permissions.ToggleDeliveredOrders` |
| PUT    | `/api/Orders/{id}/update-satus`        | Update order status                  | `Permissions.UpdateOrders`        |
| PUT    | `/api/Orders/{id}/toggle-active`       | Toggle order active/inactive         | `Permissions.UpdateOrders`        |
| PUT    | `/api/Orders/{id}/move-to-table/{newTableId}` | Move order to another table    | `Permissions.MoveOrderToTable`    |

---

### 🍽️ Order Items (`/api/Order/{orderId}/MenuItem/{menuItemId}/OrderItems`)

| Method | Endpoint                                                                 | Description                        | Permission Required            |
| ------ | ------------------------------------------------------------------------ | ---------------------------------- | ------------------------------ |
| GET    | `/api/Order/{orderId}/MenuItem/{menuItemId}/OrderItems/{orderItemId}`    | Get orderItem by ID  of order             | `Permissions.GetOrderItems`    |
| GET    | `/api/Order/{orderId}/OrderItems`                                        | Get all orderItems of an order    | `Permissions.GetOrderItems`    |
| POST   | `/api/Order/{orderId}/MenuItem/{menuItemId}/OrderItems`                  | Create new orderItem              | `Permissions.AddOrderItems`    |
| PUT    | `/api/Order/{orderId}/MenuItem/{menuItemId}/OrderItems/{orderItemId}`    | Update an orderItem              | `Permissions.UpdateOrderItems` |
| DELETE | `/api/Order/{orderId}/MenuItem/{menuItemId}/OrderItems/{orderItemId}`    | Delete a specific orderItem       | `Permissions.DeleteOrderItems` |
| DELETE | `/api/Order/{orderId}/OrderItems`                                        | Delete all orderItems of an order | `Permissions.DeleteOrderItems` |

---

### ⭐ Menu Item Ratings (`/api/Order/{orderId}/MenuItem/{menuItemId}/MenuItemRatings`)

| Method | Endpoint                                                                 | Description                          | Permission Required                 |
| ------ | ------------------------------------------------------------------------ | ------------------------------------ | ----------------------------------- |
| GET    | `/api/Order/{orderId}/MenuItem/{menuItemId}/MenuItemRatings/{menuItemRatingId}` | Get rating by ID                     | `Permissions.GetMenuItemRatings`    |
| GET    | `/api/MenuItem/{menuItemId}/MenuItemRatings`                             | Get all ratings for a menu item      | `Permissions.GetMenuItemRatings`    |
| POST   | `/api/Order/{orderId}/MenuItem/{menuItemId}/MenuItemRatings`             | Add a new rating for a menu item     | `Permissions.AddMenuItemRatings`    |
| PUT    | `/api/Order/{orderId}/MenuItem/{menuItemId}/MenuItemRatings/{menuItemRatingId}/toggleStatus` | Toggle active/inactive rating status | `Permissions.UpdateMenuItemRatings` |

---

### 🍽️ Tables (`/api/Tables`)

| Method | Endpoint                                | Description                         | Permission Required            |
| ------ | --------------------------------------- | ----------------------------------- | ------------------------------ |
| GET    | `/api/Tables/{id}`                      | Get table by ID                     | `Permissions.GetTables`        |
| GET    | `/api/Tables`                           | Get all tables (with filters)       | `Permissions.GetTables`        |
| POST   | `/api/Tables`                           | Create a new table                  | `Permissions.AddTables`        |
| PUT    | `/api/Tables/{id}`                      | Update table details                | `Permissions.UpdateTables`     |
| PUT    | `/api/Tables/{id}/update-status`        | Update table status (manual status) | `Permissions.UpdateTables`     |
| PUT    | `/api/Tables/{id}/toggleAvailability-status` | Toggle availability (free/busy)     | `Permissions.UpdateTables`     |

---

### 🧾 Invoices (`/api/Order/{orderId}/Invoices`)

| Method | Endpoint                                              | Description                            | Permission Required      |
| ------ | ----------------------------------------------------- | -------------------------------------- | ------------------------ |
| GET    | `/api/Order/{orderId}/Invoices/{id}`                  | Get invoice by ID                      | `Permissions.GetInvoices`|
| POST   | `/api/Order/{orderId}/Invoices`                       | Create a new invoice for an order      | `Permissions.AddInvoices`|
| PUT    | `/api/Order/{orderId}/Invoices/{id}/update-pay-method`| Update invoice payment method           | `Permissions.UpdateInvoices` |
| PUT    | `/api/Order/{orderId}/Invoices/{id}/toggle-status`    | Toggle invoice status (paid/unpaid)    | `Permissions.UpdateInvoices` |
