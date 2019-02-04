using UnityEngine;

namespace Enemy
{
    [CreateAssetMenu(fileName ="NewEnemyObject",menuName ="Custom Objects/Enemy/Enemy Object",order =0)]
   public class EnemyScriptableObject: ScriptableObject
    {
        public float enemySpeed;
        public Material enemyMaterial;
        public GameObject enemyPrefab;
        public EnemyView enemyView;
        public int enemyHealth;
        public Vector3 pos;

        
    }
}
