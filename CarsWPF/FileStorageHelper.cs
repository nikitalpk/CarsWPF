using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace CarsWPF
{
    public static class FileStorageHelper
    {
        public static readonly string CarFilePath = "cars.json";
        public static readonly string ClientFilePath = "clients.json";
        public static readonly string InspectionFilePath = "inspections.json";
        public static readonly string RentFilePath = "rents.json";
        public static readonly string ReservationFilePath = "reservations.json";

        public static void SaveToFile<T>(List<T> items, string filePath)
        {
            var jsonString = JsonConvert.SerializeObject(items, Formatting.Indented);
            File.WriteAllText(filePath, jsonString);
        }

        public static List<T> LoadFromFile<T>(string filePath)
        {
            var jsonString = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(jsonString);
        }
    }
}
