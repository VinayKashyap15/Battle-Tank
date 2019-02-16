using System;
using UnityEngine;

namespace CameraManagement
{    
    public class MiniMapSetup: MonoBehaviour
    {
        private Transform followTarget;
        
        private void LateUpdate() {
            if(followTarget!=null)
            {
                transform.localPosition= new Vector3(followTarget.transform.localPosition.x, transform.localPosition.y,followTarget.transform.localPosition.z);
            }
        }

        public void SetupTarget(Transform _followTarget)
        {
            followTarget=_followTarget;

            transform.localPosition= new Vector3(followTarget.transform.localPosition.x, transform.localPosition.y,followTarget.transform.localPosition.z);
        }

        public void SetRenderTexture(int _id)
        {
            this.GetComponent<Camera>().targetTexture= Resources.Load("Player"+(_id+1).ToString())as RenderTexture;
        }
    }
}