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
        isSuccess.text = ServiceLocator.Instance.Get<GameModel>().resultTasks[task] ? "<color=green>”—œ≈’</color>" : "<color=red>Õ≈”ƒ¿◊¿</color>";
        description.text = ServiceLocator.Instance.Get<GameModel>().resultTasks[task] ? task.character.WinText : task.character.LoseText;
    }
}
