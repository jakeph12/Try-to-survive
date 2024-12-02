using System;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace JakePhLib
{
    public class SaveAndLoad<Obg> where Obg : class, new()
    {
        public static void SaveData(Obg SaveData, string NameSave, string Paths = null)
        {
            if (Paths == null || Paths == "") Paths = Application.persistentDataPath;
            if (!Directory.Exists(Paths)) Directory.CreateDirectory(Paths);
            Paths += $"/{NameSave}.data";
            BinaryFormatter Bf = new BinaryFormatter();
            FileStream Files = File.Create(Paths);
            Bf.Serialize(Files, SaveData);
            Files.Close();
        }
        public static void LoadData(out Obg LoadData,string NameSave, string Paths = null)
        {
            if (Paths == null || Paths == "") Paths = Application.persistentDataPath;
            Paths += $"/{NameSave}.data";
            LoadData = null;
            if (File.Exists(Paths))
            {
                BinaryFormatter Bf = new BinaryFormatter();
                FileStream Files = File.OpenRead(Paths);
                Obg ReturnedData = (Obg)Bf.Deserialize(Files);
                Files.Close();
                LoadData = ReturnedData;
            }

        }
        public static void DeleteSave(string NameSave, string Paths = null)
        {
            if (Paths == null || Paths == "") Paths = Application.persistentDataPath;
            if (Directory.Exists(Paths))
            {
                string Fileph = Paths + $"/{NameSave}.data";
                if (File.Exists(Fileph))
                {
                    File.Delete(Fileph);
                }
            }
        }
        public static bool CheckSave(string NameSave, string Paths = null)
        {
            var pathf = (Paths == null  || Paths == "" )? Application.persistentDataPath : Paths;
            if (!Directory.Exists(pathf)) return false; 
            pathf += $"/{NameSave}.data";
            if (!File.Exists(pathf)) return false;
            return true;
        }
    }
}