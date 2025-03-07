CONTAINER_NAME='manga-db'
PASSWORD='Password123!'

{
    # Run the postgres container
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

echo "Container started!";