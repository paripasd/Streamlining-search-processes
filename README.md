# Setup

## Docker

Download the Volumes Backup & Share extensin to docker desktop.

![image](https://github.com/attilaUCN/semester4project/assets/69151140/8e77a98c-9ab0-4a93-824d-1906f3bd8aa4)

From this extension select the "Import into new volume" option and select the path to the given data file from the repository and give the volume "test_information" name. Than click import.

![image](https://github.com/attilaUCN/semester4project/assets/69151140/488869ab-a6f9-4083-b624-a8eaf606ebef)

Search for the official SolR image in docker and pull it.

![image](https://github.com/attilaUCN/semester4project/assets/69151140/0947c071-d19e-4123-a2ec-716952b2536b)

Create a container with the offical SolR image with the given parameters. Namely any given name for the container, "8983" for the ports,
"/var/lib/docker/volumes/test_information/_data" for the host path and "/var/solr" for the container path than click on run.

![image](https://github.com/attilaUCN/semester4project/assets/69151140/df8d69f8-61fb-44ee-9f6c-9096241924fc)

Wait until SolR setup finishes.

![image](https://github.com/attilaUCN/semester4project/assets/69151140/d6bd5f59-5cf8-4c84-8d51-7aafcae2fd05)

Go to "http://localhost:8983/solr/#/" to see if SolR is running.

![image](https://github.com/attilaUCN/semester4project/assets/69151140/1baca7a4-41c1-4f1f-b2ed-39db243f7970)

