using ConsoleConsumer;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Speech.Synthesis;
using System.Text;
using System.Text.Json;

const int speechRate = 0;

var factory = new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "user",
    Password = "user",
};

var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "payment",
         durable: false,
         exclusive: false,
         autoDelete: false,
         arguments: null);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (sender, args) =>
{
    var body = args.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    var payment = JsonSerializer.Deserialize<Payment>(message);
    string speechText = NumberToWords.ConvertAmount(payment.Rupees);

    Console.WriteLine($"Received Rupees: {payment.Rupees}");

    var voice = new SpeechSynthesizer();
    voice.SetOutputToDefaultAudioDevice();
    voice.Rate = speechRate;
    voice.Speak("Received Rupees.! " + speechText);
};

channel.BasicConsume("payment", true, consumer);

Console.ReadLine();