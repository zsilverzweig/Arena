using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "New Mob", menuName = "Mob Data")]

    public class MonsterDataSO : ScriptableObject
    {
        [Header("The Monster")]
        public string monsterName = "Monster";
        public Sprite sprite;
        public Sprite attackingSprite;
        public Sprite weaponSprite;
    
        [Header("The Monster's Stats")]
        public int experience = 1;
        public int health = 1;
        public int maxHealth = 3;
    
        [Header("Damage and Attack")]
        public float attackDistance = 1f;
        public float attackDuration = .3f;
        public float timeBetweenMovement = 1f;
        public int damage;
        
        [Header("Weapon UI Variables")]
        
        public int rotation = 60;
        public int extension = 3;
        public float xOffset = 0.0f;
        public float yOffset = 0.0f;
        
        [Header("Loot")]
        public Loot loot;
        public float lootDropRate = 0.5f;
    }
}
