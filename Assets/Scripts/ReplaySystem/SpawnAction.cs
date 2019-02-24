using UnityEngine;
using Player;
using ServiceLocator;

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
           GameApplication.Instance.GetService<IPlayerService>().SetSpawnPos(position);
        }
    }
}