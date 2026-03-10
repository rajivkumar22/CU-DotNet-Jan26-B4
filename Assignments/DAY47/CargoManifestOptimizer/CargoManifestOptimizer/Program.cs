using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CargoManifestOptimizer
{
    public class Item
    {

        public string Name { get; set; }
        public double Weight { get; set; }
        public string Category { get; set; }
        public Item(string name, double weight, string category)
        {
            Name = name;
            Weight = weight;
            Category = category;
        }

    }
    public class Container
    {
        public string ContainerID { get; set; }
        public List<Item> Items = new List<Item>();


        public Container(string ID, List<Item> items)
        {
            ContainerID = ID;
            Items = items;
        }

    }
    public class Cargo
    {
        
        List<List<Container>> CargoBay = new List<List<Container>>();
        public Cargo(List<List<Container>> cargoBay)
        {
            CargoBay = cargoBay;
        }
        public List<string> FindHeavyContainers(double weightThreshold)
        {
            //List<string> ContainersID = new List<string>();
            //foreach (var row in CargoBay)
            //{
            //    if (row == null) continue;
            //    foreach (var container in row)
            //    {
            //        if (container.Items == null) continue;
            //        double totalweight = container.Items.Sum(s => s.Weight);


            //        if (totalweight > weightThreshold)
            //        {
            //            ContainersID.Add(container.ContainerID);
            //        }
            //    }
            //}
            //return ContainersID;

            return CargoBay
                .Where(row => row != null)
                .SelectMany(row => row)
                .Where(container => container != null)
                .Where(c => c.Items.Sum(i => i.Weight) > weightThreshold)
                .Select(c => c.ContainerID)
                .ToList();

        }
        public Dictionary<string, int> GetCountsByCategory()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            //foreach (var row in CargoBay)
            //{
            //    foreach (var container in row)
            //    {

            //        foreach (var item in container.Items)
            //        {
            //            if (!dict.ContainsKey(item.Category))
            //            {
            //                dict[item.Category] = 1;
            //            }
            //            else
            //            
            //                dict[item.Category]++;
            //            }

            //        }

            //    }
            //}
            //return dict;
            return CargoBay
                .Where(row => row != null)
                .SelectMany(row => row)
                .Where(container => container.Items != null)
                .SelectMany(container => container.Items)
                .GroupBy(item => item.Category)
                .ToDictionary(key => key.Key, value => value.Count());

        }
        public List<Item> FlattenAndSortShipment()
        {
            return CargoBay
                .Where(row => row != null)
                .SelectMany(row => row)
                .Where(container => container != null)
                .SelectMany(container => container.Items)
                .GroupBy(items => items.Name)
                .Select(items => items.First())
                .OrderBy(item => item.Category)
                .ThenByDescending(item => item.Weight)
                .ToList();

        }

    }



    internal class Program
    {



        static void Main(string[] args)
        {
            var CargoBay = new List<List<Container>>
            {
                new List<Container>
                {
                    new Container("C001", new List<Item>
                    {
                        new Item("Laptop", 2.5, "Tech"),
                        new Item("Monitor", 5.0, "Tech"),
                        new Item("Smartphone", 0.5, "Tech")

                    }),
                    new Container("C104", new List<Item>
                    {
                        new Item("Server Rack", 45.0, "Tech"),
                        new Item("Cables", 1.2, "Tech")
                    })
                },
                    new List<Container>
    {
        new Container("C002", new List<Item>
        {
            new Item("Apple", 0.2, "Food"),
            new Item("Banana", 0.2, "Food"),
            new Item("Milk", 1.0, "Food")
        }),
        new Container("C003", new List<Item>
        {
            new Item("Table", 15.0, "Furniture"),
            new Item("Chair", 7.5, "Furniture")
        })
    }

         

            };

            Cargo cargo = new Cargo(CargoBay);

            
            var heavy = cargo.FindHeavyContainers(20);
            foreach (var id in heavy)
                Console.WriteLine(id);
        }
    }
}

