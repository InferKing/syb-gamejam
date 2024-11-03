using Model.Items;
using System.Collections.Generic;
using UnityEngine;

namespace Model.Characters
{
    [CreateAssetMenu(fileName = "Cfg_Char_", menuName = "Character/Character")]
    public class CharacterData : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }
        [field: SerializeField]
        public CharacterTask Task { get; private set; }
        [field: SerializeField]
        public string WinText { get; private set; }
        [field: SerializeField]
        public string LoseText { get; private set; }
    }

    [System.Serializable]
    public class DictUnit
    {
        public ItemKey key;
        public int coef;

        public DictUnit(ItemKey key, int coef)
        {
            this.key = key;
            this.coef = coef;
        }
    }
}
