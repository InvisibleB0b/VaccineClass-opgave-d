using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using VaccineClassLib;

namespace RestConsumerVaccine
{
    class Program
    {

        private const string ServerUrl = "http://localhost:58863/";

        static void Main(string[] args)
        {

            // den der henter alle

            List<Vaccine> vList = new List<Vaccine>();


            //en klasse der håndtere http kaldene til vores api

            HttpClientHandler handler = new HttpClientHandler();

            //vi skal ikke skal ikke opsætte vores credentials
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {

                //opsætning http clienten så den ved hvilken adresse api ligger på

                client.BaseAddress = new Uri(ServerUrl);


                //her der fjerner vi default headers så vi selv kan sætte dem op
                client.DefaultRequestHeaders.Clear();


                //og her der fortæller vi at vores response skal være i json format -> det er de eneste oplysinger der behøver at være i headeren.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));

                try
                {

                    //http client prøver at lave et GET kald til {baseurl}/vacciner og venter på svar
                    var response = client.GetAsync($"vaccines").Result;
                    if (response.IsSuccessStatusCode)
                    {

                        //hvis status koden på svaret var fint så læser JSON svaret som en liste af vacciner
                        vList = response.Content.ReadAsAsync<List<Vaccine>>().Result;
                    }
                    else
                    {
                        vList = null;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }

            Console.WriteLine("Alle vacciner \n");

            foreach (Vaccine vaccine in vList)
            {
                Console.WriteLine(vaccine + "\n");
            }



            //Den enkelte metode

            Vaccine v = new Vaccine();


            HttpClientHandler handler2 = new HttpClientHandler();

            handler2.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler2))
            {

                client.BaseAddress = new Uri(ServerUrl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("aplication/json"));

                try
                {
                    var response = client.GetAsync($"vaccines/1").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        v = response.Content.ReadAsAsync<Vaccine>().Result;
                    }
                    else
                    {
                        v = null;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }


            Console.WriteLine("Vaccine nr 1\n");


            Console.WriteLine(v);



        }
    }
}
