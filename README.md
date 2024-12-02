# Localization Files Manager

**Localization Files Manager** is a WPF application designed to simplify the creation and management of localization data files for video games. The tool supports editing, importing, and exporting localization files in various formats, making it easy to manage multilingual content for game development.

This project was developed as a school assignment aimed at helping us explore and learn WPF (Windows Presentation Foundation). As a result, the project's architecture may not follow optimal software engineering practices, and some bugs or limitations may still be present. While the app is functional and demonstrates core concepts of localization management, it is primarily an educational exercise rather than a production-ready solution.

## Features

- **Load and Save Support**: Work with CSV, XML, and JSON files for localization data.  
- **Data Grid Editor**: Edit localization values in a data grid interface.  
- **Code Export**: Export localization data into C++ or C# static classes for easy integration into your projects. 

## Tech Stack

- **WPF**: For creating the user interface.  
- **Newtonsoft.Json**: To handle JSON parsing and serialization.  
- **Premake**: As the build system for easy project setup.  

## Getting Started

### Prerequisites
- Windows operating system.
- Visual Studio (tested on Visual Studio 2022).

### Building the Project

1. Clone the repository:  
   ```bash
   git clone https://github.com/Theo-Mestre/Localization-Files-Manager
   ```

2. Navigate to the `Scripts` folder and run the setup script:  
   ```
   Scripts/SetupWindows.bat
   ```
   This script uses Premake to generate the solution files and build the project.

3. Open the generated solution in Visual Studio and build the project.

## Usage

1. Launch the application.
2. Import localization files in CSV, XML, or JSON formats.
3. Edit the localization values directly in the data grid.
4. Export the data to either CSV, XML, JSON, C++ or C# static classes for integration into your project.

## Team

This project was developed as part of a school assignment by:

- **Killian Anton**  
- **Kevin Babel**  
- **Séforah Leung-Tack-Wingfor**
- **Theo Mestre**

## License

This project is licensed under the [MIT License](LICENSE).
