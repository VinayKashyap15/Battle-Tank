using UnityEngine;

namespace GameplayInterfaces
{
    public interface ICharacterController
    {
       
        void SetFireState(bool isFiring);
        void PlayerIdle();
        void Fire();
        void Move(float h, float v);
        void Rotate(float pitch);
        
    }
}
