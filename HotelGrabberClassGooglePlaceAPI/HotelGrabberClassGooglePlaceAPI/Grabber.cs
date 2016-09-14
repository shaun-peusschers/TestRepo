using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Threading;

namespace HotelGrabberClassGooglePlaceAPI
{
    class Grabber
    {
        public static List<AreaCoordinatePair> AreaCoordinatePairList = new List<AreaCoordinatePair>();
        public static List<String> AutoCompleteListofTowns = new List<string>();

        public Grabber(String APIKey)
        {
            this.APIKey = APIKey;

        }
        String _LastStatus;
        bool _LastSearchSuccess;
        int _LastAddressCount;

        public int LastAddressCount
        {
            get
            {
                return _LastAddressCount;
            }

        }
        public String LastStatus
        {
            get
            {
                return _LastStatus;
            }
           
        }
        public bool LastSearchSuccess
        {
            get
            {
                return _LastSearchSuccess;
            }
           
        }
        public static AutoCompleteStringCollection AutoCompleteData
        {
            get
            {
                AutoCompleteStringCollection allowedTypes = new AutoCompleteStringCollection();
                allowedTypes.AddRange(Grabber.AutoCompleteListofTowns.ToArray());
                return allowedTypes;
            }

        }

        public String APIKey
        {
            get;
            set;
        }

        static Grabber()
        {

            AreaCoordinatePairList.Add(new AreaCoordinatePair("Aalwynsfontein", -30.4166667, 18.6333333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Aan de Doorns", -33.7, 19.5));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Aberdeen", 57.149717, -2.094278));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Aberfeldy", 56.621752, -3.866969));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Abbotsdale", -33.486944, 18.675833));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Acornhoek", -24.6006166, 31.0851019));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Adelaide", -34.9286212, 138.5999594));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Adendorp", -32.2826499, 24.5566499));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Addo", -33.5267165, 25.7116584));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Aggeneys", -29.2, 18.85));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("L'Agulhas", -34.822222, 20.016667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Agulhas", -34.822222, 20.016667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Ahrens", -29.066667, 30.766667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Akasia", -25.647, 28.0998));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Albertinia", -34.2, 21.583333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Alberton", -26.267222, 28.121944));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Alderley", -27.4239203, 152.9999563));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Aldinville", -29.38883, 31.25268));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Alexander Bay", -28.6073653, 16.4847619));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Alexandria", 31.2000924, 29.9187387));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Alexandra", -26.103833, 28.096167));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Alettasrus", -26.633333, 24.5));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Alice", -23.679633, -46.599189));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Alicedale", -33.316667, 26.083333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Aliwal North", -30.7, 26.7));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Allandale", -28.833333, 27.133333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Allanridge", -27.7561818, 26.6376476));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Alldays", -22.6824604, 29.1027149));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Allep", -29.68222, 25.22833));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Alpha", -28.3666667, 28.5166667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Amalia", -27.248056, 25.045833));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Amalienstein", -33.483333, 21.466667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Amanzimtoti", -30.05, 30.883333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Amersfoort", 52.1561113, 5.3878266));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Amsterdam", 52.3702157, 4.8951679));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Anerley", 51.408661, -0.059686));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Arlington", 38.8799697, -77.1067698));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Arniston", -34.6819538, 20.2266293));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Ashton", -33.834722, 20.054722));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Askham", -26.983333, 20.783333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Atlantis", -33.566667, 18.483333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Atteridgeville", -25.773333, 28.071389));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Augrabies", -28.672732, 20.4284431));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Aurora", 39.7294319, -104.8319195));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Baardskeerdersbos", -34.588889, 19.570833));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Babelegi", -25.355381, 28.2789735));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Babanango", -28.3768085, 31.0836691));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Badplaas", -25.953889, 30.566667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bailey", 34.0913057, -102.8975098));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bakerville", -25.9833329, 26.083333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Balfour", -26.65, 28.583333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Balfour", -26.65, 28.583333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Balgowan", -34.3241468, 137.4949971));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Ballengeich", -27.88583, 29.97861));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Ballito", -29.533333, 31.216667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Balmoral", 57.0396646, -3.2292362));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Baltimore", 39.2903848, -76.6121893));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Banana Beach", -30.6627778, 30.5166667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bandelierkop", -23.31861, 29.80028));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bandur", 46.7923288, 9.3265244));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bank, Gauteng", -26.3198959, 27.5121586));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bankkop", -26.5769444, 30.3802778));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Ba-Phalaborwa", -23.9423181, 31.1406753));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bapsfontein", -25.995579, 28.380243));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Barakke", -32.3577129, 22.568723));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Barberspan", -26.6211099, 25.5722199));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Barberton", 41.012833, -81.6051221));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Barkly East", -30.968056, 27.593333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Barkly West", -28.5367371, 24.5197643));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Baroda", 22.3071588, 73.1812187));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Baroe", -33.22417, 24.56806));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Barrington", 42.1539141, -88.1361888));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Barrydale", -33.9076091, 20.7182064));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bathurst", -33.4176529, 149.5810314));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Baviaan", -33.20333, 20.74222));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bayala", 22.7584826, 72.3148329));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bazley", -30.44028, 30.66333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Beaufort West", -32.35, 22.583333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Beauty", 36.2234269, -81.3878001));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bedford", 52.1359729, -0.4666546));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Beestekraal", -25.37818, 27.595579));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Beitbridge", -22.216667, 30));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bekker", -26.0010574, 28.1195926));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bela-Bela", -24.883333, 28.283333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Belfast", 54.597285, -5.93012));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bell", -33.5060669, 150.2791777));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bellevue", 47.610377, -122.2006786));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bellville", -33.9, 18.633333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Belmont", 41.7952778, -88.0380556));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bendigo", -36.7587109, 144.2837466));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Benoni", -26.188333, 28.320556));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Berbice", -27.2, 31.15));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Berea", -29.850833, 30.993056));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bergplaas", -33.883333, 22.666667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bergrivier", -32.9166669, 18.316667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bergville", -28.7304834, 29.3511681));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Berlin", 52.5200066, 13.404954));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bermolli", 43.8372693, 10.6218355));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Besters", -28.433333, 29.65));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bethal", -26.4578664, 29.466654));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bethanie", -29.6, 25.95));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bethelsdorp", -33.883333, 25.5));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bethlehem", -28.233333, 28.3));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bethulie", -30.511242, 25.9822747));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Betty's Bay", -34.36, 18.9));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bewley", -25.616667, 25.716667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Biesiespoort", -31.71444, 23.1838899));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Biesiesvlei", -26.3790146, 25.91132));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Biggarsberg", -28.1838889, 29.9902778));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bhisho", -32.849444, 27.438056));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bitterfontein", -31.036111, 18.266111));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bityi|", -31.80861, 28.535));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bloemfontein", -29.116667, 26.216667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bloemhof", -27.65, 25.59));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Boipatong", -26.666667, 27.85));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Boksburg", -26.2125, 28.2625));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bonnievale", -33.9275, 20.100556));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bonza Bay", -32.9715734, 27.9585823));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bophelong", -26.6933767, 27.7783831));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bosbokrand", -24.8398416, 31.0464101));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Boshof", -28.55, 25.233333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Boston", 42.3600825, -71.0588801));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bothaville", -27.383333, 26.616667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Botshabelo", -29.233056, 26.733056));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Brakpan", -26.235278, 28.37));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Brandfort", -28.7, 26.466667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Braunschweig", 52.2688736, 10.5267696));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bray", 53.200903, -6.1110741));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bredasdorp", -34.533333, 20.041667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Breyten", -26.3, 29.983333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Brits", -25.6099895, 27.7959713));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Britstown", -30.583333, 23.5));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Broederstroom", -25.8020308, 27.8762004));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bronkhorstspruit", -25.805, 28.746389));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bultfontein", -28.286944, 26.150556));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Bulwer", -29.8, 29.766667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Burgersdorp", -30.992222, 26.324722));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Burgersfort", -24.6813666, 30.3349024));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Boompie Alleen", -27.28667, 28.97333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Butterworth", 5.4380309, 100.388192));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Cala", -31.523, 27.698));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Caledon", 43.8363372, -79.8744836));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Calitzdorp", -33.537386, 21.685164));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Calvert", -37.4820399, 142.81606));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Calvinia", -31.4703452, 19.7948852));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Cambria", 35.5641381, -121.0807468));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Campbell", 37.2871651, -121.9499568));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Camperdown", -33.8868973, 151.176639));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Camps Bay", -33.95, 18.383333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Candover", -27.47194, 31.94667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Cannon Rocks", -33.7441968, 26.5521384));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Cape St. Francis", -34.196944, 24.838056));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Cape Town", -33.9248685, 18.4240553));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Cape Vidal", -28.1166667, 32.5666667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Carletonville", -26.358056, 27.398056));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Carlow", 52.7189747, -6.8503703));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Carlsonia", 46.4075061, -120.2673136));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Carlton", -37.8010469, 144.9698607));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Carnarvon", -30.966667, 22.133333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Carolina", 18.3807819, -65.9573872));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Catalina Bay", -36.7917887, 174.6737374));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Carolusberg", -29.6356001, 17.9517021));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Cathcart", -32.3, 27.133333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Cato Ridge", -29.716, 30.616));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Cedarville", -30.388056, 29.041111));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Centurion", -25.860278, 28.189444));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Ceres", -29.8828106, -61.9491615));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Chalumna", -33.0434659, 27.5950731));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Chantelle", -25.6625, 28.091667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Charl Cilliers", -26.666667, 29.183333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Charlestown", 42.3782065, -71.0602131));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Chintsa", -32.823269, 28.1151939));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Chrissiesmeer", -26.278, 30.213));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Christiana", -27.92, 25.16));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Chuniespoort", -26.3806257, 27.6287329));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Churchaven", -33.1772354, 18.0652034));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Citrusdal", -32.5891267, 19.0118333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Clansthal", -30.2278451, 30.769476));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Clanwilliam", -32.178611, 18.891111));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Claremont", -33.980556, 18.465278));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Clarens", -28.516667, 28.416667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Clarkebury", -31.789, 28.28));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Clarkson", -34.01, 24.341));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Clermont", -29.7921121, 30.9015642));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Clewer", -25.9066199, 29.131795));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Clifford", -31.083333, 27.45));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Clifton", 40.8584328, -74.1637553));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Clocolan", -28.9, 27.566944));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Coalville", 52.724569, -1.3677109));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Coega", -33.7979321, 25.6717085));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Concordia", -31.3913921, -58.017434));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Coffee Bay", -31.9849029, 29.1492404));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Cofimvaba", -32.0025, 27.580556));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Coghlan", -34.560694, -58.474722));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Colchester", 51.895927, 0.891874));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Coleford", 51.7934409, -2.6174728));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Colesberg", -30.716667, 25.1));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Colenso", -28.736667, 29.826389));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Coligny", 46.382954, 5.346038));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Colston", -27.2589942, 23.8450885));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Commondale", 54.487235, -0.981619));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Constantia", -34.0257608, 18.4230789));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Copperton", 40.5646688, -112.0974407));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Cornelia", -27.234167, 28.850833));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Cork", 51.8968917, -8.4863157));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Cookhouse", -32.75, 25.816667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Cradock", -32.183333, 25.616667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Cullinan", -25.6709965, 28.5238227));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Danielskuil", -28.2, 23.583333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Dannhauser", -28, 30.05));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Darling", -33.383333, 18.383333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Darnall", -29.27236, 31.3738));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Daveyton", -26.138611, 28.425));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("De Aar", -30.65, 24.016667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Dealesville", -28.666667, 25.766667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("De Doorns", -33.4776601, 19.6669068));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("De Kelders", -34.5624055, 19.3575011));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Delareyville", -26.683333, 25.466667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Delmas", -26.15, 28.683333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Delportshoop", -28.416667, 24.3));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Deneysville", -26.895, 28.098333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Derby", 52.9225301, -1.4746186));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("De Rust", -33.4907417, 22.5304693));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Despatch", -33.801547, 25.476781));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Devon", 50.7772135, -3.999461));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Dewetsdorp", -29.583333, 26.666667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Dibeng", -23.7753685, 28.9310295));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Dingleton", -27.78179, 22.9849089));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Doonside", -33.7633531, 150.8699783));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Doringbaai", -31.816667, 18.233333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Dordrecht", 51.8132979, 4.6900929));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Douglas", 54.1523372, -4.4861228));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Drummond", -29.76, 30.69));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Duduza", -26.3725731, 28.4075474));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Duiwelskloof", -23.7, 30.133333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Dullstroom", -25.4183833, 30.1040715));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Dundee", 56.462018, -2.970721));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Durban", -29.8586804, 31.0218404));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Dutywa", -32.1, 28.3));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Dysselsdorp", -33.5630867, 22.4163416));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Edenburg", -29.734722, 25.936944));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Edenvale", -26.141111, 28.152778));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Edenville", -27.55, 27.666667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Eendekuil", -32.6885416, 18.8841141));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("East London", -32.983333, 27.866667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("ekuPhakameni", -26.24195, 30.82627));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Elandsbaai", -32.3134951, 18.350464));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Elandslaagte", -31, 26.466667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Elim", -34.583333, 19.75));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Elgin", 57.649454, -3.318485));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Elliot", -31.333333, 27.85));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Empangeni", -28.7532196, 31.8935123));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Ermelo", -26.533333, 29.983333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Eshowe", -28.888333, 31.448333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Estcourt", -29, 29.883333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Evaton", -26.5275, 27.846667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Excelsior", -28.9312695, 27.0617553));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Fauresmith", -29.75, 25.316667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Ficksburg", -28.873694, 27.878111));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Fisherhaven", -34.360833, 19.129722));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Flagstaff", 35.1982836, -111.651302));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Fort Beaufort", -32.783333, 26.633333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Fouriesburg", -28.62275, 28.210894));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Frankfort", 38.2009055, -84.8732835));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Franklin", 35.9250637, -86.8688899));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Franskraal", -34.603506, 19.399141));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Franschhoek", -33.916667, 19.133333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Fraserburg", -31.9149495, 21.5133587));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Gansbaai", -34.5805395, 19.3517531));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Ganyesa", -26.5919275, 24.1711193));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Ga-Rankuwa", -25.5881952, 28.0068979));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Gcuwa", -32.3323496, 28.1446262));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Genadendal", -34.0417712, 19.5625739));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("George", -33.966667, 22.45));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Germiston", -26.217778, 28.167222));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Giyani", -23.31, 30.706389));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Glencoe", 56.6825599, -5.1022713));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Gonubie", -32.943, 28.008));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Gouda", 52.0115205, 4.7104633));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Graaff-Reinet", -32.252222, 24.540556));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Graafwater", -32.1534088, 18.6042029));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Grabouw", -34.15, 19.016667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Grahamstown", -33.3, 26.526667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Graskop", -24.931667, 30.841667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Gravelotte, Limpopo", -23.9509759, 30.6185513));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Greylingstad", -26.743319, 28.7540675));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Greyton", -34.05, 19.616667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Greytown", -41.0847758, 175.4555185));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Griekwastad", -28.85, 23.25));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Groblersdal", -25.167361, 29.3986919));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Groblershoop", -28.897222, 21.984444));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Groot Marico", -25.588, 26.401));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Haenertsburg", -23.9447206, 29.938638));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Hammanskraal", -25.4120326, 28.2672801));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Hankey", -33.831389, 24.880833));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Harrismith", -28.283333, 29.133333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Hartbeespoort", -25.7477324, 27.8871784));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Hattingspruit", -28.0784108, 30.1315037));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Hazyview", -25.033333, 31.116667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Hectorspruit", -25.4397991, 31.6810647));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Heidelberg", -34.083333, 20.95));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Heidelberg", -34.083333, 20.95));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Heilbron", -27.283611, 27.970833));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Henley on Klip", -26.535278, 28.061111));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Hennenman", -27.9783916, 27.026445));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Hermanus", -34.4092004, 19.2504436));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Hertzogville", -28.133333, 25.5));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Hibberdene", -30.571879, 30.5724824));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Hillcrest", -29.78, 30.762778));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Hilton", -29.55, 30.3));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Himeville", -29.75, 29.5));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Hluhluwe", -28.018889, 32.2675));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Hobhouse", -29.533333, 27.15));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Hoedspruit", -24.354167, 30.947222));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Hofmeyr", -31.633333, 25.8));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Hoopstad", -27.833333, 25.916667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Hopefield", -33.065556, 18.350833));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Hopetown", -29.625833, 24.085556));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Howick", -29.4892951, 30.2166519));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Humansdorp", -34.033333, 24.766667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Ifafa Beach", -30.4623128, 30.6509076));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Illovo Beach", -30.1174964, 30.8484588));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Impendle", -29.598333, 29.867778));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Inanda", -29.683333, 30.933333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Ingwavuma", -27.133333, 32));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Irene", -25.8811884, 28.226347));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Isando", -26.1393376, 28.2088013));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Isipingo", -29.9825487, 30.9216522));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Ixopo", -30.157222, 30.064722));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Jansenville", -32.933333, 24.666667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Jacobsdal", -29.128333, 24.775));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Jagersfontein", -29.765758, 25.4363342));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Jeffreys Bay", -34.033333, 24.916667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Johannesburg", -26.2041028, 28.0473051));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Kaapmuiden", -25.533333, 31.316667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Karridene", -30.1241961, 30.8427163));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Katlehong", -26.3651259, 28.1526196));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Kempton Park", -26.1, 28.233333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Kenton-on-Sea", -33.6805779, 26.6700737));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Kestell", -28.316667, 28.7));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Keurboomstrand", -34, 23.45));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Kgotsong", -26.3477195, 27.333333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Khayelitsha", -34.040278, 18.677778));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Kimberley", -28.741944, 24.771944));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Kingsburgh", -30.083333, 30.866667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("King William's Town", -32.883333, 27.4));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Kinross", 56.206132, -3.4229));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Kirkwood", -33.3990758, 25.4431597));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Klerksdorp", -26.8598225, 26.6317514));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Kloof", -29.783333, 30.833333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Knysna", -34.0350856, 23.0464693));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Koffiefontein", -29.408056, 25.002222));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Kokstad", -30.553889, 29.426944));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Komatipoort", -25.433333, 31.95));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Koppies", -27.233333, 27.583333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Kromdraai", -29.2, 26.5));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Kroonstad", -27.65, 27.233333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Kriel", -26.2551061, 29.2633978));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Krugersdorp", -26.1, 27.766667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("KwaDukuza", -29.3669655, 31.2660004));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("KwaMashu", -29.75, 30.983333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("KwaMhlanga", -25.432, 28.708));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("KwaThema", -26.2863716, 28.4002447));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Ladybrand", -29.2, 27.45));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Lady Frere", -31.703, 27.234));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Lady Grey", -30.7102921, 27.2382163));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Ladysmith", -28.5596713, 29.780789));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Laingsburg", 42.8903086, -84.3513631));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("La Lucia", -29.75, 31.058));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("La Mercy", -29.633333, 31.133333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Lambert's Bay", -32.0978443, 18.3267319));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Lenasia", -26.316944, 27.827778));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Lephalale", -23.6664659, 27.7448285));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Lichtenburg", -26.1093224, 26.1713917));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Lindley", -27.9008809, 27.9131832));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Lyttelton", -43.6032583, 172.7193227));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Loopspruit", -25.5554844, 28.7246568));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Louis Trichardt", -23.0462413, 29.9046562));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Louwsburg", -27.583333, 31.283333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Luckhoff", -29.75, 24.783333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Lydenburg", -25.096, 30.446));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Machadodorp", -25.666667, 30.25));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Maclear", -31.0637563, 28.3345061));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Madadeni", -27.7507512, 30.0708566));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Mafikeng", -25.855978, 25.64031));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Magabeni", -30.17, 30.767));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Magaliesburg", -25.9934195, 27.5437144));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Mahlabatini", -28.2315972, 31.4698984));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Makeleketla", -28.5323842, 26.9999584));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Malelane", -25.483333, 31.516667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Mamelodi", -25.7234441, 28.4221519));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Mandini", -29.1565066, 31.412158));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Marble Hall", -24.9650576, 29.2814687));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Margate", -30.85, 30.366667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Marquard", -28.666667, 27.433333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Matatiele", -30.342222, 28.806111));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Matjiesfontein", -33.2307354, 20.5826261));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Melmoth", -28.5773566, 31.3941835));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Memel", 55.7032948, 21.1442794));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Merrivale", 50.557622, -4.049531));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Meyerton", -26.5583, 28.0197));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Middelburg", -31.506809, 25.017521));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Middelburg", -31.506809, 25.017521));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Midrand", -25.9991795, 28.1262927));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Mkuze", -27.616667, 32.033333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Mmabatho", -25.8377623, 25.594752));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Modder River", -29, 24.6333333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Modimolle", -24.7, 28.406111));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Mokopane", -24.1808673, 29.0138998));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Molteno", -31.396111, 26.363056));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Mooirivier", -29.2106317, 30.0029572));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Morgenzon", -26.733056, 29.615278));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Mount Edgecombe", -29.721, 31.05));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Mount Fletcher", -30.6914475, 28.5051382));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Mossel Bay", -34.183333, 22.133333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Mthatha", -31.6066839, 28.7780987));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Mtubatuba", -28.416667, 32.183333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Mtunzini", -28.9596737, 31.7500778));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Muden", -28.966667, 30.383333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Muldersdrift", -26.0357664, 27.8484446));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Musina", -22.338056, 30.041667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Naboomspruit", -24.516667, 28.716667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Nelspruit", -25.4752984, 30.9694163));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Newcastle", -27.744167, 29.937222));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("New Germany", -29.8, 30.883333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("New Hanover", 34.2154913, -77.8824596));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Engcobo", -31.675, 28));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Nieu-Bethesda", -31.8652034, 24.5521132));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Nigel", -26.3903078, 28.4630376));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Nongoma", -27.8942891, 31.6454222));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Nottingham Road", -29.3557779, 29.9993445));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Odendaalsrus", -27.866667, 26.683333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Ogies", -26.050556, 29.0525));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Ohrigstad", -24.75, 30.566667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Orania, Northern Cape", -29.8149831, 24.3995073));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Oranjeville", -26.983333, 28.2));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Orchards", -26.1526149, 28.0756882));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Orkney", 58.936601, -2.743876));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Oudtshoorn", -33.6007225, 22.2026347));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Oyster Bay", -34.0070312, 151.0809796));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Paarl", -33.724167, 18.955833));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Palm Beach", 26.7056206, -80.0364297));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Park Rynie", -30.316667, 30.733333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Parys", -26.9, 27.45));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Patensie", -33.758889, 24.814722));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Paterson", 40.9167654, -74.171811));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Paulpietersburg", -27.416667, 30.816667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Paul Roux", -28.3, 27.95));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Pennington", -30.383333, 30.7));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Perdekop", -27.164669, 29.6238368));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Petrusburg", -29.116667, 25.416667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Petrus Steyn", -27.65, 28.133333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Phalaborwa", -23.9424435, 31.1409218));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Philippolis", -30.266667, 25.283333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Phuthaditjhaba", -28.533333, 28.816667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Piet Retief", -27, 30.8));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Pietermaritzburg", -29.6006068, 30.3794118));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Piketberg", -32.9, 18.766667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Pilgrim's Rest", -24.7836, 30.7916));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Pinetown", -29.816667, 30.85));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Plettenberg Bay", -34.05, 23.366667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Pniel", -33.8880642, 18.9591376));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Polokwane", -23.8961708, 29.4486263));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Pomeroy", 54.5943155, -6.9290099));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Pongola", -27.383333, 31.616667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Port Alfred", -33.6, 26.883333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Port Edward", -31.05, 30.216667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Port Elizabeth", -33.958056, 25.6));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Port Shepstone", -30.75, 30.45));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Port St. Johns", -31.6288, 29.5369));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Potchefstroom", -26.7145297, 27.0970475));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Pretoria", -25.746111, 28.188056));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Prieska", -29.668333, 22.743889));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Queensburgh", -29.8793508, 30.907304));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Queenstown", -31.9, 26.883333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Ramsgate", 51.335545, 1.419895));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Randburg", -26.093611, 28.006389));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Randfontein", -26.179722, 27.704167));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Ratanda", -26.55, 28.333333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Reddersburg", -29.65, 26.166667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Reitz", -27.8009575, 28.4318311));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Richards Bay", -28.7807276, 32.0382856));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Richmond", 37.5407246, -77.4360481));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Riebeek Kasteel", -33.385336, 18.898514));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Roodepoort", -26.1625, 27.8725));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Rooihuiskraal", -25.8959672, 28.1561533));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Rosendal", 59.9858957, 6.0115682));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Rouxville", -30.416667, 26.833333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Rustenburg", -25.6544483, 27.255854));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Sabie", -25.097778, 30.779167));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Salt Rock", -29.4940719, 31.2411748));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Sandton", -26.1075663, 28.0567007));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Sasolburg", -26.8101899, 27.8277254));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Schweizer-Reneke", -27.183333, 25.333333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Scottburgh", -30.3216098, 30.6890055));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Sebokeng", -26.576944, 27.840556));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Secunda", -26.516111, 29.202778));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Senekal", -28.316667, 27.6));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Sezela", -30.4071763, 30.6602534));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Sharpeville", -26.688611, 27.871389));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Shawela", -23.4805683, 30.3421093));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Shelly Beach", -30.8043563, 30.4115883));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Smithfield", -30.2125, 26.531389));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Somerset East", -32.716667, 25.583333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Somerset West", -34.083333, 18.85));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Soshanguve", -25.5226464, 28.1005726));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Southbroom", -30.92, 30.317));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Soweto", -26.2485377, 27.8540323));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Springbok", -29.666667, 17.883333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Springfontein", -30.253889, 25.703889));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Springs", -26.254722, 28.442778));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Standerton", -26.95, 29.25));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Stilfontein", -26.8428169, 26.7745188));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Stellenbosch", -33.9321045, 18.860152));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Steynsburg", -31.2990504, 25.8225997));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Steynsrus", -27.95, 27.566667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("St Francis Bay", -34.162, 24.83));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("St Lucia", 13.909444, -60.978893));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("St Michael's-on-sea", 51.3406958, 0.7383998));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Strand", -34.1123197, 18.849207));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Strydenburg", -29.933333, 23.666667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Stutterheim", -32.566667, 27.416667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Swartberg", -33.366667, 22.354167));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Swellendam", -34.033333, 20.433333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Swinburne", -28.35, 29.283333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Tarkastad", -32.016667, 26.266667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Tembisa", -26.0063121, 28.2108827));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Thaba Nchu", -29.2, 26.833333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Thabazimbi", -24.6, 27.4));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Theunissen", -28.4019346, 26.7100581));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Thohoyandou", -22.95, 30.483333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Thokoza", -26.3556981, 28.1327491));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Tongaat", -29.566667, 31.116667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Trichardt", -26.483333, 29.216667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Trompsburg", -30.0336296, 25.7797302));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Tsakane", -26.35, 28.366667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Tugela Ferry", -28.7415512, 30.461686));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Tulbagh", -33.285, 19.137778));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Tweeling", -27.55, 28.516667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Tweespruit", -29.185556, 27.028889));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Ubombo", -27.560985, 32.0844546));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Uitenhage", -33.766667, 25.4));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Ulundi", -28.316667, 31.416667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Umbogintwini", -30.0216412, 30.9015642));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Umdloti", -29.666667, 31.116667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Umgababa", -30.1333148, 30.8326663));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Umhlanga Rocks", -29.7399369, 31.0779377));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Umkomaas", -30.201, 30.794));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Umlazi", -29.966667, 30.883333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Umtentweni", -30.716667, 30.466667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("uMthatha", -31.6066839, 28.7780987));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Umzinto", -30.316667, 30.666667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Umzumbe", -30.4848267, 30.2974199));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Underberg", -29.783333, 29.5));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Upington", -28.4, 21.266667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Uniondale, Western Cape", -33.659167, 23.123889));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Utrecht", 52.0907374, 5.1214201));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Uvongo", -30.8324918, 30.3839017));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Vaalbank", -25.1602436, 28.8407455));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Vaalwater", -24.2971536, 28.1151939));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Vanderbijlpark", -26.699167, 27.835556));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Van Reenen", -28.376, 29.381));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Van Stadensrus", -29.9869396, 27.0293878));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Ventersburg", -28.083333, 27.133333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Vereeniging", -26.673611, 27.931944));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Verkeerdevlei", -28.833333, 26.783333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Verulam", -29.65, 31.05));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Victoria West", -31.403056, 23.120556));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Viljoenskroon", -27.216667, 26.95));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Villiers", -27.033333, 28.6));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Virginia", 37.4315734, -78.6568942));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Vivo", -23.0432422, 29.2766931));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Volksrust", -27.366667, 29.883333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Vosloorus", -26.358333, 28.2075));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Vrede", -27.43, 29.16));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Vredefort", -27.0007882, 27.3733989));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Vryburg", -26.9584048, 24.7298615));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Vryheid", -27.766944, 30.8));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Wakkerstroom", -27.35, 30.133333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Warden", 45.3797379, -72.5043523));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Warner Beach", -30.085, 30.862));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Warrenton", 38.8211845, -91.1391977));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Wartburg", 50.9663423, 10.3063424));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Wasbank", -28.313889, 30.107222));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Waterval Boven", -25.6429145, 30.3406679));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Waterval Onder", -25.6477799, 30.38));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Weenen", -28.85, 30.066667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Welkom", -27.983056, 26.720833));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Wellington", -33.633333, 18.983333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Wepener", -29.733333, 27.033333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Wesselsbron", -27.85, 26.366667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Westonaria", -26.3142974, 27.6480347));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Westville", -29.831, 30.925));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("White River", -25.316667, 31.016667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Whittlesea", -32.166667, 26.816667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Wilderness", -33.9940082, 22.5748481));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Williston", -31.35, 20.916667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Winburg", -28.533333, 27.016667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Winkelspruit", -30.09806, 30.85694));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Winterton", -28.8166405, 29.5296214));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Witbank", -25.8727817, 29.2553229));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Wolmaransstad", -27.216667, 25.966667));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Worcester", -33.645, 19.443611));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("York", 53.9599651, -1.0872979));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Zastron", -30.3, 27.083333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Zeerust", -25.533333, 26.083333));
            AreaCoordinatePairList.Add(new AreaCoordinatePair("Zwelitsha", -32.916667, 27.416667));
            AutoCompleteListofTowns.Add("Aalwynsfontein");
            AutoCompleteListofTowns.Add("Aan de Doorns");
            AutoCompleteListofTowns.Add("Aberdeen");
            AutoCompleteListofTowns.Add("Aberfeldy");
            AutoCompleteListofTowns.Add("Abbotsdale");
            AutoCompleteListofTowns.Add("Acornhoek");
            AutoCompleteListofTowns.Add("Adelaide");
            AutoCompleteListofTowns.Add("Adendorp");
            AutoCompleteListofTowns.Add("Addo");
            AutoCompleteListofTowns.Add("Aggeneys");
            AutoCompleteListofTowns.Add("L'Agulhas");
            AutoCompleteListofTowns.Add("Agulhas");
            AutoCompleteListofTowns.Add("Ahrens");
            AutoCompleteListofTowns.Add("Akasia");
            AutoCompleteListofTowns.Add("Albertinia");
            AutoCompleteListofTowns.Add("Alberton");
            AutoCompleteListofTowns.Add("Alderley");
            AutoCompleteListofTowns.Add("Aldinville");
            AutoCompleteListofTowns.Add("Alexander Bay");
            AutoCompleteListofTowns.Add("Alexandria");
            AutoCompleteListofTowns.Add("Alexandra");
            AutoCompleteListofTowns.Add("Alettasrus");
            AutoCompleteListofTowns.Add("Alice");
            AutoCompleteListofTowns.Add("Alicedale");
            AutoCompleteListofTowns.Add("Aliwal North");
            AutoCompleteListofTowns.Add("Allandale");
            AutoCompleteListofTowns.Add("Allanridge");
            AutoCompleteListofTowns.Add("Alldays");
            AutoCompleteListofTowns.Add("Allep");
            AutoCompleteListofTowns.Add("Alpha");
            AutoCompleteListofTowns.Add("Amalia");
            AutoCompleteListofTowns.Add("Amalienstein");
            AutoCompleteListofTowns.Add("Amanzimtoti");
            AutoCompleteListofTowns.Add("Amersfoort");
            AutoCompleteListofTowns.Add("Amsterdam");
            AutoCompleteListofTowns.Add("Anerley");
            AutoCompleteListofTowns.Add("Arlington");
            AutoCompleteListofTowns.Add("Arniston");
            AutoCompleteListofTowns.Add("Ashton");
            AutoCompleteListofTowns.Add("Askham");
            AutoCompleteListofTowns.Add("Atlantis");
            AutoCompleteListofTowns.Add("Atteridgeville");
            AutoCompleteListofTowns.Add("Augrabies");
            AutoCompleteListofTowns.Add("Aurora");
            AutoCompleteListofTowns.Add("Baardskeerdersbos");
            AutoCompleteListofTowns.Add("Babelegi");
            AutoCompleteListofTowns.Add("Babanango");
            AutoCompleteListofTowns.Add("Badplaas");
            AutoCompleteListofTowns.Add("Bailey");
            AutoCompleteListofTowns.Add("Bakerville");
            AutoCompleteListofTowns.Add("Balfour");
            AutoCompleteListofTowns.Add("Balfour");
            AutoCompleteListofTowns.Add("Balgowan");
            AutoCompleteListofTowns.Add("Ballengeich");
            AutoCompleteListofTowns.Add("Ballito");
            AutoCompleteListofTowns.Add("Balmoral");
            AutoCompleteListofTowns.Add("Baltimore");
            AutoCompleteListofTowns.Add("Banana Beach");
            AutoCompleteListofTowns.Add("Bandelierkop");
            AutoCompleteListofTowns.Add("Bandur");
            AutoCompleteListofTowns.Add("Bank, Gauteng");
            AutoCompleteListofTowns.Add("Bankkop");
            AutoCompleteListofTowns.Add("Ba-Phalaborwa");
            AutoCompleteListofTowns.Add("Bapsfontein");
            AutoCompleteListofTowns.Add("Barakke");
            AutoCompleteListofTowns.Add("Barberspan");
            AutoCompleteListofTowns.Add("Barberton");
            AutoCompleteListofTowns.Add("Barkly East");
            AutoCompleteListofTowns.Add("Barkly West");
            AutoCompleteListofTowns.Add("Baroda");
            AutoCompleteListofTowns.Add("Baroe");
            AutoCompleteListofTowns.Add("Barrington");
            AutoCompleteListofTowns.Add("Barrydale");
            AutoCompleteListofTowns.Add("Bathurst");
            AutoCompleteListofTowns.Add("Baviaan");
            AutoCompleteListofTowns.Add("Bayala");
            AutoCompleteListofTowns.Add("Bazley");
            AutoCompleteListofTowns.Add("Beaufort West");
            AutoCompleteListofTowns.Add("Beauty");
            AutoCompleteListofTowns.Add("Bedford");
            AutoCompleteListofTowns.Add("Beestekraal");
            AutoCompleteListofTowns.Add("Beitbridge");
            AutoCompleteListofTowns.Add("Bekker");
            AutoCompleteListofTowns.Add("Bela-Bela");
            AutoCompleteListofTowns.Add("Belfast");
            AutoCompleteListofTowns.Add("Bell");
            AutoCompleteListofTowns.Add("Bellevue");
            AutoCompleteListofTowns.Add("Bellville");
            AutoCompleteListofTowns.Add("Belmont");
            AutoCompleteListofTowns.Add("Bendigo");
            AutoCompleteListofTowns.Add("Benoni");
            AutoCompleteListofTowns.Add("Berbice");
            AutoCompleteListofTowns.Add("Berea");
            AutoCompleteListofTowns.Add("Bergplaas");
            AutoCompleteListofTowns.Add("Bergrivier");
            AutoCompleteListofTowns.Add("Bergville");
            AutoCompleteListofTowns.Add("Berlin");
            AutoCompleteListofTowns.Add("Bermolli");
            AutoCompleteListofTowns.Add("Besters");
            AutoCompleteListofTowns.Add("Bethal");
            AutoCompleteListofTowns.Add("Bethanie");
            AutoCompleteListofTowns.Add("Bethelsdorp");
            AutoCompleteListofTowns.Add("Bethlehem");
            AutoCompleteListofTowns.Add("Bethulie");
            AutoCompleteListofTowns.Add("Betty's Bay");
            AutoCompleteListofTowns.Add("Bewley");
            AutoCompleteListofTowns.Add("Biesiespoort");
            AutoCompleteListofTowns.Add("Biesiesvlei");
            AutoCompleteListofTowns.Add("Biggarsberg");
            AutoCompleteListofTowns.Add("Bhisho");
            AutoCompleteListofTowns.Add("Bitterfontein");
            AutoCompleteListofTowns.Add("Bityi|");
            AutoCompleteListofTowns.Add("Bloemfontein");
            AutoCompleteListofTowns.Add("Bloemhof");
            AutoCompleteListofTowns.Add("Boipatong");
            AutoCompleteListofTowns.Add("Boksburg");
            AutoCompleteListofTowns.Add("Bonnievale");
            AutoCompleteListofTowns.Add("Bonza Bay");
            AutoCompleteListofTowns.Add("Bophelong");
            AutoCompleteListofTowns.Add("Bosbokrand");
            AutoCompleteListofTowns.Add("Boshof");
            AutoCompleteListofTowns.Add("Boston");
            AutoCompleteListofTowns.Add("Bothaville");
            AutoCompleteListofTowns.Add("Botshabelo");
            AutoCompleteListofTowns.Add("Brakpan");
            AutoCompleteListofTowns.Add("Brandfort");
            AutoCompleteListofTowns.Add("Braunschweig");
            AutoCompleteListofTowns.Add("Bray");
            AutoCompleteListofTowns.Add("Bredasdorp");
            AutoCompleteListofTowns.Add("Breyten");
            AutoCompleteListofTowns.Add("Brits");
            AutoCompleteListofTowns.Add("Britstown");
            AutoCompleteListofTowns.Add("Broederstroom");
            AutoCompleteListofTowns.Add("Bronkhorstspruit");
            AutoCompleteListofTowns.Add("Bultfontein");
            AutoCompleteListofTowns.Add("Bulwer");
            AutoCompleteListofTowns.Add("Burgersdorp");
            AutoCompleteListofTowns.Add("Burgersfort");
            AutoCompleteListofTowns.Add("Boompie Alleen");
            AutoCompleteListofTowns.Add("Butterworth");
            AutoCompleteListofTowns.Add("Cala");
            AutoCompleteListofTowns.Add("Caledon");
            AutoCompleteListofTowns.Add("Calitzdorp");
            AutoCompleteListofTowns.Add("Calvert");
            AutoCompleteListofTowns.Add("Calvinia");
            AutoCompleteListofTowns.Add("Cambria");
            AutoCompleteListofTowns.Add("Campbell");
            AutoCompleteListofTowns.Add("Camperdown");
            AutoCompleteListofTowns.Add("Camps Bay");
            AutoCompleteListofTowns.Add("Candover");
            AutoCompleteListofTowns.Add("Cannon Rocks");
            AutoCompleteListofTowns.Add("Cape St. Francis");
            AutoCompleteListofTowns.Add("Cape Town");
            AutoCompleteListofTowns.Add("Cape Vidal");
            AutoCompleteListofTowns.Add("Carletonville");
            AutoCompleteListofTowns.Add("Carlow");
            AutoCompleteListofTowns.Add("Carlsonia");
            AutoCompleteListofTowns.Add("Carlton");
            AutoCompleteListofTowns.Add("Carnarvon");
            AutoCompleteListofTowns.Add("Carolina");
            AutoCompleteListofTowns.Add("Catalina Bay");
            AutoCompleteListofTowns.Add("Carolusberg");
            AutoCompleteListofTowns.Add("Cathcart");
            AutoCompleteListofTowns.Add("Cato Ridge");
            AutoCompleteListofTowns.Add("Cedarville");
            AutoCompleteListofTowns.Add("Centurion");
            AutoCompleteListofTowns.Add("Ceres");
            AutoCompleteListofTowns.Add("Chalumna");
            AutoCompleteListofTowns.Add("Chantelle");
            AutoCompleteListofTowns.Add("Charl Cilliers");
            AutoCompleteListofTowns.Add("Charlestown");
            AutoCompleteListofTowns.Add("Chintsa");
            AutoCompleteListofTowns.Add("Chrissiesmeer");
            AutoCompleteListofTowns.Add("Christiana");
            AutoCompleteListofTowns.Add("Chuniespoort");
            AutoCompleteListofTowns.Add("Churchaven");
            AutoCompleteListofTowns.Add("Citrusdal");
            AutoCompleteListofTowns.Add("Clansthal");
            AutoCompleteListofTowns.Add("Clanwilliam");
            AutoCompleteListofTowns.Add("Claremont");
            AutoCompleteListofTowns.Add("Clarens");
            AutoCompleteListofTowns.Add("Clarkebury");
            AutoCompleteListofTowns.Add("Clarkson");
            AutoCompleteListofTowns.Add("Clermont");
            AutoCompleteListofTowns.Add("Clewer");
            AutoCompleteListofTowns.Add("Clifford");
            AutoCompleteListofTowns.Add("Clifton");
            AutoCompleteListofTowns.Add("Clocolan");
            AutoCompleteListofTowns.Add("Coalville");
            AutoCompleteListofTowns.Add("Coega");
            AutoCompleteListofTowns.Add("Concordia");
            AutoCompleteListofTowns.Add("Coffee Bay");
            AutoCompleteListofTowns.Add("Cofimvaba");
            AutoCompleteListofTowns.Add("Coghlan");
            AutoCompleteListofTowns.Add("Colchester");
            AutoCompleteListofTowns.Add("Coleford");
            AutoCompleteListofTowns.Add("Colesberg");
            AutoCompleteListofTowns.Add("Colenso");
            AutoCompleteListofTowns.Add("Coligny");
            AutoCompleteListofTowns.Add("Colston");
            AutoCompleteListofTowns.Add("Commondale");
            AutoCompleteListofTowns.Add("Constantia");
            AutoCompleteListofTowns.Add("Copperton");
            AutoCompleteListofTowns.Add("Cornelia");
            AutoCompleteListofTowns.Add("Cork");
            AutoCompleteListofTowns.Add("Cookhouse");
            AutoCompleteListofTowns.Add("Cradock");
            AutoCompleteListofTowns.Add("Cullinan");
            AutoCompleteListofTowns.Add("Danielskuil");
            AutoCompleteListofTowns.Add("Dannhauser");
            AutoCompleteListofTowns.Add("Darling");
            AutoCompleteListofTowns.Add("Darnall");
            AutoCompleteListofTowns.Add("Daveyton");
            AutoCompleteListofTowns.Add("De Aar");
            AutoCompleteListofTowns.Add("Dealesville");
            AutoCompleteListofTowns.Add("De Doorns");
            AutoCompleteListofTowns.Add("De Kelders");
            AutoCompleteListofTowns.Add("Delareyville");
            AutoCompleteListofTowns.Add("Delmas");
            AutoCompleteListofTowns.Add("Delportshoop");
            AutoCompleteListofTowns.Add("Deneysville");
            AutoCompleteListofTowns.Add("Derby");
            AutoCompleteListofTowns.Add("De Rust");
            AutoCompleteListofTowns.Add("Despatch");
            AutoCompleteListofTowns.Add("Devon");
            AutoCompleteListofTowns.Add("Dewetsdorp");
            AutoCompleteListofTowns.Add("Dibeng");
            AutoCompleteListofTowns.Add("Dingleton");
            AutoCompleteListofTowns.Add("Doonside");
            AutoCompleteListofTowns.Add("Doringbaai");
            AutoCompleteListofTowns.Add("Dordrecht");
            AutoCompleteListofTowns.Add("Douglas");
            AutoCompleteListofTowns.Add("Drummond");
            AutoCompleteListofTowns.Add("Duduza");
            AutoCompleteListofTowns.Add("Duiwelskloof");
            AutoCompleteListofTowns.Add("Dullstroom");
            AutoCompleteListofTowns.Add("Dundee");
            AutoCompleteListofTowns.Add("Durban");
            AutoCompleteListofTowns.Add("Dutywa");
            AutoCompleteListofTowns.Add("Dysselsdorp");
            AutoCompleteListofTowns.Add("Edenburg");
            AutoCompleteListofTowns.Add("Edenvale");
            AutoCompleteListofTowns.Add("Edenville");
            AutoCompleteListofTowns.Add("Eendekuil");
            AutoCompleteListofTowns.Add("East London");
            AutoCompleteListofTowns.Add("ekuPhakameni");
            AutoCompleteListofTowns.Add("Elandsbaai");
            AutoCompleteListofTowns.Add("Elandslaagte");
            AutoCompleteListofTowns.Add("Elim");
            AutoCompleteListofTowns.Add("Elgin");
            AutoCompleteListofTowns.Add("Elliot");
            AutoCompleteListofTowns.Add("Empangeni");
            AutoCompleteListofTowns.Add("Ermelo");
            AutoCompleteListofTowns.Add("Eshowe");
            AutoCompleteListofTowns.Add("Estcourt");
            AutoCompleteListofTowns.Add("Evaton");
            AutoCompleteListofTowns.Add("Excelsior");
            AutoCompleteListofTowns.Add("Fauresmith");
            AutoCompleteListofTowns.Add("Ficksburg");
            AutoCompleteListofTowns.Add("Fisherhaven");
            AutoCompleteListofTowns.Add("Flagstaff");
            AutoCompleteListofTowns.Add("Fort Beaufort");
            AutoCompleteListofTowns.Add("Fouriesburg");
            AutoCompleteListofTowns.Add("Frankfort");
            AutoCompleteListofTowns.Add("Franklin");
            AutoCompleteListofTowns.Add("Franskraal");
            AutoCompleteListofTowns.Add("Franschhoek");
            AutoCompleteListofTowns.Add("Fraserburg");
            AutoCompleteListofTowns.Add("Gansbaai");
            AutoCompleteListofTowns.Add("Ganyesa");
            AutoCompleteListofTowns.Add("Ga-Rankuwa");
            AutoCompleteListofTowns.Add("Gcuwa");
            AutoCompleteListofTowns.Add("Genadendal");
            AutoCompleteListofTowns.Add("George");
            AutoCompleteListofTowns.Add("Germiston");
            AutoCompleteListofTowns.Add("Giyani");
            AutoCompleteListofTowns.Add("Glencoe");
            AutoCompleteListofTowns.Add("Gonubie");
            AutoCompleteListofTowns.Add("Gouda");
            AutoCompleteListofTowns.Add("Graaff-Reinet");
            AutoCompleteListofTowns.Add("Graafwater");
            AutoCompleteListofTowns.Add("Grabouw");
            AutoCompleteListofTowns.Add("Grahamstown");
            AutoCompleteListofTowns.Add("Graskop");
            AutoCompleteListofTowns.Add("Gravelotte, Limpopo");
            AutoCompleteListofTowns.Add("Greylingstad");
            AutoCompleteListofTowns.Add("Greyton");
            AutoCompleteListofTowns.Add("Greytown");
            AutoCompleteListofTowns.Add("Griekwastad");
            AutoCompleteListofTowns.Add("Groblersdal");
            AutoCompleteListofTowns.Add("Groblershoop");
            AutoCompleteListofTowns.Add("Groot Marico");
            AutoCompleteListofTowns.Add("Haenertsburg");
            AutoCompleteListofTowns.Add("Hammanskraal");
            AutoCompleteListofTowns.Add("Hankey");
            AutoCompleteListofTowns.Add("Harrismith");
            AutoCompleteListofTowns.Add("Hartbeespoort");
            AutoCompleteListofTowns.Add("Hattingspruit");
            AutoCompleteListofTowns.Add("Hazyview");
            AutoCompleteListofTowns.Add("Hectorspruit");
            AutoCompleteListofTowns.Add("Heidelberg");
            AutoCompleteListofTowns.Add("Heidelberg");
            AutoCompleteListofTowns.Add("Heilbron");
            AutoCompleteListofTowns.Add("Henley on Klip");
            AutoCompleteListofTowns.Add("Hennenman");
            AutoCompleteListofTowns.Add("Hermanus");
            AutoCompleteListofTowns.Add("Hertzogville");
            AutoCompleteListofTowns.Add("Hibberdene");
            AutoCompleteListofTowns.Add("Hillcrest");
            AutoCompleteListofTowns.Add("Hilton");
            AutoCompleteListofTowns.Add("Himeville");
            AutoCompleteListofTowns.Add("Hluhluwe");
            AutoCompleteListofTowns.Add("Hobhouse");
            AutoCompleteListofTowns.Add("Hoedspruit");
            AutoCompleteListofTowns.Add("Hofmeyr");
            AutoCompleteListofTowns.Add("Hoopstad");
            AutoCompleteListofTowns.Add("Hopefield");
            AutoCompleteListofTowns.Add("Hopetown");
            AutoCompleteListofTowns.Add("Howick");
            AutoCompleteListofTowns.Add("Humansdorp");
            AutoCompleteListofTowns.Add("Ifafa Beach");
            AutoCompleteListofTowns.Add("Illovo Beach");
            AutoCompleteListofTowns.Add("Impendle");
            AutoCompleteListofTowns.Add("Inanda");
            AutoCompleteListofTowns.Add("Ingwavuma");
            AutoCompleteListofTowns.Add("Irene");
            AutoCompleteListofTowns.Add("Isando");
            AutoCompleteListofTowns.Add("Isipingo");
            AutoCompleteListofTowns.Add("Ixopo");
            AutoCompleteListofTowns.Add("Jansenville");
            AutoCompleteListofTowns.Add("Jacobsdal");
            AutoCompleteListofTowns.Add("Jagersfontein");
            AutoCompleteListofTowns.Add("Jeffreys Bay");
            AutoCompleteListofTowns.Add("Johannesburg");
            AutoCompleteListofTowns.Add("Kaapmuiden");
            AutoCompleteListofTowns.Add("Karridene");
            AutoCompleteListofTowns.Add("Katlehong");
            AutoCompleteListofTowns.Add("Kempton Park");
            AutoCompleteListofTowns.Add("Kenton-on-Sea");
            AutoCompleteListofTowns.Add("Kestell");
            AutoCompleteListofTowns.Add("Keurboomstrand");
            AutoCompleteListofTowns.Add("Kgotsong");
            AutoCompleteListofTowns.Add("Khayelitsha");
            AutoCompleteListofTowns.Add("Kimberley");
            AutoCompleteListofTowns.Add("Kingsburgh");
            AutoCompleteListofTowns.Add("King William's Town");
            AutoCompleteListofTowns.Add("Kinross");
            AutoCompleteListofTowns.Add("Kirkwood");
            AutoCompleteListofTowns.Add("Klerksdorp");
            AutoCompleteListofTowns.Add("Kloof");
            AutoCompleteListofTowns.Add("Knysna");
            AutoCompleteListofTowns.Add("Koffiefontein");
            AutoCompleteListofTowns.Add("Kokstad");
            AutoCompleteListofTowns.Add("Komatipoort");
            AutoCompleteListofTowns.Add("Koppies");
            AutoCompleteListofTowns.Add("Kromdraai");
            AutoCompleteListofTowns.Add("Kroonstad");
            AutoCompleteListofTowns.Add("Kriel");
            AutoCompleteListofTowns.Add("Krugersdorp");
            AutoCompleteListofTowns.Add("KwaDukuza");
            AutoCompleteListofTowns.Add("KwaMashu");
            AutoCompleteListofTowns.Add("KwaMhlanga");
            AutoCompleteListofTowns.Add("KwaThema");
            AutoCompleteListofTowns.Add("Ladybrand");
            AutoCompleteListofTowns.Add("Lady Frere");
            AutoCompleteListofTowns.Add("Lady Grey");
            AutoCompleteListofTowns.Add("Ladysmith");
            AutoCompleteListofTowns.Add("Laingsburg");
            AutoCompleteListofTowns.Add("La Lucia");
            AutoCompleteListofTowns.Add("La Mercy");
            AutoCompleteListofTowns.Add("Lambert's Bay");
            AutoCompleteListofTowns.Add("Lenasia");
            AutoCompleteListofTowns.Add("Lephalale");
            AutoCompleteListofTowns.Add("Lichtenburg");
            AutoCompleteListofTowns.Add("Lindley");
            AutoCompleteListofTowns.Add("Lyttelton");
            AutoCompleteListofTowns.Add("Loopspruit");
            AutoCompleteListofTowns.Add("Louis Trichardt");
            AutoCompleteListofTowns.Add("Louwsburg");
            AutoCompleteListofTowns.Add("Luckhoff");
            AutoCompleteListofTowns.Add("Lydenburg");
            AutoCompleteListofTowns.Add("Machadodorp");
            AutoCompleteListofTowns.Add("Maclear");
            AutoCompleteListofTowns.Add("Madadeni");
            AutoCompleteListofTowns.Add("Mafikeng");
            AutoCompleteListofTowns.Add("Magabeni");
            AutoCompleteListofTowns.Add("Magaliesburg");
            AutoCompleteListofTowns.Add("Mahlabatini");
            AutoCompleteListofTowns.Add("Makeleketla");
            AutoCompleteListofTowns.Add("Malelane");
            AutoCompleteListofTowns.Add("Mamelodi");
            AutoCompleteListofTowns.Add("Mandini");
            AutoCompleteListofTowns.Add("Marble Hall");
            AutoCompleteListofTowns.Add("Margate");
            AutoCompleteListofTowns.Add("Marquard");
            AutoCompleteListofTowns.Add("Matatiele");
            AutoCompleteListofTowns.Add("Matjiesfontein");
            AutoCompleteListofTowns.Add("Melmoth");
            AutoCompleteListofTowns.Add("Memel");
            AutoCompleteListofTowns.Add("Merrivale");
            AutoCompleteListofTowns.Add("Meyerton");
            AutoCompleteListofTowns.Add("Middelburg");
            AutoCompleteListofTowns.Add("Middelburg");
            AutoCompleteListofTowns.Add("Midrand");
            AutoCompleteListofTowns.Add("Mkuze");
            AutoCompleteListofTowns.Add("Mmabatho");
            AutoCompleteListofTowns.Add("Modder River");
            AutoCompleteListofTowns.Add("Modimolle");
            AutoCompleteListofTowns.Add("Mokopane");
            AutoCompleteListofTowns.Add("Molteno");
            AutoCompleteListofTowns.Add("Mooirivier");
            AutoCompleteListofTowns.Add("Morgenzon");
            AutoCompleteListofTowns.Add("Mount Edgecombe");
            AutoCompleteListofTowns.Add("Mount Fletcher");
            AutoCompleteListofTowns.Add("Mossel Bay");
            AutoCompleteListofTowns.Add("Mthatha");
            AutoCompleteListofTowns.Add("Mtubatuba");
            AutoCompleteListofTowns.Add("Mtunzini");
            AutoCompleteListofTowns.Add("Muden");
            AutoCompleteListofTowns.Add("Muldersdrift");
            AutoCompleteListofTowns.Add("Musina");
            AutoCompleteListofTowns.Add("Naboomspruit");
            AutoCompleteListofTowns.Add("Nelspruit");
            AutoCompleteListofTowns.Add("Newcastle");
            AutoCompleteListofTowns.Add("New Germany");
            AutoCompleteListofTowns.Add("New Hanover");
            AutoCompleteListofTowns.Add("Engcobo");
            AutoCompleteListofTowns.Add("Nieu-Bethesda");
            AutoCompleteListofTowns.Add("Nigel");
            AutoCompleteListofTowns.Add("Nongoma");
            AutoCompleteListofTowns.Add("Nottingham Road");
            AutoCompleteListofTowns.Add("Odendaalsrus");
            AutoCompleteListofTowns.Add("Ogies");
            AutoCompleteListofTowns.Add("Ohrigstad");
            AutoCompleteListofTowns.Add("Orania, Northern Cape");
            AutoCompleteListofTowns.Add("Oranjeville");
            AutoCompleteListofTowns.Add("Orchards");
            AutoCompleteListofTowns.Add("Orkney");
            AutoCompleteListofTowns.Add("Oudtshoorn");
            AutoCompleteListofTowns.Add("Oyster Bay");
            AutoCompleteListofTowns.Add("Paarl");
            AutoCompleteListofTowns.Add("Palm Beach");
            AutoCompleteListofTowns.Add("Park Rynie");
            AutoCompleteListofTowns.Add("Parys");
            AutoCompleteListofTowns.Add("Patensie");
            AutoCompleteListofTowns.Add("Paterson");
            AutoCompleteListofTowns.Add("Paulpietersburg");
            AutoCompleteListofTowns.Add("Paul Roux");
            AutoCompleteListofTowns.Add("Pennington");
            AutoCompleteListofTowns.Add("Perdekop");
            AutoCompleteListofTowns.Add("Petrusburg");
            AutoCompleteListofTowns.Add("Petrus Steyn");
            AutoCompleteListofTowns.Add("Phalaborwa");
            AutoCompleteListofTowns.Add("Philippolis");
            AutoCompleteListofTowns.Add("Phuthaditjhaba");
            AutoCompleteListofTowns.Add("Piet Retief");
            AutoCompleteListofTowns.Add("Pietermaritzburg");
            AutoCompleteListofTowns.Add("Piketberg");
            AutoCompleteListofTowns.Add("Pilgrim's Rest");
            AutoCompleteListofTowns.Add("Pinetown");
            AutoCompleteListofTowns.Add("Plettenberg Bay");
            AutoCompleteListofTowns.Add("Pniel");
            AutoCompleteListofTowns.Add("Polokwane");
            AutoCompleteListofTowns.Add("Pomeroy");
            AutoCompleteListofTowns.Add("Pongola");
            AutoCompleteListofTowns.Add("Port Alfred");
            AutoCompleteListofTowns.Add("Port Edward");
            AutoCompleteListofTowns.Add("Port Elizabeth");
            AutoCompleteListofTowns.Add("Port Shepstone");
            AutoCompleteListofTowns.Add("Port St. Johns");
            AutoCompleteListofTowns.Add("Potchefstroom");
            AutoCompleteListofTowns.Add("Pretoria");
            AutoCompleteListofTowns.Add("Prieska");
            AutoCompleteListofTowns.Add("Queensburgh");
            AutoCompleteListofTowns.Add("Queenstown");
            AutoCompleteListofTowns.Add("Ramsgate");
            AutoCompleteListofTowns.Add("Randburg");
            AutoCompleteListofTowns.Add("Randfontein");
            AutoCompleteListofTowns.Add("Ratanda");
            AutoCompleteListofTowns.Add("Reddersburg");
            AutoCompleteListofTowns.Add("Reitz");
            AutoCompleteListofTowns.Add("Richards Bay");
            AutoCompleteListofTowns.Add("Richmond");
            AutoCompleteListofTowns.Add("Riebeek Kasteel");
            AutoCompleteListofTowns.Add("Roodepoort");
            AutoCompleteListofTowns.Add("Rooihuiskraal");
            AutoCompleteListofTowns.Add("Rosendal");
            AutoCompleteListofTowns.Add("Rouxville");
            AutoCompleteListofTowns.Add("Rustenburg");
            AutoCompleteListofTowns.Add("Sabie");
            AutoCompleteListofTowns.Add("Salt Rock");
            AutoCompleteListofTowns.Add("Sandton");
            AutoCompleteListofTowns.Add("Sasolburg");
            AutoCompleteListofTowns.Add("Schweizer-Reneke");
            AutoCompleteListofTowns.Add("Scottburgh");
            AutoCompleteListofTowns.Add("Sebokeng");
            AutoCompleteListofTowns.Add("Secunda");
            AutoCompleteListofTowns.Add("Senekal");
            AutoCompleteListofTowns.Add("Sezela");
            AutoCompleteListofTowns.Add("Sharpeville");
            AutoCompleteListofTowns.Add("Shawela");
            AutoCompleteListofTowns.Add("Shelly Beach");
            AutoCompleteListofTowns.Add("Smithfield");
            AutoCompleteListofTowns.Add("Somerset East");
            AutoCompleteListofTowns.Add("Somerset West");
            AutoCompleteListofTowns.Add("Soshanguve");
            AutoCompleteListofTowns.Add("Southbroom");
            AutoCompleteListofTowns.Add("Soweto");
            AutoCompleteListofTowns.Add("Springbok");
            AutoCompleteListofTowns.Add("Springfontein");
            AutoCompleteListofTowns.Add("Springs");
            AutoCompleteListofTowns.Add("Standerton");
            AutoCompleteListofTowns.Add("Stilfontein");
            AutoCompleteListofTowns.Add("Stellenbosch");
            AutoCompleteListofTowns.Add("Steynsburg");
            AutoCompleteListofTowns.Add("Steynsrus");
            AutoCompleteListofTowns.Add("St Francis Bay");
            AutoCompleteListofTowns.Add("St Lucia");
            AutoCompleteListofTowns.Add("St Michael's-on-sea");
            AutoCompleteListofTowns.Add("Strand");
            AutoCompleteListofTowns.Add("Strydenburg");
            AutoCompleteListofTowns.Add("Stutterheim");
            AutoCompleteListofTowns.Add("Swartberg");
            AutoCompleteListofTowns.Add("Swellendam");
            AutoCompleteListofTowns.Add("Swinburne");
            AutoCompleteListofTowns.Add("Tarkastad");
            AutoCompleteListofTowns.Add("Tembisa");
            AutoCompleteListofTowns.Add("Thaba Nchu");
            AutoCompleteListofTowns.Add("Thabazimbi");
            AutoCompleteListofTowns.Add("Theunissen");
            AutoCompleteListofTowns.Add("Thohoyandou");
            AutoCompleteListofTowns.Add("Thokoza");
            AutoCompleteListofTowns.Add("Tongaat");
            AutoCompleteListofTowns.Add("Trichardt");
            AutoCompleteListofTowns.Add("Trompsburg");
            AutoCompleteListofTowns.Add("Tsakane");
            AutoCompleteListofTowns.Add("Tugela Ferry");
            AutoCompleteListofTowns.Add("Tulbagh");
            AutoCompleteListofTowns.Add("Tweeling");
            AutoCompleteListofTowns.Add("Tweespruit");
            AutoCompleteListofTowns.Add("Ubombo");
            AutoCompleteListofTowns.Add("Uitenhage");
            AutoCompleteListofTowns.Add("Ulundi");
            AutoCompleteListofTowns.Add("Umbogintwini");
            AutoCompleteListofTowns.Add("Umdloti");
            AutoCompleteListofTowns.Add("Umgababa");
            AutoCompleteListofTowns.Add("Umhlanga Rocks");
            AutoCompleteListofTowns.Add("Umkomaas");
            AutoCompleteListofTowns.Add("Umlazi");
            AutoCompleteListofTowns.Add("Umtentweni");
            AutoCompleteListofTowns.Add("uMthatha");
            AutoCompleteListofTowns.Add("Umzinto");
            AutoCompleteListofTowns.Add("Umzumbe");
            AutoCompleteListofTowns.Add("Underberg");
            AutoCompleteListofTowns.Add("Upington");
            AutoCompleteListofTowns.Add("Uniondale, Western Cape");
            AutoCompleteListofTowns.Add("Utrecht");
            AutoCompleteListofTowns.Add("Uvongo");
            AutoCompleteListofTowns.Add("Vaalbank");
            AutoCompleteListofTowns.Add("Vaalwater");
            AutoCompleteListofTowns.Add("Vanderbijlpark");
            AutoCompleteListofTowns.Add("Van Reenen");
            AutoCompleteListofTowns.Add("Van Stadensrus");
            AutoCompleteListofTowns.Add("Ventersburg");
            AutoCompleteListofTowns.Add("Vereeniging");
            AutoCompleteListofTowns.Add("Verkeerdevlei");
            AutoCompleteListofTowns.Add("Verulam");
            AutoCompleteListofTowns.Add("Victoria West");
            AutoCompleteListofTowns.Add("Viljoenskroon");
            AutoCompleteListofTowns.Add("Villiers");
            AutoCompleteListofTowns.Add("Virginia");
            AutoCompleteListofTowns.Add("Vivo");
            AutoCompleteListofTowns.Add("Volksrust");
            AutoCompleteListofTowns.Add("Vosloorus");
            AutoCompleteListofTowns.Add("Vrede");
            AutoCompleteListofTowns.Add("Vredefort");
            AutoCompleteListofTowns.Add("Vryburg");
            AutoCompleteListofTowns.Add("Vryheid");
            AutoCompleteListofTowns.Add("Wakkerstroom");
            AutoCompleteListofTowns.Add("Warden");
            AutoCompleteListofTowns.Add("Warner Beach");
            AutoCompleteListofTowns.Add("Warrenton");
            AutoCompleteListofTowns.Add("Wartburg");
            AutoCompleteListofTowns.Add("Wasbank");
            AutoCompleteListofTowns.Add("Waterval Boven");
            AutoCompleteListofTowns.Add("Waterval Onder");
            AutoCompleteListofTowns.Add("Weenen");
            AutoCompleteListofTowns.Add("Welkom");
            AutoCompleteListofTowns.Add("Wellington");
            AutoCompleteListofTowns.Add("Wepener");
            AutoCompleteListofTowns.Add("Wesselsbron");
            AutoCompleteListofTowns.Add("Westonaria");
            AutoCompleteListofTowns.Add("Westville");
            AutoCompleteListofTowns.Add("White River");
            AutoCompleteListofTowns.Add("Whittlesea");
            AutoCompleteListofTowns.Add("Wilderness");
            AutoCompleteListofTowns.Add("Williston");
            AutoCompleteListofTowns.Add("Winburg");
            AutoCompleteListofTowns.Add("Winkelspruit");
            AutoCompleteListofTowns.Add("Winterton");
            AutoCompleteListofTowns.Add("Witbank");
            AutoCompleteListofTowns.Add("Wolmaransstad");
            AutoCompleteListofTowns.Add("Worcester");
            AutoCompleteListofTowns.Add("York");
            AutoCompleteListofTowns.Add("Zastron");
            AutoCompleteListofTowns.Add("Zeerust");
            AutoCompleteListofTowns.Add("Zwelitsha");
        }



        public List<Hotel> searchHotels(String strName, String AreaName, int radius = 50000)
        {
            List<Hotel> outputHotels = new List<Hotel>();

            Location? tempx = AreaCoordinate(AreaName);

            if (tempx.HasValue)
            {
                outputHotels.AddRange(searchHotels(strName, tempx.Value.Latitude.ToString(), tempx.Value.Longitude.ToString(), radius));
            }

            return outputHotels;
        }

        public List<Hotel> searchHotels(String strName, String Latitude, String Longitude, int radius = 50000, String pageToken = "")
        {

            if (radius > 50000) radius = 50000;
            if (radius <= 0) radius = 1;




            //https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=-33.8670522,151.1957362&radius=500&types=food&name=cruise&key=API_KEY
            List<Hotel> outputHotels = new List<Hotel>();
            try
            {

                UriBuilder uri = new UriBuilder("https://maps.googleapis.com/maps/api/place/nearbysearch/xml");
                NameValueCollection httpValueCollection = HttpUtility.ParseQueryString(uri.Query);

                //https://maps.googleapis.com/maps/api/geocode/xml?address=Toledo&region=es&key=API_KEY

    
               
                if (pageToken.Trim() != "")
                {
                    httpValueCollection.Add("pagetoken", pageToken);

                }
                else
                {
                    httpValueCollection.Add("location", Latitude + "," + Longitude);
                    httpValueCollection.Add("radius", radius.ToString());
                    httpValueCollection.Add("types", "lodging");
                    httpValueCollection.Add("name", strName);
                    _LastAddressCount = 0;

                }
                httpValueCollection.Add("key", APIKey);

                uri.Query = httpValueCollection.ToString();

                var request = (HttpWebRequest)HttpWebRequest.Create(uri.Uri);
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                XDocument doc = XDocument.Load(response.GetResponseStream());

                foreach (XElement el in doc.Root.Elements())
                {
                    if (el.Name == "status")
                    {
                        if (el.Value == "ZERO_RESULTS")
                        {

                            _LastStatus = "No data found for this Search";
                            _LastSearchSuccess = true;
                            return outputHotels;
                        }
                        else if (el.Value == "OVER_QUERY_LIMIT")
                        {
                            _LastStatus = "Quota for your search is over for today";
                            _LastSearchSuccess = false;
                            return outputHotels;
                        }
                        else if (el.Value == "INVALID_REQUEST")
                        {
                            if (pageToken.Trim() == null)
                            {
                                _LastStatus = "INVALID REQUEST!";
                                _LastSearchSuccess = false;
                                return outputHotels;
                            }
                            else
                            {
                                outputHotels.AddRange(searchHotels(strName, Latitude, Longitude, radius = 50000, pageToken));
                                return outputHotels;
                            }
                        }

                        else if (el.Value != "OK")
                        {


                            _LastStatus = "Invalid Key!";
                            _LastSearchSuccess = false;
                            return outputHotels;
                        }
                        _LastStatus = "OK";
                        continue;
                    }

                    if (el.Name == "result")
                    {
                        Hotel newHotel = new Hotel();
                        foreach (XElement result in el.Elements())
                        {
                            if (result.Name == "name")
                            {

                                newHotel.Name = result.Value;
                            }
                            else if (result.Name == "formatted_address" || result.Name == "vicinity")
                            {
                                newHotel.Address = result.Value;
                            }
                            else if (result.Name == "geometry")
                            {

                                foreach (XElement location in result.Elements())
                                {
                                    foreach (XElement latlang in location.Elements())
                                    {
                                        if (latlang.Name == "lat")
                                        {
                                            newHotel.Location.Latitude = Convert.ToDouble(latlang.Value);
                                        }
                                        else if (latlang.Name == "lng")
                                        {
                                            newHotel.Location.Longitude = Convert.ToDouble(latlang.Value);
                                        }
                                    }

                                }

                            }
                            else if (result.Name == "place_id")
                            {
                                newHotel.Place_Id = result.Value;
                            }

                        }
                        if (newHotel.Name.ToUpper().IndexOf(strName.ToUpper()) != -1)
                        {
                            outputHotels.Add(newHotel);
                            _LastAddressCount++;
                        }

                        continue;
                    }
                    if (el.Name == "next_page_token")
                    {
                        Thread.Sleep(50);
                        outputHotels.AddRange(searchHotels(strName, Latitude, Longitude, radius = 50000, el.Value));
                     

                    }


                }



                return outputHotels;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public Location? getCashedArea(String areaName)
        {
            for (int i = 0; i < AreaCoordinatePairList.Count; i++)
            {
                if (AreaCoordinatePairList[i].areaName.ToUpper() == areaName.ToUpper())
                {
                    return AreaCoordinatePairList[i].areaCordinate;
                }
            }
            return null;
        }

        public Location? AreaCoordinate(String areaName)
        {
            Location? tmpXX = getCashedArea(areaName);

            if (tmpXX.HasValue)
            {
                return tmpXX;
            }

            Location tmpX = new Location();
            UriBuilder uri = new UriBuilder("https://maps.googleapis.com/maps/api/geocode/xml");
            NameValueCollection httpValueCollection = HttpUtility.ParseQueryString(uri.Query);
            //https://maps.googleapis.com/maps/api/geocode/xml?address=Toledo&region=es&key=API_KEY
            httpValueCollection.Add("address", areaName);
            httpValueCollection.Add("region", "za");
            httpValueCollection.Add("key", APIKey);
            uri.Query = httpValueCollection.ToString();


            var request = (HttpWebRequest)HttpWebRequest.Create(uri.Uri);
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            XDocument doc = XDocument.Load(response.GetResponseStream());

            foreach (XElement el in doc.Root.Elements())
            {
                if (el.Name == "status")
                {
                    if (el.Value == "ZERO_RESULTS")
                    {
                        
                        _LastStatus = "No data found for this Search";
                        _LastSearchSuccess = true;
                        return null;
                    }
                    else if (el.Value == "OVER_QUERY_LIMIT")
                    {
                        _LastStatus = "Quota for your search is over for today";
                        _LastSearchSuccess = false;
                        return null;
                    }
                    else if (el.Value != "OK")
                    {
                        _LastStatus = "Invalid Key!";
                        _LastSearchSuccess = false;
                        return null;
                    }
                    continue;
                }

                if (el.Name == "result")
                {

                    foreach (XElement result in el.Elements())
                    {

                        if (result.Name == "geometry")
                        {

                            foreach (XElement location in result.Elements())
                            {
                                foreach (XElement latlang in location.Elements())
                                {
                                    if (latlang.Name == "lat")
                                    {
                                        tmpX.Latitude = Convert.ToDouble(latlang.Value);
                                    }
                                    else if (latlang.Name == "lng")
                                    {
                                        tmpX.Longitude = Convert.ToDouble(latlang.Value);
                                    }
                                }

                            }

                        }


                    }
                    break;
                }
            }
            return tmpX;
        }





        //public List<Hotel> searchHotels(String strName, String pageToken = "")
        //{

        //    Boolean LookNextToken = true;
        //    if (pageToken.Trim() != "") pageToken = "&pagetoken=" + pageToken;



        //    List<Hotel> outputHotels = new List<Hotel>();
        //    try
        //    {
        //        string url = "https://maps.googleapis.com/maps/api/place/textsearch/xml?query=" + strName + "+in+South+Africa&types=lodging&key=" + APIKey + pageToken;
        //        var request = (HttpWebRequest)HttpWebRequest.Create(url);
        //        HttpWebResponse response = request.GetResponse() as HttpWebResponse;
        //        XDocument doc = XDocument.Load(response.GetResponseStream());

        //        foreach (XElement el in doc.Root.Elements())
        //        {
        //            if (el.Name == "status")
        //            {
        //                if (el.Value == "ZERO_RESULTS")
        //                {

        //                    _LastStatus = "No data found for this Search";
        //                    _LastSearchSuccess = true;
        //                    return outputHotels;
        //                }
        //                else if (el.Value == "OVER_QUERY_LIMIT")
        //                {
        //                    _LastStatus = "Quota for your search is over for today";
        //                    _LastSearchSuccess = false;
        //                    return outputHotels;
        //                }
        //                else if (el.Value != "OK")
        //                {
        //                    _LastStatus = "Invalid Key!";
        //                    _LastSearchSuccess = false;
        //                    return outputHotels;
        //                }
        //                continue;
        //            }

        //            if (el.Name == "result")
        //            {
        //                Hotel newHotel = new Hotel();
        //                foreach (XElement result in el.Elements())
        //                {
        //                    if (result.Name == "name")
        //                    {

        //                        newHotel.Name = result.Value;
        //                    }
        //                    else if (result.Name == "formatted_address")
        //                    {
        //                        newHotel.Address = result.Value;
        //                    }
        //                    else if (result.Name == "geometry")
        //                    {

        //                        foreach (XElement location in result.Elements())
        //                        {
        //                            foreach (XElement latlang in location.Elements())
        //                            {
        //                                if (latlang.Name == "lat")
        //                                {
        //                                    newHotel.Location.Latitude = Convert.ToDouble(latlang.Value);
        //                                }
        //                                else if (latlang.Name == "lng")
        //                                {
        //                                    newHotel.Location.Longitude = Convert.ToDouble(latlang.Value);
        //                                }
        //                            }

        //                        }

        //                    }
        //                    else if (result.Name == "place_id")
        //                    {
        //                        newHotel.Place_Id = result.Value;
        //                    }

        //                }
        //                if (newHotel.Name.ToUpper().IndexOf(strName.ToUpper()) != -1)
        //                {
        //                    outputHotels.Add(newHotel);
        //                }
        //                else
        //                {
        //                    LookNextToken = false;
        //                }
        //                continue;
        //            }
        //            if (el.Name == "next_page_token")
        //            {
        //                if (LookNextToken == true)
        //                {
        //                    outputHotels.AddRange(searchHotels(strName, el.Value));
        //                }
        //            }

        //        }

        //        return outputHotels;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}
    }
}
