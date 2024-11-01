using System.Collections.Generic;
using UnityEngine;

namespace Model.Characters
{
    [CreateAssetMenu(fileName = "Cfg_Character_", menuName = "Character/Character")]
    public class CharacterData : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }
        [field: SerializeField]
        public List<CharacterTask> Tasks { get; private set; }
    }
}
