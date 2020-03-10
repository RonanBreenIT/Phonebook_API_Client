using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using PhonebookClient.Models;


namespace PhonebookClient
{
    class Client
    {
        static async Task GetsAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:51275/api/Phonebook/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // GET: api/Phonebook
                HttpResponseMessage response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    var PhonebookList = await response.Content.ReadAsAsync<IEnumerable<Phonebook>>();
                    Console.WriteLine("*** Complete Phonebook List ***");
                    foreach (var contact in PhonebookList)
                    {
                        Console.WriteLine("\n" + contact);
                    }
                }

                // GET: api/Phonebook/1
                response = await client.GetAsync("ID/7");
                if (response.IsSuccessStatusCode)
                {
                    var SinglePhonebookContact = await response.Content.ReadAsAsync<IEnumerable<Phonebook>>();
                    Console.WriteLine("\n *** Phonebook item with ID 1 ***");
                    foreach (var contact in SinglePhonebookContact)
                    {
                        Console.WriteLine("\n" + contact);
                    }
                }

                // GET: api/Phonebook/GetEntry/{number}
                response = await client.GetAsync("GetEntry/2222");
                if (response.IsSuccessStatusCode)
                {
                    var FindNumber = await response.Content.ReadAsAsync<Phonebook>(); // Can't make IENumerable as Methid in Phonebook not IENumerable
                    Console.WriteLine("\n *** Phonebook item found with number 3333 ***");
                    Console.WriteLine(FindNumber);
                }

                // Post: api/Phonebook/AddEntry {FromBody}
                Phonebook contact1 = new Phonebook() { Name = "Added Name", ID = 50, Number = "87878677", Address = "25 new street" };
                response = client.PostAsJsonAsync("AddEntry", contact1).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nAdded Contact: " + contact1.Name);
                    //string result = response.Content.ReadAsStringAsync().Result;
                    //Console.WriteLine(result);
                }

                // Post: api/Phonebook/UpdateEntry {FromBody}
                Phonebook contact2 = new Phonebook() { Name = "new updated Name", ID = 51, Number = "87878677", Address = "26 new street" };
                response = client.PutAsJsonAsync("UpdateEntry", contact2).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nUpdated Contact: " + contact2.Name);
                    //string result = response.Content.ReadAsStringAsync().Result;
                    //Console.WriteLine(result);
                }

                // Delete: api/Phonebook/DeleteEntry/{number}
                response = client.DeleteAsync("DeleteEntry/87878677").Result;
                if (response.IsSuccessStatusCode)
                {
                    //Console.WriteLine("\nDeleted Contact: " + contact3.Name);
                    string result = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("Deleted " + result);
                }
            }
        }
    
        

        
        static void Main()
        {
            GetsAsync().Wait();
            Console.ReadLine();
        }
    }
}
