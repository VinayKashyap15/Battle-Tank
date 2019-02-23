
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;


namespace SaveFile
{

    [System.Serializable]
    public class PlayerData
    {
        public int playerID;
        public int highscore;
        public int enemyKills;
        public int playerDeaths;
        public int gamesJoined;
        public int rewardID;


    }

    [System.Serializable]
    public class Data
    {
        public List<PlayerData> Players;
        public Data()
        { Players = new List<PlayerData>(); }
    }

    public class SaveInEncodedFile : ISaveData
    {
        private Data _data = new Data();
        private string path = Application.streamingAssetsPath + "/Data.json";
        private string jsonString;
        public SaveInEncodedFile()
        {
            LoadJSonFile();
        }

        private void LoadJSonFile()
        {
            jsonString = File.ReadAllText(path);

            if (jsonString.Length == 0)
            {
                CreateNewFile();
                jsonString = File.ReadAllText(path);
            }

            Debug.Log(jsonString);

            _data = JsonUtility.FromJson<Data>(jsonString);

        }

        private void CreateNewFile()
        {
            PlayerData newPlayerData = new PlayerData();

            newPlayerData.enemyKills = 0;
            newPlayerData.gamesJoined = 0;
            newPlayerData.highscore = 0;
            newPlayerData.playerDeaths = 0;
            newPlayerData.rewardID = 0;
            newPlayerData.playerID = 0;

            _data.Players.Add(newPlayerData);
            File.WriteAllText(path, JsonUtility.ToJson(_data));
        }
        public bool GetBool(string _dataToSave, int id)
        {
            //throw new System.NotImplementedException();
            return false;
        }

        public float GetFloat(string _dataToSave, int id)
        {
            //throw new System.NotImplementedException();
            return -1;
        }

        public int GetInt(string _dataToSave, int id)
        {
            //throw new System.NotImplementedException();
            return PlayerPrefs.GetInt(_dataToSave + id.ToString());
        }

        public string GetString(string _dataToSave, int id)
        {
            //throw new System.NotImplementedException();
            return "";
        }

        public void SaveInt(string _dataToSave, int id, int value)
        {
            PlayerPrefs.SetInt(_dataToSave + id.ToString(), value);
        }
        public void SaveBool(string _dataToSave, int id, bool value)
        {
            //throw new System.NotImplementedException();
        }

        public void SaveFloat(string _dataToSave, int id, float value)
        {
            //throw new System.NotImplementedException();
        }

        public void SaveString(string _dataToSave, int id, string value)
        {
            //throw new System.NotImplementedException();
        }
    }
}
