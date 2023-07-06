using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class dataPersister : MonoBehaviour
{

    [System.Serializable]
    public class PlayerData
    {
        public string Name;
        public int Score;
    }

    public static dataPersister Instance;

    public string pName;
    public int bestScore;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public bool getName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            PlayerData playerData = new PlayerData();
            string json;
            json = File.ReadAllText(path);
            playerData = JsonUtility.FromJson<PlayerData>(json);
            dataPersister.Instance.bestScore = playerData.Score;
            dataPersister.Instance.pName = playerData.Name;
            return true;
        }
        else
        {
            Debug.Log("datapath doesn't exist");
            return false;
        }
    }

    public void writeName(GameObject nameInput)
    {
        //getting name from the input field and converting it to json and writing it to savefile
        PlayerData playerData = new PlayerData();
        string name = nameInput.GetComponent<TMPro.TMP_InputField>().text;
        playerData.Name = name;
        playerData.Score = bestScore;
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", JsonUtility.ToJson(playerData));
    }
}
