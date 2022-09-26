using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static string directory = "/SavedData/";
    public static string fName = "SavedData.txt";

    public static void Save(SaveObject saveObj)
    {
        string dir = Application.persistentDataPath + directory;
        if(!Directory.Exists(dir))
            Directory.CreateDirectory(dir);
        string json=JsonUtility.ToJson(saveObj);
        File.WriteAllText(dir+fName, json);   
    }

    public static SaveObject Load()
    {
        string path=Application.persistentDataPath + directory +fName; 
        SaveObject saveObj = new SaveObject();

        if (File.Exists(path))
        {
            string json=File.ReadAllText(path);
            saveObj=JsonUtility.FromJson<SaveObject>(json);
        }
        else
        {
            Debug.Log("File does not exist");
        }
        return saveObj;
    }

}
