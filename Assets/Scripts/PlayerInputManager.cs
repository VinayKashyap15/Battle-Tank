using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInputManager : MonoBehaviour
{

    public PlayerModel model = new PlayerModel();
    public PlayerController controller = new PlayerController();
    public PlayerView view = new PlayerView();
    Coroutine viewCo;

    bool isMoving = false;

    void Update()
    {
        float h = Input.GetAxis("Horizontal1");
        float v = Input.GetAxis("Vertical1");

        if (h > 0 || v > 0)
            isMoving = true;
        else
            isMoving = false;

        if (isMoving)
        {
             viewCo = controller.Move(h,v);
        }
        else { controller.Stop(viewCo); }

        if (Input.GetMouseButtonDown(0))
        {
            controller.Fire();
        }
        if (Input.GetAxis("Mouse X"))
        {
            float pitch = Input.GetAxis("Mouse X");
        }
    }
}
