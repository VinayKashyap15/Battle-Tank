namespace SaveFile
{
    public interface ISaveData
    {
        void SaveInt(string _dataToSave, int id, int value);

        int GetInt(string _dataToSave, int id);

        void SaveFloat(string _dataToSave, int id, float value);

        float GetFloat(string _dataToSave, int id);

        void SaveString(string _dataToSave, int id, string value);

        string GetString(string _dataToSave, int id);

        void SaveBool(string _dataToSave, int id, bool value);

        bool GetBool(string _dataToSave, int id);
        
    }
}