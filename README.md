# Tomnaia Transportation Management System

## Overview
Tomnaia is a comprehensive Transportation Management System built using .NET for the backend and Flutter for the frontend mobile application. The system facilitates and manages transportation services for various user roles including bus users, drivers, and administrators. It enables efficient management of ride requests, driver registration, vehicle management, and admin oversight.

## Demo Video
[Watch the demo video](https://github.com/Mr-Array/TomnaiaApi/blob/master/Tomnaia.mp4)

## Features
### User Roles
- **Passenger Users:** Includes general users, parents, and minors utilizing car or bus services.
- **Drivers:** Can register, log in, manage their profile, and handle their vehicles.
- **Administrators:** Oversee the system, review driver data, manage requests, and configure settings.

### Driver Capabilities
- **Register, Login, Logout:** Basic authentication and profile management.
- **Vehicle Management:** Add, update, and delete vehicle details, including capacity.
- **Offer Management:** Send and cancel ride offers.
- **Request Handling:** Respond to ride requests specifying locations and urgency.

### User Capabilities
- **Request Rides:** Submit ride requests with details about origin, destination, and urgency (urgent or scheduled).

### Admin Capabilities
- **Review Driver Data:** Accept or reject driver registrations.
- **Manage Requests:** Review, accept, or reject ride requests.
- **System Configuration:** Configure system settings via a dashboard.

## System Workflow
1. **User Registration and Management:**
   - Users and drivers register and manage their profiles.
   - Drivers manage their vehicles, including adding, updating, and deleting vehicle records.

2. **Ride Request and Offer:**
   - Users request rides specifying details like origin, destination, and urgency.
   - Drivers can send offers for rides or cancel them if needed.

3. **Admin Oversight:**
   - Admins review driver registrations and manage ride requests.
   - Admins can block requests if necessary and configure the system via a dashboard.

## Technical Details

### Backend (.NET)
- **Framework:** ASP.NET Core
- **Database:** SQL Server
- **Authentication:** JWT
- **API Documentation:** Swagger

### Frontend (Flutter)
- **Language:** Dart
- **State Management:** Provider
- **Networking:** HTTP
- **UI Components:** Material Design

## Installation and Setup

### Backend (.NET)
1. **Clone the Repository:**
   ```sh
   git clone https://github.com/your-username/tomnaia-backend.git

