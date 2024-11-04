using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EmailView : MonoBehaviour
{
    public Image icon;
    public TMP_Text isSuccess, description;


    public void UpdateView(NewTask task)
    {
        icon.sprite = task.character.Sprite;
        isSuccess.text = ServiceLocator.Instance.Get<GameModel>().resultTasks[task] ? "<color=green>�����</color>" : "<color=red>�������</color>";
        description.text = ServiceLocator.Instance.Get<GameModel>().resultTasks[task] ? task.character.WinText : task.character.LoseText;
    }
}
