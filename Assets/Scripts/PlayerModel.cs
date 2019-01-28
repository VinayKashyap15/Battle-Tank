public class PlayerModel {

    private int playerID;
    private string playerName;
    private float playerSpeed;
    private float bulletSpeed;

    public PlayerModel()
    {
        playerID = 1;
        playerName = "Vinay";
        playerSpeed = 3f;
        bulletSpeed = 6f;
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
}