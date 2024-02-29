# WeatherApp

Small .NET 8 application to tell the weather.

Built using Visual Studio 2022 Community Edition on a Windows PC.



Requirements:

You will need the following pieces of software installed to develop this application.

- .NET 8 SDK
- Visual Studio 2022 (any edition will work)
  - Visual Studio Code MAY be a suitable alternative, but it has not been tested
- Git

Steps to run locally:

1. Pull down the repository from GitHub using ``git clone`` command.
2. Open up Visual Studio 2022 and open the WeatherApp.sln file.
  3. Open up the appsettings.json file and populate the key called ``OpenWeatherApiKey`` with an API key from Open Weather.
   NOTE: You can also use the "Manage User Secrets" option in Visual Studio to securely store it and the app can grab it from there as well.
  If neither of these work, you can add it in Program.cs on line 61 (when creating the ``OpenWeatherApiConfiguration`` object).
4. In Visual Studio, build and run the WeatherApp.Service application. This will run the app as a console app.
5. ???
6. Profit!