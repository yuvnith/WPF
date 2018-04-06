using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfPractise
{
    /// <summary>
    /// Interaction logic for TreeViewBinding.xaml
    /// </summary>
    public partial class TreeViewBinding : Window
    {
        public ObservableCollection<Continent> Continents { get; set; }
        public TreeViewBinding()
        {
            InitializeComponent();
            Continents = CreateWorld();
            this.DataContext = Continents;
        }

       
        private ObservableCollection<Continent> CreateWorld()
        {
            ObservableCollection<Continent> world = new ObservableCollection<Continent>();

            Continent northAmerica = new Continent()
            {
                Name = "North America",
                Size = 9540000,
                Countries = new ObservableCollection<Country>()
                {
                    new Country()
                    {
                        Name = "Canada",
                        Population = 15000000,
                        Cities = new ObservableCollection<City>()
                        {
                            new City() { Name = "Ottowa", Population = 812179 },
                            new City() { Name = "Vancouver", Population = 347009 },
                            new City() { Name = "Quebec", Population = 457339 }
                        }
                    },
                    new Country()
                    {
                        Name = "United States",
                        Population = 3456700,
                        Cities = new ObservableCollection<City>()
                        {
                            new City() { Name = "Denver", Population = 124897 },
                            new City() { Name = "Boston", Population = 234659 },
                            new City() { Name = "New York", Population = 354730 },
                            new City() { Name = "Los Angeles", Population = 423100 }
                        }
                    },
                    new Country()
                    {
                        Name = "Mexico",
                        Population = 34000234,
                        Cities = new ObservableCollection<City>()
                        {
                            new City() { Name = "Mexico City", Population = 21000000 },
                            new City() { Name = "Tijuana", Population = 1594000 },
                            new City() { Name = "Puebla", Population = 1590256 }
                        }
                    }
                }
            };

            Continent southAmerica = new Continent()
            {
                Name = "South America",
                Size = 6879000,
                Countries = new ObservableCollection<Country>()
                {
                    new Country()
                    {
                        Name = "Brazil",
                        Population = 4210000,
                        Cities = new ObservableCollection<City>()
                        {
                            new City() { Name = "Sao Paulo", Population = 11500000 },
                            new City() { Name = "Rio de Janeiro", Population = 7186000 },
                            new City() { Name = "Fortaleza", Population = 2505054 }
                        }
                    },
                    new Country()
                    {
                        Name = "Argentina",
                        Population = 5673420,
                        Cities = new ObservableCollection<City>()
                        {
                            new City() { Name = "Buenos Aires", Population = 5698000 },
                            new City() { Name = "Chaco", Population = 7845000 }
                        }
                    }
                }
            };

            world.Add(northAmerica);
            world.Add(southAmerica);
            return world;
        }
    }

    public class Continent
    {
        public Continent() { }

        public string Name { get; set; }
        public int Size { get; set; }  //in sq miles
        public ObservableCollection<Country> Countries { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }

    public class Country
    {
        public Country() { }

        public string Name { get; set; }
        public int Population { get; set; }
        public ObservableCollection<City> Cities { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }

    public class City
    {
        public City() { }

        public string Name { get; set; }
        public int Population { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}

