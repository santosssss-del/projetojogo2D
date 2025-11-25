using UnityEngine;

public class GhostController : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2;

    private bool goToB = true;

    void Update()
    {
        if (pointA == null || pointB == null)
        {
            Debug.LogError("❌ ERRO: Point A ou Point B NÃO foram atribuídos no inspetor!");
            return;
        }

        if (goToB)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, pointB.position) < 0.01f)
            {
                goToB = false;

                // 🔄 virar para esquerda
                Vector3 scale = transform.localScale;
                scale.x = -Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, pointA.position) < 0.01f)
            {
                goToB = true;

                // 🔄 virar para direita
                Vector3 scale = transform.localScale;
                scale.x = Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
        }
    }
}
