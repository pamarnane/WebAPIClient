using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text.Json;
using System.Text;

namespace WebAPIClient
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static async Task QueueMission()
        { 
        // Code to queue up a mission
        
        
        
        
        
        }


        static void Main(string[] args)
        {

            do
            {
                ProcessRepositories().GetAwaiter().GetResult();
            }while(1 == 1);
          
        }


        static async Task ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var byteArray = Encoding.ASCII.GetBytes("admin:00000000");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            //var streamTask = client.GetStreamAsync("http://192.168.1.50/api/v2.0.0/status");
            //var stringTask = client.GetStringAsync("http://192.168.1.52/di_value/slot_0/ch_2");
            //   var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);
            //var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);
            //var msg = await stringTask;
            //Console.Write(msg);
            // foreach (var repo in repositories)
            // Console.ReadKey();

            var streamTask = client.GetStreamAsync("http://192.168.1.52/di_value/slot_0/ch_0");
            var repositories = await JsonSerializer.DeserializeAsync<Repository>(await streamTask);

            if (repositories.Val == 0)
            {

                Console.WriteLine("Input is off");
                await QueueMission();

            }


            //System.Threading.Thread.Sleep(1000);



        }

    }
}
