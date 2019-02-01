using Common;
using Player;

namespace InputComponents
{
    public class InputManagerBase : SingletonBase<InputManagerBase>
    {     
        
        private void Update()
        {
            foreach (var _currentPlayerController in PlayerService.Instance.listOfPlayerControllers)
            {
                _currentPlayerController.GetInputComponent().OnUpdate();
            }
        }

       
    }
}
