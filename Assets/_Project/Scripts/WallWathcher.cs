using UnityEngine;

public class WallTransparencyController : MonoBehaviour
{
    public Transform player; // Ссылка на объект игрока
    public float transparencyDistance = 5f; // Максимальная дистанция для проверки
    public LayerMask wallLayer; // Слой, на котором находятся стены
    
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


            //// Если луч попадает в стену, делаем ее прозрачной
            //Renderer hitRenderer = hit.collider.GetComponent<Renderer>();
            //if (hitRenderer != null)
            //{

            //    // Сохраняем оригинальный цвет, если еще не сохранен
            //    if (wallMaterial == null)
            //    {
            //        wallMaterial = hitRenderer.material;
            //        originalColor = wallMaterial.color; // Сохраняем оригинальный цвет
            //    }

            //    Color color = originalColor;
            //    color.a = 0.5f; // Установите желаемую прозрачность
            //    hit.collider.gameObject.GetComponent<Renderer>().material.color = color;
            //}
        }
        else
        {
            //// Если луч не попадает в стену, восстанавливаем непрозрачность
            //if (wallMaterial != null)
            //{
            //    wallMaterial.color = originalColor; // Восстанавливаем оригинальный цвет
            //    wallMaterial = null; // Сбрасываем ссылку на материал
            //}
        }
    }
}

