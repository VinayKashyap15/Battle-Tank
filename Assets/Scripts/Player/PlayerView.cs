using UnityEngine;

namespace Player
{
    public class PlayerView : MonoBehaviour
    {

        [SerializeField]
        private GameObject muzzlePoint;
        private PlayerController currentPlayerController;
        private Rigidbody bulletRb;

        public void MovePlayer(float h, float v, float speed)
        {
            transform.Translate(new Vector3(h * speed * Time.deltaTime, 0, v * speed * Time.deltaTime));
        }
        public void RotatePlayer(float pitch)
        {
            transform.Rotate(new Vector3(0, pitch, 0));
        }
        public void OnFirePressed()
        {
            Debug.Log("Fire Button Pressed");
        }
        public int UpdateMyScore(int _currentScore)
        {
            _currentScore += 10;
            Debug.Log("Score :" + _currentScore.ToString());
            return _currentScore;
        }
        public Vector3 GetMuzzlePosition()
        {
            return muzzlePoint.transform.position;
        }
        public Quaternion GetMuzzleRotation()
        {
            return muzzlePoint.transform.rotation;
        }
        public Vector3 GetMuzzleDirection()
        {
            return muzzlePoint.transform.forward;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.collider.CompareTag("Enemy"))
            {
                PlayerService.Instance.DestroyPlayer(currentPlayerController);
                Destroy(this.gameObject);
            }
        }

        public void SetPlayerController(PlayerController _currentPlayerController)
        {
            currentPlayerController = _currentPlayerController;
        }

    }
}