using UnityEngine;
using System;


namespace SaveFile
{
    public class SaveInPlayerPrefs : ISaveData
    {
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