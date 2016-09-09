﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace LifeInsurance
{
    public class Postcode
    {
        public static string LookupCountry(string postcode)
        {
            string PostCodeLookupURL = ("https://api.postcodes.io/postcodes/" + postcode);
            string country = ("");

            // Setup http call
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(PostCodeLookupURL);
            wrGETURL.Method = "GET";

            // Setup proxy settings
            WebProxy prox = new WebProxy();
            Uri uri = new Uri("http://peg-proxy01:80");
            prox.Address = uri;

            // prox.Credentials = new System.Net.NetworkCredential("USERNAME", "PASSWORD", "INSURANCE");
            wrGETURL.Proxy = prox;

            // Make request
            try
            {
                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();

                // Parse return, extract Status and Country
                using (StreamReader reader = new StreamReader(objStream)) 
                {
                    string json = reader.ReadToEnd();
                    JToken token = JObject.Parse(json);
                    int Status = (int)token.SelectToken("status");

                    // Populate NewClient instance with country.
                    country = (string)token.SelectToken("result.country");
                    return country;
                }
            }

            catch (WebException ex)
            {
                Console.Clear();
                HttpWebResponse result = (HttpWebResponse)ex.Response;
                
                Console.WriteLine("The following error occured.");

                switch (result.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        Console.WriteLine((int)result.StatusCode + " " + result.StatusCode);
                        break;
                    case HttpStatusCode.NotFound:
                        Console.WriteLine((int)result.StatusCode + " " + result.StatusCode);
                        break;
                    case HttpStatusCode.RequestTimeout:
                        Console.WriteLine((int)result.StatusCode + " " + result.StatusCode);
                        break;
                    default:
                        Console.WriteLine((int)result.StatusCode + " " + result.StatusCode);
                        break;
                }

                Console.ReadLine();
                Environment.Exit(0);
            }

            return country;
        }
    }
}
