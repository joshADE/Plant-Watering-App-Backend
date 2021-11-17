# Plant-Watering-App-Backend
> The backend server needed to run the ShipVista Plants Assessment which can be seen [here](https://github.com/joshADE/plant-watering-app-frontend)


# Technologies used
* [.NET Core(Web API)](https://dotnet.microsoft.com/apps/aspnet/apis) (REST API)
* [PostgreSQL](https://www.postgresql.org/) (Open Source Relational Database) (not needed to run on local machine)

# Requirements

* GIT (version 2.x and above)
* Visual Studio (version 2019 and above) (configured with the .NET package, community edition is fine) (go [here](https://visualstudio.microsoft.com/vs/features/net-development/) to install visual studio with .NET)

# Optional

* PostgreSQL (latest version would be fine) (click [here](https://www.postgresqltutorial.com/install-postgresql/) for installation instructions)

# Getting Started

## Clone Repository

Clone the repository to your computer.

```
git clone https://github.com/joshADE/Plant-Watering-App-Backend.git
```

## Installation

1. Open the project directory.
2. Open the .sln (solution) file with Visual Studio to restore the necessary NuGet packages required for the project.

## Database

1. No RDBMS is required to run the project as the data is kept in memory.

## Running project locally

1. Build the project by navigating to Build > Build Solution and make sure that there are no errors.
2. Press the green play button (IIS Express)

Open up https://localhost:44321/api/plants in a browser to see the app. (You can use part of the url 'https://localhost:44321/api/'  to connect to the front-end of the app linked above). 
You can also visit https://localhost:44321/swagger/ to see list of all the endpoints and interact with them.
