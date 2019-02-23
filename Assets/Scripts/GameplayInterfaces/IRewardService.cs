using RewardSystem;

namespace GameplayInterfaces
{
    public interface IRewardService : IService
    {
        void OnRewardUnlocked(int _id, RewardUnlockType _type);
        RewardScriptableObject GetListOfRewards();
    }
}