using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Linq;
using Geolocator.Plugin;

namespace WeatherDemo
{
    [Activity(Label = "WeatherDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        AutoCompleteTextView ACSearch;
        TextView Cities;
        TextView Time;
        TextView CTtemp;

        TextView Day1;
        TextView Day2;
        TextView Day3;
        TextView Day4;
        TextView Day5;

        TextView Temp1;
        TextView Temp2;
        TextView Temp3;
        TextView Temp4;
        TextView Temp5;

        Button Confirm;

        ImageView img1;
        ImageView img2;
        ImageView img3;
        ImageView img4;
        ImageView img5;

        static string[] NZPlaces = new string[] {
"Ahaura",
"Ahipara",
"Ahititi",
"Ahuroa",
"Akaroa",
"Akitio",
"Albany",
"Albert Town",
"Albury",
"Alexandra",
"Allanton",
"Amberley",
"Anakiwa",
"Aramoana",
"Aranga",
"Arapohue",
"Arrowtown",
"Arundel",
"Ashburton",
"Ashhurst",
"Ashley",
"Auckland",
"Auroa",
"Awanui",

"Balclutha",
"Balfour",
"Barrhill",
"Barrytown",
"Beachlands",
"Beaumont",
"Bell Block",
"Benhar",
"Benneydale",
"Bideford",
"Blackball",
"Blenheim",
"Bluff",
"Brighton",
"Brightwater",
"Broadwood",
"Bulls",
"Bunnythorpe",
"Burnt Hill",

"Cambridge",
"Canvastown",
"Carterton",
"Cheviot",
"Christchurch",
"Clarksville",
"Clarkville",
"Clevedon",
"Clinton",
"Clive",
"Clyde",
"Coatesville",
"Collingwood",
"Colville",
"Coopers Creek",
"Coroglen",
"Coromandel",
"Cromwell",
"Culverden",
"Cust",

"Dairy Flat",
"Dannevirke",
"Darfield",
"Dargaville",
"Dipton",
"Dobson",
"Doyleston",
"Drury",
"Dunedin",
"Duntroon",

"Eastbourne",
"Edendale",
"Edgecumbe",
"Egmont Village",
"Eketahuna",
"Eltham",
"Ettrick",
"Eyrewell Forest",

"Fairhall",
"Fairlie",
"Featherston",
"Feilding",
"Fernside",
"Flaxmere",
"Flaxton",
"Fox Glacier",
"Foxton",
"Foxton Beach",
"Frankton, Otago",
"Frankton, Waikato",
"Franz Josef",

"Geraldine",
"Gisborne",
"Glenorchy",
"Glentui",
"Gore",
"Granity",
"Greymouth",
"Greytown",
"Grovetown",
"Gummies Bush",

"Haast",
"Hakataramea",
"Halcombe",
"Hamilton",
"Hampden",
"Hanmer Springs",
"Hari Hari",
"Hastings",
"Haumoana",
"Haupiri",
"Havelock",
"Havelock North",
"Hāwea",
"Hawera",
"Helensville",
"Henley",
"Herbert",
"Herekino",
"Hikuai",
"Hikurangi",
"Hikutaia",
"Hinuera",
"Hokitika",
"Hope",
"Horeke",
"Houhora",
"Howick",
"Huapai",
"Huiakama",
"Huirangi",
"Hukerenui",
"Hunterville",
"Huntly",
"Hurleyville",

"Inangahua Junction",
"Inglewood",
"Invercargill",

"Jack's Point",
"Jacobs River",

"Kaeo",
"Kaiapoi",
"Kaihu",
"Kaikohe",
"Kaikoura",
"Kaimata",
"Kaingaroa",
"Kaipara Flats",
"Kairaki",
"Kaitaia",
"Kaitangata",
"Kaiwaka",
"Kakanui",
"Kakaramea",
"Kaniere",
"Kaponga",
"Karamea",
"Karetu",
"Karitane",
"Katikati",
"Kaukapakapa",
"Kauri",
"Kawakawa",
"Kawerau",
"Kennedy Bay",
"Kerikeri",
"Kihikihi",
"Kingston",
"Kinloch",
"Kirwee",
"Kohukohu",
"Koitiata",
"Kokatahi",
"Kokopu",
"Koromiko",
"Kumara",
"Kumeu",
"Kurow",

"Lauriston",
"Lawrence",
"Leeston",
"Leigh",
"Lepperton",
"Levin",
"Lincoln",
"Linkwater",
"Little River",
"Loburn",
"Lower Hutt",
"Luggate",
"Lumsden",
"Lyttelton",

"Makahu",
"Manaia, Coromandel",
"Manaia, Taranaki",
"Manakau",
"Manapouri",
"Mangakino",
"Mangamuka",
"Mangatoki",
"Mangawhai",
"Manukau",
"Manurewa",
"Manutahi",
"Mapua",
"Maraetai",
"Marco",
"Maromaku",
"Marsden Bay",
"Martinborough",
"Marton",
"Maruia",
"Masterton",
"Matakana",
"Matakohe",
"Matamata",
"Matapu",
"Matarangi",
"Matarau",
"Matata",
"Mataura",
"Matihetihe",
"Maungakaramea",
"Maungatapere",
"Maungaturoto",
"Mayfield",
"Meremere",
"Methven",
"Middlemarch",
"Midhirst",
"Millers Flat",
"Milton",
"Mimi",
"Minginui",
"Moana",
"Moawhango",
"Moenui",
"Moeraki",
"Moerewa",
"Mokau",
"Mokoia",
"Morrinsville",
"Mosgiel",
"Mossburn",
"Motatau",
"Motueka",
"Mount Maunganui",
"Mount Somers",
"Murchison",
"Murupara",

"Napier",
"Naseby",
"Nelson",
"New Brighton",
"New Plymouth",
"Ngaere",
"Ngamatapouri",
"Ngapara",
"Ngaruawahia",
"Ngataki",
"Ngatea",
"Ngongotaha",
"Ngunguru",
"Nightcaps",
"Norfolk",
"Normanby",
"Norsewood",

"Oakura",
"Oamaru",
"Oban",
"Ohaeawai",
"Ohakune",
"Ohangai",
"Ohoka",
"Ōhope Beach",
"Ohura",
"Okaihau",
"Okato",
"Okuku",
"Omanaia",
"Omarama",
"Omata",
"Omokoroa",
"Onewhero",
"Opononi",
"Opotiki",
"Opua",
"Opunake",
"Oratia",
"Orewa",
"Oromahoe",
"Oruaiti",
"Otaika",
"Otaki",
"Otakou",
"Otara",
"Otautau",
"Otiria",
"Otorohanga",
"Owaka",
"Oxford",

"Paekakariki",
"Paeroa",
"Pahiatua",
"Paihia",
"Pakaraka",
"Pakiri",
"Pakotai",
"Palmerston",
"Palmerston North",
"Pamapuria",
"Panguru",
"Papakura",
"Papamoa",
"Paparoa",
"Paparore",
"Papatoetoe",
"Parakai",
"Paraparaumu",
"Paremoremo",
"Pareora",
"Paroa",
"Parua Bay",
"Patea",
"Pauanui",
"Pauatahanui",
"Pegasus",
"Peka Peka",
"Pembroke",
"Peria",
"Petone",
"Picton",
"Piopio",
"Pipiwai",
"Pirongia",
"Pleasant Point",
"Plimmerton",
"Pokeno",
"Porirua",
"Poroti",
"Port Chalmers",
"Portland",
"Portobello",
"Pukekohe",
"Pukepoto",
"Pukerua Bay",
"Pukeuri",
"Punakaiki",
"Purua",
"Putaruru",
"Putorino",

"Queenstown",

"Raetihi",
"Raglan",
"Rahotu",
"Rai Valley",
"Rakaia",
"Ramarama",
"Ranfurly",
"Rangiora",
"Rapaura",
"Ratapiko",
"Raumati",
"Rawene",
"Rawhitiroa",
"Reefton",
"Renwick",
"Reporoa",
"Richmond",
"Riverhead",
"Riverlands",
"Riversdale",
"Riversdale Beach",
"Riverton",
"Riwaka",
"Rolleston",
"Ross",
"Rotorua",
"Roxburgh",
"Ruakaka",
"Ruatoria",
"Ruawai",
"Runanga",
"Russell",

"Saint Andrews",
"Saint Arnaud",
"Saint Bathans",
"Sanson",
"Seacliff",
"Seddon",
"Seddonville",
"Sefton",
"Shannon",
"Sheffield",
"Silverdale",
"Snells Beach",
"Spring Creek",
"Springfield",
"Springston",
"Stirling",
"Stratford",
"Swannanoa",

"Taharoa",
"Taieri Mouth",
"Taihape",
"Taipa-Mangonui",
"Tairua",
"Takaka",
"Tangiteroria",
"Tangowahine",
"Tapanui",
"Tapawera",
"Tapora",
"Tapu",
"Taradale",
"Tauhoa",
"Taumarunui",
"Taupaki",
"Taupo",
"Tauranga",
"Tauraroa",
"Tautoro",
"Te Anau",
"Te Arai",
"Te Aroha",
"Te Awamutu",
"Te Awanga",
"Te Hapua",
"Te Horo",
"Te Kao",
"Te Kauwhata",
"Te Kopuru",
"Te Kuiti",
"Te Poi",
"Te Puke",
"Te Puru",
"Te Rerenga",
"Temuka",
"Thames",
"Tikorangi",
"Timaru",
"Tinopai",
"Tinwald",
"Tirau",
"Titoki",
"Tokanui",
"Tokarahi",
"Toko",
"Tokoroa",
"Tolaga Bay",
"Tomarata",
"Towai",
"Tuahiwi",
"Tuai",
"Tuakau",
"Tuamarina",
"Tuatapere",
"Turangi",
"Twizel",

"Umawera",
"Upper Hutt",
"Upper Moutere",
"Urenui",
"Uruti",

"View Hill",

"Waddington",
"Waharoa",
"Waiharara",
"Waiheke Island",
"Waihi",
"Waihi Beach",
"Waihola",
"Waikaia",
"Waikaka",
"Waikanae",
"Waikawa, Marlborough",
"Waikawa, Southland",
"Waikouaiti",
"Waikuku",
"Waikuku Beach",
"Waima",
"Waimangaroa",
"Waimate",
"Waimate North",
"Waimauku",
"Wainui",
"Wainuiomata",
"Waioneke",
"Waiotira",
"Waiouru",
"Waipango",
"Waipawa",
"Waipukurau",
"Wairakei",
"Wairau Valley",
"Wairoa",
"Waitahuna",
"Waitara",
"Waitaria Bay",
"Waitati",
"Waitoa",
"Waitoki",
"Waitoriki",
"Waitotara",
"Waiuku",
"Waiwera",
"Wakefield",
"Wallacetown",
"Walton",
"Wanaka",
"Ward",
"Wardville",
"Warkworth",
"Warrington",
"Waverley",
"Wellington",
"Wellsford",
"Weston",
"Westport",
"Whakamaru",
"Whakatane",
"Whananaki",
"Whangamata",
"Whangamomona",
"Whanganui",
"Whangarei",
"Whangarei Heads",
"Whangaruru",
"Whataroa",
"Whatuwhiwhi",
"Whenuakite",
"Whenuakura",
"Whiritoa",
"Whitby",
"Whitford",
"Whitianga",
"Willowby",
"Wimbledon",
"Winchester",
"Windsor",
"Windwhistle",
"Winscombe",
"Winton",
"Woodend",
"Woodend Beach",
"Woodhill",
"Woodville",
"Wyndham",
};

        double lat, lng;

        PLCity obj= new PLCity();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            ACSearch = FindViewById<AutoCompleteTextView>(Resource.Id.txtSearch);

            Cities = FindViewById<TextView>(Resource.Id.txtCity);
            Time = FindViewById<TextView>(Resource.Id.txtTime);
            CTtemp = FindViewById<TextView>(Resource.Id.txtCTemp);

            Day1 = FindViewById<TextView>(Resource.Id.txtDay1);
            Day2 = FindViewById<TextView>(Resource.Id.txtDay2);
            Day3 = FindViewById<TextView>(Resource.Id.txtDay3);
            Day4 = FindViewById<TextView>(Resource.Id.txtDay4);
            Day5 = FindViewById<TextView>(Resource.Id.txtDay5);

            Temp1 = FindViewById<TextView>(Resource.Id.txtTemp1);
            Temp2 = FindViewById<TextView>(Resource.Id.txtTemp2);
            Temp3 = FindViewById<TextView>(Resource.Id.txtTemp3);
            Temp4 = FindViewById<TextView>(Resource.Id.txtTemp4);
            Temp5 = FindViewById<TextView>(Resource.Id.txtTemp5);

            LinearLayout Bg = FindViewById<LinearLayout>(Resource.Id.bg);

            Bg.SetBackgroundResource(Resource.Drawable.Chalk);

            Confirm = FindViewById<Button>(Resource.Id.btnConfirm);

            img1 = FindViewById<ImageView>(Resource.Id.img1);
            img2 = FindViewById<ImageView>(Resource.Id.img2);
            img3 = FindViewById<ImageView>(Resource.Id.img3);
            img4 = FindViewById<ImageView>(Resource.Id.img4);
            img5 = FindViewById<ImageView>(Resource.Id.img5);

            var adapter = new ArrayAdapter<String>(this, Resource.Layout.Place, NZPlaces);

            ACSearch.Adapter = adapter;

            //LoadWeather("Hamilton");

            getGpsAsync();
        }

        public void LoadWeatherGPS()
        {
            var root = obj.ExecuteRequestlatlong(lat,lng);
            var rootCurrent = obj.ExecuteRequestCurrentlatlong(lat,lng);

            Cities.Text = root.city.name;

            var newdate = UnixTimeStampToDateTime(root.list[0].dt);

            int day = newdate.AddDays(1).Day;

            Time.Text = day.ToString() + "/" + newdate.AddDays(1).Date.Month.ToString() + "/" + newdate.AddDays(1).Date.Year.ToString();

            var newdate1 = UnixTimeStampToDateTime(root.list[1].dt);
            Day1.Text = newdate1.AddDays(1).DayOfWeek.ToString();

            var newdate2 = UnixTimeStampToDateTime(root.list[2].dt);
            Day2.Text = newdate2.AddDays(1).DayOfWeek.ToString();

            var newdate3 = UnixTimeStampToDateTime(root.list[3].dt);
            Day3.Text = newdate3.AddDays(1).DayOfWeek.ToString();

            var newdate4 = UnixTimeStampToDateTime(root.list[4].dt);
            Day4.Text = newdate4.AddDays(1).DayOfWeek.ToString();

            var newdate5 = UnixTimeStampToDateTime(root.list[5].dt);
            Day5.Text = newdate5.AddDays(1).DayOfWeek.ToString();

            Temp1.Text = Math.Round(root.list[0].temp.max).ToString() + " / " + Math.Round(root.list[0].temp.min).ToString();
            Temp2.Text = Math.Round(root.list[1].temp.max).ToString() + " / " + Math.Round(root.list[1].temp.min).ToString();
            Temp3.Text = Math.Round(root.list[2].temp.max).ToString() + " / " + Math.Round(root.list[2].temp.min).ToString();
            Temp4.Text = Math.Round(root.list[3].temp.max).ToString() + " / " + Math.Round(root.list[3].temp.min).ToString();
            Temp5.Text = Math.Round(root.list[4].temp.max).ToString() + " / " + Math.Round(root.list[4].temp.min).ToString();

            CTtemp.Text = Math.Round(rootCurrent.main.temp).ToString() + "\n" + rootCurrent.weather[0].description;

            Confirm.Click += Confirm_Click;

            if (root.list[0].weather[0].id >= 200)
            {
                img1.SetImageResource(Resource.Drawable.Thunder);
            }

            if (root.list[0].weather[0].id >= 300)
            {
                img1.SetImageResource(Resource.Drawable.Showers);
            }

            if (root.list[0].weather[0].id >= 500)
            {
                img1.SetImageResource(Resource.Drawable.Rain);
            }

            if (root.list[0].weather[0].id >= 504)
            {
                img1.SetImageResource(Resource.Drawable.Showers);
            }

            if (root.list[0].weather[0].id >= 600)
            {
                img1.SetImageResource(Resource.Drawable.Snow);
            }

            if (root.list[0].weather[0].id >= 700)
            {
                img1.SetImageResource(Resource.Drawable.Mist);
            }

            if (root.list[0].weather[0].id == 800)
            {
                img1.SetImageResource(Resource.Drawable.Clear);
            }

            if (root.list[0].weather[0].id == 801)
            {
                img1.SetImageResource(Resource.Drawable.FewClouds);
            }

            if (root.list[0].weather[0].id >= 802)
            {
                img1.SetImageResource(Resource.Drawable.Scatter);
            }

            if (root.list[0].weather[0].id >= 803)
            {
                img1.SetImageResource(Resource.Drawable.Broken);
            }

            //2
            if (root.list[1].weather[0].id >= 200)
            {
                img2.SetImageResource(Resource.Drawable.Thunder);
            }

            if (root.list[1].weather[0].id >= 300)
            {
                img2.SetImageResource(Resource.Drawable.Showers);
            }

            if (root.list[1].weather[0].id >= 500)
            {
                img2.SetImageResource(Resource.Drawable.Rain);
            }

            if (root.list[1].weather[0].id >= 504)
            {
                img2.SetImageResource(Resource.Drawable.Showers);
            }

            if (root.list[1].weather[0].id >= 600)
            {
                img2.SetImageResource(Resource.Drawable.Snow);
            }

            if (root.list[1].weather[0].id >= 700)
            {
                img2.SetImageResource(Resource.Drawable.Mist);
            }

            if (root.list[1].weather[0].id == 800)
            {
                img2.SetImageResource(Resource.Drawable.Clear);
            }

            if (root.list[1].weather[0].id == 801)
            {
                img2.SetImageResource(Resource.Drawable.FewClouds);
            }

            if (root.list[1].weather[0].id >= 802)
            {
                img2.SetImageResource(Resource.Drawable.Scatter);
            }

            if (root.list[1].weather[0].id >= 803)
            {
                img2.SetImageResource(Resource.Drawable.Broken);
            }

            //3
            if (root.list[2].weather[0].id >= 200)
            {
                img3.SetImageResource(Resource.Drawable.Thunder);
            }

            if (root.list[2].weather[0].id >= 300)
            {
                img3.SetImageResource(Resource.Drawable.Showers);
            }

            if (root.list[2].weather[0].id >= 500)
            {
                img3.SetImageResource(Resource.Drawable.Rain);
            }

            if (root.list[2].weather[0].id >= 504)
            {
                img3.SetImageResource(Resource.Drawable.Showers);
            }

            if (root.list[2].weather[0].id >= 600)
            {
                img3.SetImageResource(Resource.Drawable.Snow);
            }

            if (root.list[2].weather[0].id >= 700)
            {
                img3.SetImageResource(Resource.Drawable.Mist);
            }

            if (root.list[2].weather[0].id == 800)
            {
                img3.SetImageResource(Resource.Drawable.Clear);
            }

            if (root.list[2].weather[0].id == 801)
            {
                img3.SetImageResource(Resource.Drawable.FewClouds);
            }

            if (root.list[2].weather[0].id >= 802)
            {
                img3.SetImageResource(Resource.Drawable.Scatter);
            }

            if (root.list[2].weather[0].id >= 803)
            {
                img3.SetImageResource(Resource.Drawable.Broken);
            }

            //4
            if (root.list[3].weather[0].id >= 200)
            {
                img4.SetImageResource(Resource.Drawable.Thunder);
            }

            if (root.list[3].weather[0].id >= 300)
            {
                img4.SetImageResource(Resource.Drawable.Showers);
            }

            if (root.list[3].weather[0].id >= 500)
            {
                img4.SetImageResource(Resource.Drawable.Rain);
            }

            if (root.list[3].weather[0].id >= 504)
            {
                img4.SetImageResource(Resource.Drawable.Showers);
            }

            if (root.list[3].weather[0].id >= 600)
            {
                img4.SetImageResource(Resource.Drawable.Snow);
            }

            if (root.list[3].weather[0].id >= 700)
            {
                img4.SetImageResource(Resource.Drawable.Mist);
            }

            if (root.list[3].weather[0].id == 800)
            {
                img4.SetImageResource(Resource.Drawable.Clear);
            }

            if (root.list[3].weather[0].id == 801)
            {
                img4.SetImageResource(Resource.Drawable.FewClouds);
            }

            if (root.list[3].weather[0].id >= 802)
            {
                img4.SetImageResource(Resource.Drawable.Scatter);
            }

            if (root.list[3].weather[0].id >= 803)
            {
                img4.SetImageResource(Resource.Drawable.Broken);
            }

            //5
            if (root.list[4].weather[0].id >= 200)
            {
                img5.SetImageResource(Resource.Drawable.Thunder);
            }

            if (root.list[4].weather[0].id >= 300)
            {
                img5.SetImageResource(Resource.Drawable.Showers);
            }

            if (root.list[4].weather[0].id >= 500)
            {
                img5.SetImageResource(Resource.Drawable.Rain);
            }

            if (root.list[4].weather[0].id >= 504)
            {
                img5.SetImageResource(Resource.Drawable.Showers);
            }

            if (root.list[4].weather[0].id >= 600)
            {
                img5.SetImageResource(Resource.Drawable.Snow);
            }

            if (root.list[4].weather[0].id >= 700)
            {
                img5.SetImageResource(Resource.Drawable.Mist);
            }

            if (root.list[4].weather[0].id == 800)
            {
                img5.SetImageResource(Resource.Drawable.Clear);
            }

            if (root.list[4].weather[0].id == 801)
            {
                img5.SetImageResource(Resource.Drawable.FewClouds);
            }

            if (root.list[4].weather[0].id >= 802)
            {
                img5.SetImageResource(Resource.Drawable.Scatter);
            }

            if (root.list[4].weather[0].id >= 803)
            {
                img5.SetImageResource(Resource.Drawable.Broken);
            }

            
        }

        public void LoadWeather(string City)
        {
            var root = obj.ExecuteRequest(City + ",nz");
            var rootCurrent = obj.ExecuteRequestCurrent(City + ",nz");

            Cities.Text = root.city.name;

            var newdate = UnixTimeStampToDateTime(root.list[0].dt);

            int day = newdate.AddDays(1).Day;

            Time.Text = day.ToString() + "/" + newdate.AddDays(1).Date.Month.ToString() + "/" + newdate.AddDays(1).Date.Year.ToString();

            var newdate1 = UnixTimeStampToDateTime(root.list[1].dt);
            Day1.Text = newdate1.AddDays(1).DayOfWeek.ToString();

            var newdate2 = UnixTimeStampToDateTime(root.list[2].dt);
            Day2.Text = newdate2.AddDays(1).DayOfWeek.ToString();

            var newdate3 = UnixTimeStampToDateTime(root.list[3].dt);
            Day3.Text = newdate3.AddDays(1).DayOfWeek.ToString();

            var newdate4 = UnixTimeStampToDateTime(root.list[4].dt);
            Day4.Text = newdate4.AddDays(1).DayOfWeek.ToString();

            var newdate5 = UnixTimeStampToDateTime(root.list[5].dt);
            Day5.Text = newdate5.AddDays(1).DayOfWeek.ToString();

            Temp1.Text = Math.Round(root.list[0].temp.max).ToString() + " / " + Math.Round(root.list[0].temp.min).ToString();
            Temp2.Text = Math.Round(root.list[1].temp.max).ToString() + " / " + Math.Round(root.list[1].temp.min).ToString();
            Temp3.Text = Math.Round(root.list[2].temp.max).ToString() + " / " + Math.Round(root.list[2].temp.min).ToString();
            Temp4.Text = Math.Round(root.list[3].temp.max).ToString() + " / " + Math.Round(root.list[3].temp.min).ToString();
            Temp5.Text = Math.Round(root.list[4].temp.max).ToString() + " / " + Math.Round(root.list[4].temp.min).ToString();

            CTtemp.Text = Math.Round(rootCurrent.main.temp).ToString() + "\n" + rootCurrent.weather[0].description;

            Confirm.Click += Confirm_Click;

            

            if (root.list[0].weather[0].id >= 200)
            {
                img1.SetImageResource(Resource.Drawable.Thunder);
            }

            if (root.list[0].weather[0].id >= 300)
            {
                img1.SetImageResource(Resource.Drawable.Showers);
            }

            if (root.list[0].weather[0].id >= 500)
            {
                img1.SetImageResource(Resource.Drawable.Rain);
            }

            if (root.list[0].weather[0].id >= 504)
            {
                img1.SetImageResource(Resource.Drawable.Showers);
            }

            if (root.list[0].weather[0].id >= 600)
            {
                img1.SetImageResource(Resource.Drawable.Snow);
            }

            if (root.list[0].weather[0].id >= 700)
            {
                img1.SetImageResource(Resource.Drawable.Mist);
            }

            if (root.list[0].weather[0].id == 800)
            {
                img1.SetImageResource(Resource.Drawable.Clear);
            }

            if (root.list[0].weather[0].id == 801)
            {
                img1.SetImageResource(Resource.Drawable.FewClouds);
            }

            if (root.list[0].weather[0].id >= 802)
            {
                img1.SetImageResource(Resource.Drawable.Scatter);
            }

            if (root.list[0].weather[0].id >= 803)
            {
                img1.SetImageResource(Resource.Drawable.Broken);
            }

            //2
            if (root.list[1].weather[0].id >= 200)
            {
                img2.SetImageResource(Resource.Drawable.Thunder);
            }

            if (root.list[1].weather[0].id >= 300)
            {
                img2.SetImageResource(Resource.Drawable.Showers);
            }

            if (root.list[1].weather[0].id >= 500)
            {
                img2.SetImageResource(Resource.Drawable.Rain);
            }

            if (root.list[1].weather[0].id >= 504)
            {
                img2.SetImageResource(Resource.Drawable.Showers);
            }

            if (root.list[1].weather[0].id >= 600)
            {
                img2.SetImageResource(Resource.Drawable.Snow);
            }

            if (root.list[1].weather[0].id >= 700)
            {
                img2.SetImageResource(Resource.Drawable.Mist);
            }

            if (root.list[1].weather[0].id == 800)
            {
                img2.SetImageResource(Resource.Drawable.Clear);
            }

            if (root.list[1].weather[0].id == 801)
            {
                img2.SetImageResource(Resource.Drawable.FewClouds);
            }

            if (root.list[1].weather[0].id >= 802)
            {
                img2.SetImageResource(Resource.Drawable.Scatter);
            }

            if (root.list[1].weather[0].id >= 803)
            {
                img2.SetImageResource(Resource.Drawable.Broken);
            }

            //3
            if (root.list[2].weather[0].id >= 200)
            {
                img3.SetImageResource(Resource.Drawable.Thunder);
            }

            if (root.list[2].weather[0].id >= 300)
            {
                img3.SetImageResource(Resource.Drawable.Showers);
            }

            if (root.list[2].weather[0].id >= 500)
            {
                img3.SetImageResource(Resource.Drawable.Rain);
            }

            if (root.list[2].weather[0].id >= 504)
            {
                img3.SetImageResource(Resource.Drawable.Showers);
            }

            if (root.list[2].weather[0].id >= 600)
            {
                img3.SetImageResource(Resource.Drawable.Snow);
            }

            if (root.list[2].weather[0].id >= 700)
            {
                img3.SetImageResource(Resource.Drawable.Mist);
            }

            if (root.list[2].weather[0].id == 800)
            {
                img3.SetImageResource(Resource.Drawable.Clear);
            }

            if (root.list[2].weather[0].id == 801)
            {
                img3.SetImageResource(Resource.Drawable.FewClouds);
            }

            if (root.list[2].weather[0].id >= 802)
            {
                img3.SetImageResource(Resource.Drawable.Scatter);
            }

            if (root.list[2].weather[0].id >= 803)
            {
                img3.SetImageResource(Resource.Drawable.Broken);
            }

            //4
            if (root.list[3].weather[0].id >= 200)
            {
                img4.SetImageResource(Resource.Drawable.Thunder);
            }

            if (root.list[3].weather[0].id >= 300)
            {
                img4.SetImageResource(Resource.Drawable.Showers);
            }

            if (root.list[3].weather[0].id >= 500)
            {
                img4.SetImageResource(Resource.Drawable.Rain);
            }

            if (root.list[3].weather[0].id >= 504)
            {
                img4.SetImageResource(Resource.Drawable.Showers);
            }

            if (root.list[3].weather[0].id >= 600)
            {
                img4.SetImageResource(Resource.Drawable.Snow);
            }

            if (root.list[3].weather[0].id >= 700)
            {
                img4.SetImageResource(Resource.Drawable.Mist);
            }

            if (root.list[3].weather[0].id == 800)
            {
                img4.SetImageResource(Resource.Drawable.Clear);
            }

            if (root.list[3].weather[0].id == 801)
            {
                img4.SetImageResource(Resource.Drawable.FewClouds);
            }

            if (root.list[3].weather[0].id >= 802)
            {
                img4.SetImageResource(Resource.Drawable.Scatter);
            }

            if (root.list[3].weather[0].id >= 803)
            {
                img4.SetImageResource(Resource.Drawable.Broken);
            }

            //5
            if (root.list[4].weather[0].id >= 200)
            {
                img5.SetImageResource(Resource.Drawable.Thunder);
            }

            if (root.list[4].weather[0].id >= 300)
            {
                img5.SetImageResource(Resource.Drawable.Showers);
            }

            if (root.list[4].weather[0].id >= 500)
            {
                img5.SetImageResource(Resource.Drawable.Rain);
            }

            if (root.list[4].weather[0].id >= 504)
            {
                img5.SetImageResource(Resource.Drawable.Showers);
            }

            if (root.list[4].weather[0].id >= 600)
            {
                img5.SetImageResource(Resource.Drawable.Snow);
            }

            if (root.list[4].weather[0].id >= 700)
            {
                img5.SetImageResource(Resource.Drawable.Mist);
            }

            if (root.list[4].weather[0].id == 800)
            {
                img5.SetImageResource(Resource.Drawable.Clear);
            }

            if (root.list[4].weather[0].id == 801)
            {
                img5.SetImageResource(Resource.Drawable.FewClouds);
            }

            if (root.list[4].weather[0].id >= 802)
            {
                img5.SetImageResource(Resource.Drawable.Scatter);
            }

            if (root.list[4].weather[0].id >= 803)
            {
                img5.SetImageResource(Resource.Drawable.Broken);
            }

           
        }

        public async void getGpsAsync()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            string test = "Getting gps";

            var position = await locator.GetPositionAsync(10000);

            if (position == null)
            {
                test = "null gps :(";
                return;
            }
            test = string.Format("Time: {0} \nLat: {1} \nLong: {2} \n Altitude: {3} \nAltitude Accuracy: {4} \nAccuracy: {5} \n Heading: {6} \n Speed: {7}",
            position.Timestamp, position.Latitude, position.Longitude,
            position.Altitude, position.AltitudeAccuracy, position.Accuracy, position.Heading, position.Speed);

            Toast.MakeText(this, " GPS location is" + test, ToastLength.Long).Show();

            lat = position.Latitude;
            lng = position.Longitude;

            LoadWeatherGPS(); 
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            try
            {
                    if (NZPlaces.Contains(ACSearch.Text))
                    {
                        LoadWeather(ACSearch.Text);
                    }
                    else
                    {
                        Toast.MakeText(this, "Please enter in a valid place.", ToastLength.Long).Show();
                    }
            }
            catch (Exception)
            {
                Toast.MakeText(this, "Sorry this place is not registered on our weather station.", ToastLength.Long).Show();
            }
            
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

    }
}

