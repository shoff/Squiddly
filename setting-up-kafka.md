## Setting up kafka net
Docker provides us with a concept of docker net. We can create a dedicated net on which the containers will be able to talk to each other:

docker network create kafka

With the network kafka created, we can create the containers. I will use the images provided by confluent.io, as they are up to date and well documented.

## Configuring the Zookeeper container
First, we create a Zookeeper image, using port 2181 and our kafka net. I use fixed version rather than latest, to guarantee that the example will work for you. If you want to use a different version of the image, feel free to experiment:

docker run --network=kafka -d --name=zookeeper -e ZOOKEEPER_CLIENT_PORT=2181 confluentinc/cp-zookeeper:latest

## Configuring the Kafka container
With the Zookeeper container up and running, you can create the Kafka container. We will place it on the kafka net, expose port 9092 as this will be the port for communicating and set a few extra parameters to work correctly with Zookeeper:

docker run --network=kafka -d -p 9092:9092 --name=kafka -e KAFKA_ZOOKEEPER_CONNECT=zookeeper:2181 -e KAFKA_ADVERTISED_LISTENERS=PLAINTEXT://kafka:9092 -e KAFKA_OFFSETS_TOPIC_REPLICATION_FACTOR=1 confluentinc/cp-kafka:4.1.0

## Connecting to Kafka – DNS editing
One last catch here is that Kafka may not respond correctly when contacted on localhost:9092– the Docker communication happens via kafka:9092.

You can do that easily on Windows by editing the hostfile located in C:\Windows\System32\drivers\etc\hosts. You want to add the line pointing kafka to 127.0.0.1. Your hostfile should look something like this:
