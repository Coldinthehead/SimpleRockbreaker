using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Data
{
    [CreateAssetMenu(menuName = "Configurations/Stage")]
    public class StageTemplate : ScriptableObject
    {
        [SerializeField]
        public List<StageDetails> Levels;
    }
}