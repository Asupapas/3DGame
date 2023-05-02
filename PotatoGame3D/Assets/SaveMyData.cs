using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;

public class SaveMyData : MonoBehaviour
{
    // game data to be saved
    public SaveData gameData;
    //file to write to
    string saveFile;
    //the file we want to open
    FileStream dataStream;
    //the format we use to write out to the file
    BinaryFormatter converter = new BinaryFormatter();
    CharacterController cc;

    void Awake()
    {
        //"/gamedata.data" is able to be changed
        saveFile = Application.persistentDataPath + "gamedata.data" + gameObject.name + "gamedata.data";
        gameData = new SaveData();
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            gameData.x = transform.position.x;
            gameData.y = transform.position.y;
            gameData.z = transform.position.z;
            SaveFile();
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            LoadFIle();
            cc.enabled = false;
            Vector3 pos = new Vector3(gameData.x, gameData.y, gameData.z);
            transform.position = pos;
            cc.enabled = true;
        }
    }

    public void SaveFile()
    {
        // create filestream to the save file path
        dataStream = new FileStream(saveFile, FileMode.Create);
        //serialize (save) data into the file
        converter.Serialize(dataStream, gameData);
        //CLOSE THE FILE
        dataStream.Close();
    }

    public void LoadFIle()
    {
        //check if the file exists
        if(File.Exists(saveFile))
        {
            //open the filestream
            dataStream = new FileStream(saveFile, FileMode.Open);
            //deserialize (unsave) the game data
            gameData = converter.Deserialize(dataStream) as SaveData;
            //CLOSE THE FILE
            dataStream.Close();
        }
    }
}

[System.Serializable]
public class SaveData 
{
    public float x;
    public float y;
    public float z;
}
