using UnityEngine;
using GameplayInterfaces;
using ServiceLocator;
using System.Collections.Generic;
using System.Collections;
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
        private Camera mainCam;

        private void Awake()
        {
            anim = gameObject.GetComponentInChildren<Animator>();
            mainCam= gameObject.GetComponentInChildren<Camera>();

        }
        public void MovePlayer(float h, float v, float speed)
        {
            transform.Translate(new Vector3(h * speed * Time.deltaTime, 0, v * speed * Time.deltaTime));
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

        public void 
        TakeDamage(int _damage)
        {
            if(currentPlayerController != null)
            {
                currentPlayerController.TakeDamage(_damage);
            }
        }

        public IEnumerator DestroySelf()
        {
           GameApplication.Instance.GetService<IPlayerService>().InvokePlayerDeath(currentPlayerController.GetID(), currentPlayerController.GetNoOfDeaths());
           GameApplication.Instance.GetService<IPlayerService>().DestroyPlayer(currentPlayerController);
            yield return new WaitForSeconds(5f);

        }
        public PlayerController GetPlayerController()
        {
            return currentPlayerController;
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
            gameObject.GetComponentInChildren<Renderer>().sharedMaterial = mat;
        }

        public void DestroyView()
        {
           mainCam.transform.parent=null;
           Destroy(mainCam.gameObject);
            Destroy(this.gameObject);
        }

        public Camera GetCamera()
        {
            return mainCam; 
        }
        public void RotatePlayer(float pitch)
        {
            transform.Rotate(new Vector3(0, pitch, 0));
        }
    }
}