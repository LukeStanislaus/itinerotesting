using Itinero;
using Itinero.IO.Osm;
using Itinero.LocalGeo;
using Itinero.Osm.Vehicles;
using System;
using System.Collections.Generic;
using System.IO;

namespace itinerotesting
{
    class Program
    {
        public static List<Coordinate> coordlist = new List<Coordinate>();
        static void Main(string[] args)
        {

            // load some routing data and build a routing network.
            var routerDb = new RouterDb();

            using (var stream = new FileInfo(@"C:\Users\Luke\Downloads\downloads\saint-helena-ascension-and-tristan-da-cunha-latest.osm.pbf").OpenRead())
            {
                // create the network for cars only.
                routerDb.LoadOsmData(stream, Vehicle.Car);
            }
            routerDb.area
            Router router = new Router(routerDb);
            // get a profile.
            var profile = Vehicle.Car.Fastest(); // the default OSM car profile.


            var start = router.Resolve(profile, -15.9244f, -5.718f);
            var end = router.Resolve(profile, -15.9245f, -5.719f);
            var route = router.Calculate(profile, start, end);
            Console.WriteLine(route.ToGeoJson());
            Console.ReadLine();
        }
    }
}
