using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogo : MonoBehaviour
{
    public bool coletado;
    float cd = 5f;

    public SpriteRenderer sprite;
    public BoxCollider2D coll;
    public Animator anim;

    void Start()
    {
        sprite = this.gameObject.GetComponent<SpriteRenderer>();
        coll = this.gameObject.GetComponent<BoxCollider2D>();
        anim = this.gameObject.GetComponent<Animator>();
    }
    
    void Update()
    {
        if (coletado)
        {
            StartCoroutine(Tempo());
            sprite.enabled = false;
            coll.enabled = false;
            anim.enabled = false;
        }
        else
        {
            sprite.enabled = true;
            coll.enabled = true;
            anim.enabled = true;
        }
    }

    public IEnumerator Tempo()
    {
        yield return new WaitForSeconds(cd);
        coletado = false;
    }
}
