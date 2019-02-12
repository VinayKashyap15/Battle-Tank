using UnityEngine;
using GameplayInterfaces;
using Common;
using System;

namespace Player
{
    public class PlayerView : MonoBehaviour, ITakeDamage
    {

        [SerializeField]
        private GameObject muzzlePoint;
        public bool isFriendlyFire;

        private PlayerController currentPlayerController;
        private Rigidbody bulletRb;
        private Animator anim;

        private void Awake()
        {
            anim = gameObject.GetComponentInChildren<Animator>();
            
        }
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

        public int UpdateMyScore(int _currentScore, int _points)
        {
            _currentScore += _points;
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
            if (collision.collider.GetComponent<Enemy.EnemyView>())
            {
                TakeDamage(25);
            }
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
            
            PlayerService.Instance.InvokePlayerDeath(currentPlayerController.GetID(),currentPlayerController.GetNoOfDeaths());
           //gameObject.transform.position = PlayerService.Instance.GetRespawnSafePosition();
           

        }

        public string GetName()
        {
            return "PlayerView";
        }

        public Animator GetAnimator()
        {
            return anim;
        }

        public void SetMaterial(Material mat)
        {
            gameObject.GetComponentInChildren<Renderer>().sharedMaterial= mat;
        }
    }
}