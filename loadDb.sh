#!/bin/bash

# Variables
DB_CONTAINER_NAME="manga-api-db-container"
DB_NAME="mangaDb"
DB_USER="mangaAdmin"
DB_PASSWORD="password"
DB_PORT="5432"

# Pull the latest postgres image
docker pull postgres:latest

# Run the postgres container
docker run --name $DB_CONTAINER_NAME -e POSTGRES_DB=$DB_NAME -e POSTGRES_USER=$DB_USER -e POSTGRES_PASSWORD=$DB_PASSWORD -p $DB_PORT:5432 -d postgres:latest

# Wait for the database to be ready
echo "Waiting for the database to be ready..."
sleep 5

# Print success message
echo "Postgres database '$DB_NAME' is running in Docker container '$DB_CONTAINER_NAME' on port $DB_PORT"