using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperController : MonoBehaviour
{
    private CapsuleCollider2D colliderKeeper;
    private Animator anim;
    private bool goRight;

    public int life;
    public float speed;

    public Transform a;
    public Transform b;

    public GameObject range;

    void Start()   // <-- corrigido
    {
        colliderKeeper = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Morte
        if (life <= 0)
        {
            colliderKeeper.enabled = false;
            range.SetActive(false);
            anim.Play("Die", -1);
            enabled = false; // <-- desativa depois
            return;
        }

        // Interrompe se estiver atacando
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            return;

        // Anda para B
        if (goRight)
        {
            if (Vector2.Distance(transform.position, b.position) < 0.5f)
                goRight = false;

            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.position = Vector2.MoveTowards(transform.position, b.position, speed * Time.deltaTime); // <-- corrigido
        }
        // Anda para A
        else
        {
            if (Vector2.Distance(transform.position, a.position) < 0.5f)
                goRight = true;

            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.position = Vector2.MoveTowards(transform.position, a.position, speed * Time.deltaTime); // <-- corrigido
        }
    }
}
