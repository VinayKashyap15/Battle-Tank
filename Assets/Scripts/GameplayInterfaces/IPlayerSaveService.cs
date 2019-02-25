using System.Collections;
using AchievementSystem;
using UnityEngine;

namespace GameplayInterfaces
{
    public interface IPlayerSaveService:IService
    {
        void SetInt(string _dataToSave, int _id, int _value);
        int GetInt(string _dataToSave, int _id);
        AchievementStatus GetAchievementStatus(AchievementTypes _type, int id);
        void SetAchievementStatus(AchievementTypes _type, int id, int statusInt);
        void SetHighScoreData(int v, int newScore);
        int GetHighScoreData(int v);
        int GetEnemyKillData(int v);
        int GetGamesPlayedData(int v);
        void SetGamesPlayedData(int id, int v);
    }
}