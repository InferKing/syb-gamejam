using UnityEngine;

namespace Model.Items
{
	[CreateAssetMenu(fileName = "Cfg_Item_", menuName = "Item")]
	public class ItemData : ScriptableObject
	{
		[field: SerializeField]
		public ItemKey ItemKey { get; private set; }
		[field: SerializeField]
		public string Name { get; private set; }
	} 
}
