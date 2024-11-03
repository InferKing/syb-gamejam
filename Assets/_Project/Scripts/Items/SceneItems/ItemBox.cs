using UnityEngine;

// для отправки подобранного
public class ItemBox : MonoBehaviour, IInteractable
{
    public bool CanInteract => true;

    public Vector3 Position => transform.position;

    public void Action()
    {
        if (ServiceLocator.Instance.Get<GameModel>().State == GameState.GetAll)
        {
            ServiceLocator.Instance.Get<GameModel>().State = GameState.Idle;
            ServiceLocator.Instance.Get<EventBus>().Invoke(new GameStateChangedSignal(GameState.Idle));
        }
    }
}
