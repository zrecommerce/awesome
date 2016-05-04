AwesomeAPI
----------
C# Web API 2 service.

## Requirements

The host machine will likeley require `libuv`, and you must add your user to the `docker` group (to avoid sudo).

Vagrant must be installed on your machine.

Docker must be installed on your machine, and the docker service must be running.
This application uses the `docker` vagrant provision and provider.

See MODELS.md for initial seed data info.


## Start

Using your terminal, navigate into the AwesomeAPI/ directory, and run `vagrant up`
If it is the first time the vagrant provision is started (or at least, after a call to `vagrant destroy`), check the output of the docker logs for the (new) container, as the docker container takes a few minutes to complete the `dnu restore` command before starting the Microsoft Kestrel server.

Once the server is up and running, Browse to `http://localhost:5000/api/values`

When you are finished running the API service, run `vagrant destroy` to tear it down completely (or `vagrant halt` to simply shut it down instead)

You will need to gain Bash terminal access and copy the contents of /vagrant into /app, and 


## Bash terminal access

You can use the following command to start a bash terminal on the docker container:

```
# Replace CONTAINER_ID with the container ID or Container Name. See docker ps -a for list of containers
docker exec -t -i CONTAINER_ID /bin/bash
```
The container ID is set to "awesome-dev" in the Dockerfile.


## View Logs

View the logs for CONTAINER_ID as follows:

```
# Replace CONTAINER_ID with the container ID or Container Name. See docker ps -a for list of containers
docker logs CONTAINER_ID
```

## View Swagger 2.0 UI, and JSON

See the UI: `http://localhost:5000/swagger/ui/index.html`
See the JSON: `http://localhost:5000/swagger/v1/swagger.json`

## DB Migrations
The AwesomeAPI serivce uses Entity Framework 7 Migrations.

To create a migration:

```
dnx ef migrations add NAME_OF_MIGRATION
```

To undo last:

```
ef migrations remove
```

To apply a migration:

```
dnx ef database update
```