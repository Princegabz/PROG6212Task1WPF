# PROG6212Task1WPF Application

## Overview
This is a WPF (Windows Presentation Foundation) application for managing module details for an academic semester. The application allows users to:

- Add new module details
- Search for modules by module code
- Update existing module details
- View a list of all modules
- Read and write module data from/to a text file

The data managed includes:
- Module Code
- Module Name
- Module Credits
- Class Hours per Week
- Number of Weeks in the Semester
- Start Date of the Semester

## Project Structure
- **MainWindow.xaml**: The user interface for the application
- **MainWindow.xaml.cs**: Code-behind for managing user interactions and data operations
- **ModuleDetails.cs**: Model class representing module details (not shown in the provided code but assumed)
- **ModuleDetail.txt**: Text file used for persistent storage of module data

## Features

### 1. Adding Module Details
The `btnAdd_Click` event handler checks if all fields are filled and adds a new module to the `testData` list. It then updates the list display and writes the new data to the text file.

### 2. Viewing Module List
The `ViewList()` method orders the list of modules by module code and displays them in the ListBox (`lstOutput`).

### 3. Searching Modules
The `btnSearch_Click` event handler searches for modules by their module code and updates the list display with matching results.

### 4. Updating Module Details
The `btnUpdate_Click` event handler allows users to modify selected module details directly from the ListBox selection.

### 5. Reading and Writing Data
- `ReadData()`: Reads module details from `ModuleDetail.txt`, or initializes sample data if the file does not exist.
- `UpdateData()`: Deletes and rewrites `ModuleDetail.txt` with the current module list.

## Usage
1. Run the application.
2. Add a new module by filling in all fields and clicking **Add**.
3. Search for a module by entering its code and clicking **Search**.
4. Select a module from the list to view its details.
5. Modify a module’s details and click **Update**.
6. Module data is automatically saved and loaded from `ModuleDetail.txt`.

## Known Issues
- `btnUpdate_Click` incorrectly assigns `ModuleName1` to an `int` value.
- `listOutput` may need to be changed to a list of objects instead of strings.
- `ReadData()` improperly uses `Read()` for reading integers; `ReadLine()` should be used.
- Error handling could be improved for data parsing and file operations.

## Future Enhancements
- Implement validation for date and numeric fields.
- Add better error handling and logging.
- Refactor code for cleaner separation of concerns (e.g., using MVVM pattern).
- Introduce unit tests.
- Enhance UI for better usability and user experience.

## Prerequisites
- .NET 6.0 or later
- Visual Studio 2022 or later

## How to Run
1. Clone the repository.
2. Open the solution in Visual Studio.
3. Build and run the project.

---
**Author:** Prince Gabz  
**Contact:** RNG Development, Dolphin Leap Centre, Port Elizabeth

