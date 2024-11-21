using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabOrders : TerminalTab
{
    [SerializeField]
    private Image _characterIcon;
    [SerializeField]
    private TMP_Text _orderDescription;
    [SerializeField]
    private TMP_Text _characterDescription;
    [SerializeField]
    private TMP_Text _characterName;

    public override void SetActiveTab(bool isActive, NewTask task)
    {
        base.SetActiveTab(isActive, task);

        if (task != null)
        {
            _characterIcon.sprite = task.character.Sprite;
            _orderDescription.text = task.task.Description;
            _characterDescription.text = task.character.Description;
            _characterName.text = task.character.Name;
        }
    }
}
