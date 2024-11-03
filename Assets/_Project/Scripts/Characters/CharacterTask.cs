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
        public List<DictUnit> Coefs { get; private set; } = new List<DictUnit>() 
        { 
            new DictUnit(ItemKey.Laser_Rezak, 0),
            new DictUnit(ItemKey.Prizhkovie_Botinki, 0),
            new DictUnit(ItemKey.Tort, 0),
            new DictUnit(ItemKey.Syntax_Slovar, 0),
            new DictUnit(ItemKey.Ustroistvo_Perevoda, 0),
            new DictUnit(ItemKey.Shocker, 0),
            new DictUnit(ItemKey.Galactic_Spravochnik, 0),
            new DictUnit(ItemKey.Kirka, 0),
            new DictUnit(ItemKey.Dinamyte, 0),
            new DictUnit(ItemKey.Generator_Shita, 0),
            new DictUnit(ItemKey.Ulucshennui_Boevoi_Topor, 0),
            new DictUnit(ItemKey.Verevka, 0),
            new DictUnit(ItemKey.Kapkan, 0),
            new DictUnit(ItemKey.Karandash, 0),
        };
    }
}
