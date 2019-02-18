using GameplayInterfaces;
using UnityEngine;

namespace ServiceLocator
{
    public class TestService: IPlayerService
    {
        public TestService()
        {
            Debug.Log("Test Service created");
        }
    }
}