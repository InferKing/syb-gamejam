using System.Collections;
using UnityEngine;

public class PlayerInteractableFinder : MonoBehaviour
{
    [SerializeField]
    private float _radius = 3f;
    [SerializeField]
    private LayerMask _layer;

    private IInteractable _interactable;

    private Collider[] _colliders;
    private WaitForSeconds _delay = new(.1f);

    private void Start()
    {
        _colliders = new Collider[15];

        StartCoroutine(FindInteractables());
    }

    private IEnumerator FindInteractables()
    {
        while (true)
        {
            Physics.OverlapSphereNonAlloc(transform.position, _radius, _colliders, _layer);
            foreach (Collider collider in _colliders) 
            { 
                if (collider.TryGetComponent(out IInteractable interactable))
                {
                    if (_interactable.CanInteract)
                    {
                        _interactable = interactable;
                    }
                }
            }
            yield return _delay;
        }
    }
}
