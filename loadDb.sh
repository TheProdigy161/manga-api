CONTAINER_NAME='manga-db'
PASSWORD='Password123!'

{
    # Run the postgres container
    echo "Starting container";
    docker start $CONTAINER_NAME 2> /dev/null;

} || {

    # Create the postgres container
    echo "Container not found, creating a new one";

    docker run -d \
        -e "ACCEPT_EULA=Y" \
        -e "SA_PASSWORD=$PASSWORD" \
        -p 1433:1433 \
        --name $CONTAINER_NAME \
        mcr.microsoft.com/mssql/server;
}

# Wait for 5 seconds to allow for container to start
echo "Waiting for container to start";
sleep 5

echo "Container started!";