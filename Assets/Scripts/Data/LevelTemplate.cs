using UnityEngine;

namespace Scripts.Data
{
    [CreateAssetMenu(menuName = "Configurations/LevelTemplate")]
    public class LevelTemplate : ScriptableObject
    {
        public BlockHolder BlockPatternPrefab;
    }
}