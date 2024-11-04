using UnityEngine;

public class ItemBox : MonoBehaviour, IInteractable
{
    public bool CanInteract => ServiceLocator.Instance.Get<GameModel>().State == GameState.GetAll;

    public Vector3 Position => transform.position;

    public void Action()
    {
        GameModel model = ServiceLocator.Instance.Get<GameModel>();

        int result = 0;

        foreach (var item in model.CurrentTask.task.Coefs)
        {
            foreach (var t in ServiceLocator.Instance.Get<PickedItems>().PlayerPickedItems)
            {
                if (t.ItemKey == item.key)
                {
                    result += item.coef;
                }
            }
        }

        AudioManager.Instance.PlayChpok();

        if (result >= model.CurrentTask.task.MinCoefToWin)
        {
            ServiceLocator.Instance.Get<EventBus>().Invoke(new SuccessTaskSignal(model.CurrentTask));
        }
        else
        {
            ServiceLocator.Instance.Get<EventBus>().Invoke(new FailedTaskSignal(model.CurrentTask));
        }

        ServiceLocator.Instance.Get<GameModel>().State = GameState.Idle;
        ServiceLocator.Instance.Get<EventBus>().Invoke(new GameStateChangedSignal(GameState.Idle));
    }
}
