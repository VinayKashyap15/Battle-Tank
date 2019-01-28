using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerView :MonoBehaviour
{
   
    private GameObject cam;

    private void Start()
    {
        DisplayPlayerStats();
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public IEnumerator MovePlayer(float h,float v)
    {
        transform.Translate(new Vector3( h,0, v));
        yield return null;
    }
    public IEnumerator RotatePlayer(float pitch)
    {
        transform.Rotate(new Vector3(0, pitch, 0));
        yield return null;
    }

    public void DisplayFireMessage(string message)
    {
        Debug.Log(message);
    }

    public void DisplayPlayerStats()
    {
        PlayerModel model = new PlayerModel();
        int id = model.GetID();
        string name = model.GetName();

        Debug.Log("Player Name:" + name + "Player ID:" + id.ToString());
    }

    public void OnFirePressed()
    {
        //fire
        DisplayFireMessage("Fire Button Pressed");
    }

}