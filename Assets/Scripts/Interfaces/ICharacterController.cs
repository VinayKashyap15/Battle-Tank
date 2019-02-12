using UnityEngine;

namespace GameplayInterfaces
{
    public interface ICharacterController
    {
        void PauseGame();
        void SetFireState(bool isFiring);
        void PlayerIdle();
        void Fire();
        void Move(float h, float v);
        Vector3 GetCurrentLocation();
        void SetNewLocation(Vector3 vector3);
    }
}
