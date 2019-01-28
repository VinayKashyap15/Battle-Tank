public class PlayerModel {

    public int playerID;
    public string playerName;
    public float speed;

    public PlayerModel()
    {
        playerID = 1;
        playerName = "Vinay";
        speed = 5f;
    }
    public int GetID()
    {
        return playerID;
    } 
    public string GetName()
    {
        return playerName;
    }
}