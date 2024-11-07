
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Save_system
{
    public static void savePlayer (Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.nerd";
        FileStream stream = new FileStream(path, FileMode.Create);

        Player_data data = new Player_data(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Player_data LoadPlayer ()
    {
        string path = Application.persistentDataPath + "/player.nerd";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Player_data data = formatter.Deserialize(stream) as Player_data;
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

