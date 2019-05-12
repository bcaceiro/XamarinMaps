using System;
using Xamarin.Forms.Maps;

namespace MapsTest.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public Position Position { get; set; }
    }
}
