using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RestSharp;
using Newtonsoft.Json;

namespace WeatherDemo
{
    class PLCity
    {
        public RootObject ExecuteRequest(string city)
        {
            var client = new RestClient("http://api.openweathermap.org/data/2.5/forecast/daily?APPID=eda779a0530f5471405b6257cb0bf2f1&q=" + city + "&mode=json&units=metric&cnt=10");

            RestRequest request = new RestRequest();
            IRestResponse response = client.Execute(request);

            RootObject obj = new RootObject();
            obj = JsonConvert.DeserializeObject<RootObject>(response.Content);

            return obj;
        }

        public CuTemps.RootObject ExecuteRequestCurrent(string city)
        {
            var client = new RestClient("http://api.openweathermap.org/data/2.5/weather?APPID=eda779a0530f5471405b6257cb0bf2f1&q=" + city + "&units=metric");

            RestRequest request = new RestRequest();
            IRestResponse response = client.Execute(request);

            CuTemps.RootObject obj = new CuTemps.RootObject();
            obj = JsonConvert.DeserializeObject<CuTemps.RootObject>(response.Content);

            return obj;
        }

        public RootObject ExecuteRequestlatlong(double lat,double lng)
        {


            string test = "http://api.openweathermap.org/data/2.5/forecast/daily?APPID=eda779a0530f5471405b6257cb0bf2f1&lat=" + lat + "&lon" + lng + "&mode=json&units=metric&cnt=10";

            //?lat={lat}&lon={lon}
            var client = new RestClient("http://api.openweathermap.org/data/2.5/forecast/daily?APPID=eda779a0530f5471405b6257cb0bf2f1&lat=" + lat + "&lon=" + lng + "&mode=json&units=metric&cnt=10");

            RestRequest request = new RestRequest();
            IRestResponse response = client.Execute(request);

            RootObject obj = new RootObject();
            obj = JsonConvert.DeserializeObject<RootObject>(response.Content);

            return obj;
        }

        public CuTemps.RootObject ExecuteRequestCurrentlatlong(double lat, double lng)
        {
            var client = new RestClient("http://api.openweathermap.org/data/2.5/weather?APPID=eda779a0530f5471405b6257cb0bf2f1&lat=" + lat + "&lon=" + lng+ "&units=metric");

            RestRequest request = new RestRequest();
            IRestResponse response = client.Execute(request);

            CuTemps.RootObject obj = new CuTemps.RootObject();
            obj = JsonConvert.DeserializeObject<CuTemps.RootObject>(response.Content);

            return obj;
        }

    }
}