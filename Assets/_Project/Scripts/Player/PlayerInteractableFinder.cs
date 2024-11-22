using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PlayerInteractableFinder : MonoBehaviour, IService
{
    [SerializeField]
    private TMP_Text _text;
    [SerializeField]
    private Canvas _canvas;
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

    void Update()
    {
        if (_interactable != null)
        {
            //Debug.Log(Vector3.Distance(_interactable.Position, transform.position));
        }
        if (_interactable != null && _interactable.CanInteract)
        {
            _text.text = "E";
        }
        else if (_interactable != null && Vector3.Distance(_interactable.Position, transform.position) > _radius)
        {
            _text.text = "";
            _interactable = null;
        }
        else if (_interactable == null)
        {
            _text.text = "";
        }
        _canvas.transform.position = new Vector3(transform.position.x, transform.position.y + 2.3f, transform.position.z);
        _canvas.transform.rotation = Quaternion.identity;
    }

    private void OnKeyEPressed()
    {
        if (_interactable != null && _interactable.CanInteract)
        {
            _text.text = "";
            _interactable.Action();
        }
    }

    private IEnumerator FindInteractables()
    {
        while (true)
        {
            _colliders = new Collider[15];

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
