using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapsTest.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MapsTest
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {

        private ObservableCollection<Item> _items = new ObservableCollection<Item>();
        public ObservableCollection<Item> Items
        {
            get => _items;
            set => _items = value;
        }

        private Item currentItem;





        public MainPage()
        {
            InitializeComponent();

            PopulateData();

            var pin = new Pin
            {
                Type = PinType.Place,
                Position = new Position(40.192847, -8.414153),
                Label = "LIS",
                Address = "Morada LIS"
            };

            var pin2 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(40.191331, -8.415784),
                Label = "LIS2",
                Address = "Morada LIS2"
            };

            var pin3 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(40.193109, -8.416117),
                Label = "LIS3",
                Address = "Morada LIS2"
            };

            var pin4 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(40.194338, -8.411257),
                Label = "LIS4",
                Address = "Morada LIS2"
            };



            MyMap.Pins.Add(pin);
            MyMap.Pins.Add(pin2);
            MyMap.Pins.Add(pin3);
            MyMap.Pins.Add(pin4);
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                  new Position(40.192993, -8.414710),
                  Distance.FromMiles(0.5)));

            myListView.ItemsSource = Items;

            myListView.ItemTapped += async (sender, e) =>
            {

                var content = e.Item as Item;

                currentItem = content;

                var height = detailsFrame.Height;

                detailsFrame.TranslateTo(0, this.Height - height, 300, Easing.SinInOut);

                //frameListView.IsVisible = false;


                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                 new Position(content.Position.Latitude, content.Position.Longitude),
                 Distance.FromMiles(0.1)));


                frameLabel.Text = content.Name;
                imagePlace.Source = content.ImageUrl;
            };

        }

        void PopulateData()
        {
            Items.Add(new Item
            {
                Id = "1",
                Name = "Local 1",
                ImageUrl = "https://www.dinheirovivo.pt/wp-content/uploads/2016/02/IPN-1060x594.jpg",
                Position = new Position(40.192847, -8.414153),

            });

            Items.Add(new Item
            {
                Id = "2",
                Name = "Local 2",
                ImageUrl = "https://www.dinheirovivo.pt/wp-content/uploads/2016/02/IPN-1060x594.jpg",
                Position = new Position(40.191331, -8.415784),
            });

            Items.Add(new Item
            {
                Id = "3",
                Name = "Local 3",
                ImageUrl = "https://www.dinheirovivo.pt/wp-content/uploads/2016/02/IPN-1060x594.jpg",
                Position = new Position(40.193109, -8.416117),
            });

            Items.Add(new Item
            {
                Id = "4",
                Name = "Local 4",
                ImageUrl = "https://www.dinheirovivo.pt/wp-content/uploads/2016/02/IPN-1060x594.jpg",
                Position = new Position(40.194338, -8.411257),
            });
        }


        void Handle_Tapped(object sender, EventArgs args)
        {
            //frameListView.IsVisible = true;
            detailsFrame.TranslateTo(0, Height, 300, Easing.SinInOut);


        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            
            var options = new MapLaunchOptions { Name = currentItem.Name, NavigationMode = NavigationMode.Driving };
            
            await Xamarin.Essentials.Map.OpenAsync(
                new Location(currentItem.Position.Latitude, currentItem.Position.Longitude), options);
        }

    }
}
