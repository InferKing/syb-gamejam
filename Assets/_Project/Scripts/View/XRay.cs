using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRay : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform;
    [SerializeField]
    private LayerMask _layerMask;

    RaycastHit oldHit;

    private void FixedUpdate()
    {
        float characterDistance = Vector3.Distance(transform.position, _playerTransform.position);
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out RaycastHit hit, characterDistance, _layerMask))
        {
            if (oldHit.transform)
            {
                if (oldHit.transform.gameObject.TryGetComponent(out Renderer renderer1))
                {
                    renderer1.enabled = true;
                }
            }

            if (hit.transform.gameObject.TryGetComponent(out Renderer renderer2))
            {
                renderer2.enabled = false;
            }

            oldHit = hit;
        }
        else
        {
            if (oldHit.transform != null)
            {
                oldHit.transform.GetComponent<Renderer>().enabled = true;
            }
        }
    }
}
