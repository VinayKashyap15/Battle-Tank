using UnityEngine;
using Player;
using GameplayInterfaces;

namespace InputComponents
{
    public class SpawnAction:InputActions
    {
        Vector3  position;
        public SpawnAction(Vector3 _position)
        {
            position=_position;
        }        
        public void Execute()
        {
            PlayerService.Instance.SetSpawnPos(position);
        }
    }
}