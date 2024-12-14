# Awake

Awake is a simple WPF application designed to keep your system awake. It provides a user interface to start and stop the functionality that prevents the system from sleeping. The application also includes a system tray icon with additional controls.

## Features

- Start and stop the system awake functionality.
- System tray icon with context menu for showing the window and exiting the application.
- Configurable styles for active and inactive buttons.

## Requirements

- .NET Framework 4.8

## Download

Download the latest version:
[Download Awake.exe](https://github.com/anhquanpbc/Awake/blob/main/bin/Debug/app.publish/Awake.exe)

*Note: If you see the source code instead of a download prompt, click the "Download" button on the right side of the page.*

## Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/anhquanpbc/Awake.git

2. Open the solution file Awake.sln in Visual Studio.

## Usage
1. Build the project in Visual Studio.
2. Run the application. The main window will appear with "Start" and "Stop" buttons.
3. Click "Start" to keep the system awake. The status will be updated in the text block.
4. Click "Stop" to allow the system to sleep.
5. The application will minimize to the system tray. Right-click the tray icon for options to show the window or exit the application.

## Key Files
- App.xaml and App.xaml.cs: Application startup and resource definitions.
- MainWindow.xaml and MainWindow.xaml.cs: Main window UI and logic.
- Properties/: Contains assembly information, resources, and settings.

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request with your changes.

## License
This project is licensed under the MIT License. See the LICENSE file for details.