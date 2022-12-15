using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.IO;

namespace Fluke_Final_Q6
{
    public class DataManage
    {
        private DataManage() { }

        private static DataManage instance = new DataManage();

        public static DataManage GetInstance()
        {
            return instance;
        }

        public Settings LoadData(string path = "c:/temp/player.json")
        {
            StreamReader reader = new StreamReader(path);
            string data = reader.ReadToEnd();
            reader.Close();
            return JsonConvert.DeserializeObject<Settings>(data);
        }

        public void SaveData(Settings obj, string path = "c:/temp/player.json") // Was going to save to just c:/ but I without admin I don't think it works
        {
            string data = JsonConvert.SerializeObject(obj);
            StreamWriter writer = new StreamWriter(path);
            writer.Write(data);
            writer.Close();
        }

    }
    public class Settings
    {
        public string player_name;
        public int level;
        public int hp;
        public string[] inventory;
        public string liscense_key;

        public Settings()
        {
            this.player_name = "dschuh";
            this.level = 4;
            this.hp = 99;
            this.inventory = new string[]
            {
                "spear",
                "water bottle",
                "hammer",
                "sonic screwdriver",
                "cannonball",
                "wood",
                "Scooby snack",
                "Hydra",
                "poisonous potato",
                "dead bush",
                "repair powder"
            };
            this.liscense_key = "DFGU99-1454";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Settings player = new Settings();
            DataManage myManager = DataManage.GetInstance();
            myManager.SaveData(player);

            Settings loadedSettings = myManager.LoadData();
            if (loadedSettings != null)
            {
                Console.WriteLine("Data loaded!");
            }
        }
    }
}