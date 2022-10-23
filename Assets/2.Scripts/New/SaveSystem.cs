using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
 
    public static void SavePlayerHealth (GlobalHealth currentHealth)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/health.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        //PlayerData data = new PlayerData(currentHealth);
    }

}
