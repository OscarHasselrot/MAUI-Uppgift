# MAUI Uppgift - NHL Standings App

## Overview

This is a simple .NET MAUI application developed as part of a school assignment.

The app fetches data from the `SportsDataIO API` that allows the users to:
- View the current NHL standings.
- Select a team to view more detailed information.
- View previous and upcoming games for a selected team.
- View detailed information about individual games.

The app is built using `MVVM` architecture with databinding and navigation via Shell.

--- 

## Architecture
The project follows a clear MVVM architecture:

- Views
  XAML pages responsible only for UI and databinding.

- ViewModels
  Handle presentation logic, UI state (`IsBusy`, `HasError`, etc.), and commands using CommunityToolkit.Mvvm.

- Services
  Encapsulate all API communication using `HttpClient`.	

Dependency Injection is configured in `MauiProgram.cs` to provide services and ViewModels.

---

## API & Data
The app uses the SportsDataIO API to fetch NHL data:

- Standings (by season)
- Teams
- Game schedules
- Game details

API calls are performed using `HttpClient` with asynchronous methods and deserialized with `System.Net.Http.Json`.

---

## Navigation
Navigation is handled using `Shell` routing with query parameters.

Examples:
- Team details page receives the team abbreviation as a query parameter.
- Game details page receives the game ID as a query parameter.

ViewModels implement IQueryAttributable to extract parameters during navigation.

---

## Configuration (API Key)
The application uses an `appsettings.json` file to store the API key.

For security reasons, this file is not included in the GitHub repository.

### Setup
1. Copy `appsettings.sample.json`.
2. Rename the copy to `appsettings.json`
3. Add your SportsDataIO API key in the "API_KEY" field.

The configuration file is embedded as a resource and loaded at runtime.

---

## Error Handling & UI State
- Loading indicators are handled using `IsBusy`.
- Errors are handled using `HasError` and `ErrorMessage`.
- Custom UI components are used to display loading states and error messages to the user.

---

## Styling
The app includes custom styling with:
- Reusable UI components.
- Team logos and colors.
- Icons and consistent layout for a polished mobile experience.

## Notes
This project was developed as a school assignment and is intended to demonstrate:
- Mobile application architecture.
- API consumption.
- MVVM pattern in .NET MAUI.