# About

This solution handles effective, scalable storage and retrival of FAQ documents with an emphasis on search speed and expandability. Apache SolR handles the storage and provides us countless tools for querying our data in different ways. The user interface is developed with Vue.js and Tailwind CSS to create an appealing website. The communication between system nodes and additional logic is handled by our C# API. In this setup we used Docker to host our SolR instance complimented with the API and UI running on localhost. Security features and in depth testing was not a part of this project.

![demo (1)](https://github.com/attilaUCN/semester4project/assets/69151140/5234711b-95a1-4a19-a563-6e2852caaa17)

# Setup and Usage

## API

Open the API code in Visual Studio and build the project than run it. The Swagger UI should appear which means the api is up and running on localhost.

## UI

Node.js should be installed beforehand.
Open terminal in the UI folder and excecute "npm install" than "npm run serve" to create the website hosted on localhost.

## Docker
Download Docker. Create a SolR container with a volume mounted to it from the "test_information.tar.gz" file and run the container.
