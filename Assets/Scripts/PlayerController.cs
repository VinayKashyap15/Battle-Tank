using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    PlayerView view;
    PlayerModel model = new PlayerModel();
    public PlayerController(PlayerView playerViewInstance)
    {
        view = playerViewInstance;

    }
    public void Move(float h, float v)
    {
        view.StartCoroutine(view.MovePlayer(h,v,model.GetSpeed()));
    }

    public void Fire()
    {
        view.OnFirePressed(model.GetBulletSpeed());
    }
    public void RotateCamera(float pitch)
    {
        view.StartCoroutine(view.RotatePlayer(pitch));
    }

}