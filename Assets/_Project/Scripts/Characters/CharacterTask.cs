using Model.Items;
using System.Collections.Generic;
using UnityEngine;

namespace Model.Characters
{
    [CreateAssetMenu(fileName = "Cfg_Char_Task_", menuName = "Character/Task")]
    public class CharacterTask : ScriptableObject
    {
        [field: SerializeField]
        public string Description { get; private set; }
        [field: SerializeField]
        public float RoundTime { get; private set; }
        [field: SerializeField]
        public int MaxItems { get; private set; }
        [field: SerializeField]
        public int MinCoefToWin { get; private set; }
        [field: SerializeField]
        public List<DictUnit> Coefs { get; private set; }
    }
}
