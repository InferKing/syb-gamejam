using System.Collections.Generic;
using UnityEngine;

public class BoxAnimation : MonoBehaviour
{
    public class InitContainer
    {
        public Vector3 localRotation;
        public Vector3 localPosition;

        public InitContainer(Vector3 localRotation, Vector3 localPosition)
        {
            this.localRotation = localRotation;
            this.localPosition = localPosition;
        }
    }

    [SerializeField]
    private List<GameObject> _sides;
    [SerializeField]
    private Transform _explosionPoint;
    [SerializeField]
    private BoxCollider _collider;

    private Dictionary<GameObject, InitContainer> _matches = new();

    private void Start()
    {
        foreach (var item in _sides)
        {
            _matches[item] = new InitContainer(item.transform.localEulerAngles, item.transform.localPosition);
        }
    }

    public void Play()
    {
        foreach (var item in _sides)
        {
            Vector3 direction = item.transform.position - _explosionPoint.position;
            var rb = item.AddComponent<Rigidbody>();
            rb.AddExplosionForce(50f, _explosionPoint.position, 5f);
        }
        _collider.enabled = false;
    }

    public void ResetSides()
    {
        foreach (var item in _sides)
        {
            item.transform.localEulerAngles = _matches[item].localRotation;
            item.transform.localPosition = _matches[item].localPosition;

            var rb = item.GetComponent<Rigidbody>();

            Destroy(rb);
        }

        _collider.enabled = true;
    }
}
