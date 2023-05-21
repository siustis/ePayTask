using System.Text;
using ePay.Api.Models;
using Newtonsoft.Json;

var client = new HttpClient();

var currentId = 1;

//Change this variable to match the port in your launchSettings.json
const string baseAddress = "https://localhost:7272/";
const int numberOfRequests = 100;
const int numberOfCustomers = 5;

client.BaseAddress = new Uri(baseAddress);

var tasks = new List<Task>();

//Add requests to tasks to call them asynchronously
for (var i = 0; i < numberOfRequests; i++)
{
    tasks.Add(SendPostRequest(CreateRandomCustomers(numberOfCustomers)));
}

await Task.WhenAll(tasks);

await SendGetRequest();


async Task SendPostRequest(List<Customer> customers)
{
    var content = new StringContent(JsonConvert.SerializeObject(customers), Encoding.UTF8, "application/json");

    await client.PostAsync("api/customers", content);
}

async Task SendGetRequest()
{
    var response = await client.GetAsync("api/customers");

    if (response.IsSuccessStatusCode)
    {
        var result = await response.Content.ReadAsStringAsync();
        var customers = JsonConvert.DeserializeObject<List<Customer>>(result);

        foreach (var customer in customers)
        {
            Console.WriteLine($"ID: {customer.Id}, First Name: {customer.FirstName}, Last Name: {customer.LastName}, Age: {customer.Age}");
        }
    }
}

//Generate list of random customers
List<Customer> CreateRandomCustomers(int count)
{
    var customers = new List<Customer>();
    var firstNames = new[] { "Leia", "Sadie", "Jose", "Sara", "Frank", "Dewey", "Tomas", "Joel", "Lukas", "Carlos" };
    var lastNames = new[] { "Liberty", "Ray", "Harrison", "Ronan", "Drew", "Powell", "Larsen", "Chan", "Anderson", "Lane" };
    var random = new Random();

    for (var i = 0; i < count; i++)
    {
        var customer = new Customer
        {
            FirstName = firstNames[random.Next(firstNames.Length)],
            LastName = lastNames[random.Next(lastNames.Length)],
            Age = random.Next(18, 91),
            Id = currentId++
        };

        customers.Add(customer);
    }

    return customers;
}