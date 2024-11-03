using UnityEngine;

public class WallTransparencyController : MonoBehaviour
{
    public Transform player; // ������ �� ������ ������
    public float transparencyDistance = 5f; // ������������ ��������� ��� ��������
    public LayerMask wallLayer; // ����, �� ������� ��������� �����
    
    private Material wallMaterial;
    private Color originalColor;

    void Update()
    {
        Vector3 cameraPosition = transform.position;
        Vector3 playerPosition = player.position;
        Vector3 directionToPlayer = (playerPosition - cameraPosition).normalized;
        Ray ray = new Ray(transform.position, directionToPlayer);
        RaycastHit hit;

        Debug.DrawRay(transform.position, directionToPlayer*100f, Color.green);

        if (Physics.Raycast(cameraPosition, directionToPlayer, out hit, transparencyDistance, wallLayer))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.TryGetComponent(out Hideble hideble))
                {
                    originalColor = GetComponent<Renderer>().material.color;
                    Color color1 = originalColor;
                    hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.blue;
                    
                   // hideble.Hide(color1);
                }
            }


            //// ���� ��� �������� � �����, ������ �� ����������
            //Renderer hitRenderer = hit.collider.GetComponent<Renderer>();
            //if (hitRenderer != null)
            //{

            //    // ��������� ������������ ����, ���� ��� �� ��������
            //    if (wallMaterial == null)
            //    {
            //        wallMaterial = hitRenderer.material;
            //        originalColor = wallMaterial.color; // ��������� ������������ ����
            //    }

            //    Color color = originalColor;
            //    color.a = 0.5f; // ���������� �������� ������������
            //    hit.collider.gameObject.GetComponent<Renderer>().material.color = color;
            //}
        }
        else
        {
            //// ���� ��� �� �������� � �����, ��������������� ��������������
            //if (wallMaterial != null)
            //{
            //    wallMaterial.color = originalColor; // ��������������� ������������ ����
            //    wallMaterial = null; // ���������� ������ �� ��������
            //}
        }
    }
}

