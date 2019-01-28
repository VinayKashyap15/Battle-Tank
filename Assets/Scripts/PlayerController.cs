using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    PlayerView view= new PlayerView();

    public Coroutine Move(float h, float v)
    {
        var viewCoroutine = view.StartCoroutine(view.MovePlayer(h,v));
        return viewCoroutine;
    }

    public void Fire()
    {
        view.OnFirePressed();
    }

    public void Stop(Coroutine coroutine)
    {
        view.StopCoroutine(coroutine);
    }
}