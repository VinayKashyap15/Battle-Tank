using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    PlayerView playerView;
    PlayerModel playerModel;

    public PlayerController(PlayerView playerViewInstance)
    {
        playerModel = new PlayerModel();
        playerView = playerViewInstance;
    }
    public void Move(float h, float v)
    {
        playerView.MovePlayer(h,v,playerModel.GetSpeed());
    }

    public void DisplayPlayerStats()
    {
        Debug.Log("ID: "+playerModel.GetID().ToString()+"Player name:"+playerModel.GetName()+"Player Speed:"+playerModel.GetSpeed().ToString());
    }

    public void Fire()
    {
        GameObject _bullet = BulletService.GetBullet();
        float bulletSpeed = BulletService.GetBulletSpeed();
        playerView.OnFirePressed(_bullet,bulletSpeed);
    }

    public void RotatePlayer(float pitch)
    {
        playerView.RotatePlayer(pitch);
    }


}