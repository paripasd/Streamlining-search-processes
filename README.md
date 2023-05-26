# About

This solution handles effective, scalable storage and retrival of FAQ documents with an emphasis on search speed and expandability. Apache SolR handles the storage and provides us countless tools for querying our data in different ways. The user interface is developed with Vue.js and Tailwind CSS to create an appealing website. The communication between system nodes and additional logic is handled by our C# API. In this setup we used Docker to host our SolR instance complimented with the API and UI running on localhost. Security features and in depth testing was not a part of this project.

# Setup and Usage

## API

Open the API code in Visual Studio and build the project than run it. The Swagger UI should appear which means the api is up and running on localhost.

## UI

Node.js should be installed beforehand.
Open terminal in the UI folder and excecute "npm install" than "npm run serve" to create the website hosted on localhost.

## Docker
The following guide requires you to have Docker and Docker Desktop already installed on your machine.
1. Download the Volumes Backup & Share extension to docker desktop.

![image](https://github.com/attilaUCN/semester4project/assets/69151140/738c0ab9-bfe4-4808-a4db-09cd927f0f28)

2. From this extension select the "Import into new volume" option and select the path to the given data file from the repository and give the volume "test_information" name. Than click import.

![image](https://github.com/attilaUCN/semester4project/assets/69151140/488869ab-a6f9-4083-b624-a8eaf606ebef)

3. Search for the official SolR image in docker and pull it.

![image](https://github.com/attilaUCN/semester4project/assets/69151140/0947c071-d19e-4123-a2ec-716952b2536b)

4. Create a container with the offical SolR image with the given parameters. Namely any given name for the container, "8983" for the ports,
"/var/lib/docker/volumes/test_information/_data" for the host path and "/var/solr" for the container path than click on run.

![image](https://github.com/attilaUCN/semester4project/assets/69151140/df8d69f8-61fb-44ee-9f6c-9096241924fc)

5. Wait until SolR setup finishes.

![image](https://github.com/attilaUCN/semester4project/assets/69151140/d6bd5f59-5cf8-4c84-8d51-7aafcae2fd05)

6. Go to "http://localhost:8983/solr/#/" to see if SolR is running.

![image](https://github.com/attilaUCN/semester4project/assets/69151140/1baca7a4-41c1-4f1f-b2ed-39db243f7970)

