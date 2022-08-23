using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem 
{
    public static void Save(Items item)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/items.s";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(item); 

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData Load()
    {
        string path = Application.persistentDataPath + "/items.s";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
          Debug.LogError("Save file not found in " + path);  
          return null;
        }
    }

}
