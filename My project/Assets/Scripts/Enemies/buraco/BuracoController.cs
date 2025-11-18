using UnityEngine;

public class BuracoController : MonoBehaviour
{
    [SerializeField] int dano = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().TomarDano(dano);
        }
    }
}