# Smart Box Prototype
The prototype of this smart box will showcase the technology and concept of the UPI smart box, including how it responds to successful payments and the role of the messaging broker utilized behind the scenes.

This prototype is devided into two projects:
1. Web API Producer (to produce/send request)
2. Console Consumer (to consume/process message)

### Producer Endpoint
**[POST]** https://localhost:44320/api/Producer/Payment

**Request Body:**
```
{
  "rupees": 105.50
}
```

### Consumer
Consumer will process the message stack from the queue in FIFO manner. After processing the request the Consumer app will speak up the amount received successfully.

### Setup development environment with Docker compose
To setup development environment in docker use the below command

`docker-compose up -d`

This docker compose contain the following image:

1. RabbitMQ

`Note:` Run both Producer and Consumer app togather along with RabbitMQ server.