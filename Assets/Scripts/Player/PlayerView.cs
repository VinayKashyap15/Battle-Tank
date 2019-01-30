using UnityEngine;

public class PlayerView : MonoBehaviour
{

    [SerializeField]
    private GameObject muzzlePoint;

    private Rigidbody bulletRb;

    private void Start()
    {
        //do smomething
    }

    public void MovePlayer(float h, float v, float speed)
    {
        transform.Translate(new Vector3(h * speed * Time.deltaTime, 0, v * speed * Time.deltaTime));

    }

    public void RotatePlayer(float pitch)
    {
        transform.Rotate(new Vector3(0, pitch, 0));
    }

    public void OnFirePressed(BulletController _bulletController, float _bulletSpeed)
    {
        //fire
        GameObject _bullet = _bulletController.GetBullet();
        _bullet.transform.position = muzzlePoint.transform.position;
        _bullet.transform.rotation = muzzlePoint.transform.rotation;
        _bullet.GetComponent<Rigidbody>().velocity = muzzlePoint.transform.forward * _bulletSpeed;

        Debug.Log("Fire Button Pressed");
    }

}