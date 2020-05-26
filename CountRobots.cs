using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountRobots : MonoBehaviour
{
    public static bool onScript;

    public GameObject UI;
    public Text _count;
    public static int count;

    private Animator porta_anim;
    AudioSource audio;
    public AudioClip porta_sound;
    private bool som;

    void Start()
    {
        som = false;
        onScript = false;
        UI.SetActive(false);

        porta_anim = GameObject.FindWithTag("porta3").GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if(count == 0)
        {
            UI.SetActive(false);
        }

        if (onScript)
        {
            UI.SetActive(true);
            _count.text = count + " / 4";
        }
        if (count == 4 && !som)
        {
            _count.color = Color.green;
            StartCoroutine(Tempinho());
            som = true;
        }
    }

IEnumerator Tempinho()
    {
        yield return new WaitForSeconds(2.5f);
        onScript = false;
        porta_anim.SetBool("porta", true);
        audio.PlayOneShot(porta_sound, 0.4f);
        count = 0;
    }
}
