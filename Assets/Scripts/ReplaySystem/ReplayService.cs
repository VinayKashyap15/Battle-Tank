using UnityEngine;
using Common;
namespace ReplaySystem
{
    public class ReplayService: SingletonBase<ReplayService>
    {
        private bool startReplay=false;
        private void Update() {
            if(Input.GetKey(KeyCode.R))
            {
                startReplay=!startReplay;
            }
        }

        public bool GetReplayValue()
        {
            return startReplay;
        }
    }
}