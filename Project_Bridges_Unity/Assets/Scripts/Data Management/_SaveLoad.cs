using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class _SaveLoad
{
    [Header("Controls")]
    public string fileName;
    public string variable;
    public bool saveData;
    public bool loadData;

    public void SaveToFile(string _toWrite)
    {
        Debug.Log("Saving [" + _toWrite + "] to " + fileName + variable + " in " + GetPath("/Saves/" + fileName + ".json"));

        File.WriteAllText(GetPath("/Saves/" + fileName + variable +".json"), _toWrite); //Writes to a new or already existing file "_filename" the JSon data "_toWrite".
        saveData = false;
    }

    public string ReadFromFile()
    {
        Debug.Log("Reading from " + fileName + " from " + GetPath("/Saves/" + fileName + ".json"));

        string jsonText;
        loadData = false;
        return jsonText = File.ReadAllText(GetPath("/Saves/" + fileName + variable + ".json")); //Reads the text in "_fileName" and stores it in the string "jsontext"
    }

    string GetPath(string _addPath) {

        string path = "";

        if (Application.platform == RuntimePlatform.Android) //Android
        {
            //string oriPath = Path.Combine(Application.streamingAssetsPath, _addPath);

            //// Android only use WWW to read file
            //WWW reader = new WWW(oriPath);
            //while (!reader.isDone) { }

            //string realPath = Application.persistentDataPath + fileName;
            //System.IO.File.WriteAllBytes(realPath, reader.bytes);

            //path = realPath;

            //////

            //string jsonString = Resources.Load<string>("Products.json");
            //if (jsonString != null)
            //{
            //    jsonParser data = JsonUtility.FromJson<jsonParser>(jsonString);

            //    data.products.Add(product);
            //    Debug.Log(data.products[1].code);

            //    jsonString = JsonUtility.ToJson(data);
            //    Debug.Log(jsonString);
            //}
            //using (FileStream fs = new FileStream("Products.json", FileMode.Create))
            //{
            //    using (StreamWriter writer = new StreamWriter(fs))
            //    {
            //        writer.Write(jsonString);
            //    }
            //}
            //UnityEditor.AssetDatabase.Refresh();

        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer) //IOS
        {
            path = Application.dataPath + "/Raw";
        }
        else { //Windows & Mac
            path = Application.dataPath + "/Resources"+ _addPath;
        }

        return path;
    }
}
