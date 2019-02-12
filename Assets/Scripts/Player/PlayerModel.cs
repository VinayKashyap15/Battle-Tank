using System;

namespace Player
{
    public class PlayerModel
    {

        public int playerID;
        private string playerName;
        private float playerSpeed;
        private float bulletSpeed;
        private int playerScore;
        private  int health=100;
        private int noOfDeaths;

        public PlayerModel()
        {
            playerID =0 ;
            playerName = "Vinay";
            playerSpeed = 3f;
            bulletSpeed = 6f;
            noOfDeaths=5;
            
        }
        public int GetID()
        {
            return playerID;
        }
        public string GetName()
        {
            return playerName;
        }
        public float GetSpeed()
        {
            return playerSpeed;
        }
        public float GetBulletSpeed()
        {
            return bulletSpeed;
        }
        public void SetID(int ID)
        {
            playerID = ID;
        }
        public int GetCurrentScore()
        {
            return playerScore;
        }
        public void SetCurrentScore(int _newScore)
        {
           playerScore=_newScore;
        }
        public int GetHealth()
        {
            return health;
        }
        public void SetHealth(int _newHealth)
        {
            health=_newHealth;
        }
        public int GetDeaths()
        {
            return noOfDeaths;
        }
    }
}