using UnityEngine;
using Interfaces;
using System;

namespace Player
{
    public class PlayerView : MonoBehaviour,ITakeDamage
    {

        [SerializeField]
        private GameObject muzzlePoint;
        public bool isFriendlyFire;
        
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
          
         
        }

        public void SetPlayerController(PlayerController _currentPlayerController)
        {
            currentPlayerController = _currentPlayerController;
        }

        public void TakeDamage(int _damage)
        {
            currentPlayerController.TakeDamage(_damage);
        }

        public void DestoySelf()
        {
           gameObject.transform.position= PlayerService.Instance.Respawn();
        }
    }
}