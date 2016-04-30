AwesomeAPI
----------
C# Web API 2 service.

Run `vagrant up`, then browse to `http://localhost:5000/api/values`


## Bash terminal access

You can use the following command to start a bash terminal on the docker container:

```
# Replace CONTAINER_ID with the container ID or Container Name. See docker ps -a for list of containers
docker exec -t -i CONTAINER_ID /bin/bash
```


## View Logs

View the logs for CONTAINER_ID as follows:

```
# Replace CONTAINER_ID with the container ID or Container Name. See docker ps -a for list of containers
docker logs CONTAINER_ID
```