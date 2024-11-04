using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInteractableFinder : MonoBehaviour, IService
{
    [SerializeField]
    private float _radius = 1f;
    [SerializeField]
    private LayerMask _layer;

    private IInteractable _interactable;

    private Collider[] _colliders;
    private WaitForSeconds _delay = new(.05f);
    private InputManager _inputManager;

    private void Start()
    {
        _colliders = new Collider[15];

        _inputManager = ServiceLocator.Instance.Get<InputManager>();
        _inputManager.KeyEPressed += OnKeyEPressed;

        StartCoroutine(FindInteractables());
    }

    private void OnKeyEPressed()
    {
        if (_interactable != null && _interactable.CanInteract)
        {
            _interactable.Action();
        }
    }

    private IEnumerator FindInteractables()
    {
        while (true)
        {
            Physics.OverlapSphereNonAlloc(transform.position, _radius, _colliders, _layer);
            List<IInteractable> interactables = new();
            
            foreach (Collider collider in _colliders) 
            { 
                if (collider == null) continue;
                if (collider.TryGetComponent(out IInteractable interactable) && interactable.CanInteract)
                {
                    interactables.Add(interactable);
                }
            }

            _interactable = GetNearestInteractable(interactables);

            yield return _delay;
        }
    }

    private IInteractable GetNearestInteractable(List<IInteractable> interactables)
    {
        return interactables.OrderBy(interactbale => Vector3.Distance(transform.position, interactbale.Position)).FirstOrDefault();
    }

    private void OnDisable()
    {
        _inputManager.KeyEPressed -= OnKeyEPressed;
    }
}
