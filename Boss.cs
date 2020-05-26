using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    private Animator boss;
    public GameObject quest1, quest2, quest3, quest4;
    private bool _quest1, _quest2, _quest3, _quest4;

    public static bool onBoss;
    private bool BossOn;

    private int count;
    private string text1, text2, text3;
    public GameObject input1, input2, input3;

    private AudioSource audio;
    public AudioClip conserto, erro;
    public GameObject popup;

    public GameObject player;
    public GameObject player_bug;
    Vector2 player_transform;

    public GameObject GameOver;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        boss = GameObject.FindGameObjectWithTag("boss").GetComponent<Animator>();

        BossOn = true;

        _quest1 = true;

        GameOver.SetActive(false);
    }
    
    void FixedUpdate()
    {
        if (BossOn)
        {
            if (onBoss)
            {
                if(_quest1)
                {
                    quest1.SetActive(true);
                }
                else
                {
                    quest1.SetActive(false);
                }

                if(_quest2)
                {
                    quest2.SetActive(true);
                }
                else
                {
                    quest2.SetActive(false);
                }

                if (_quest3)
                {
                    quest3.SetActive(true);
                }

                if (_quest4)
                {
                    quest4.SetActive(true);
                }
                else
                {
                    quest4.SetActive(false);
                }
            }
            else
            {
                quest1.SetActive(false);
                quest2.SetActive(false);
                quest3.SetActive(false);
                quest4.SetActive(false);
            }
        }
        else
        {
            boss.SetBool("consertado", true);
        }

        player_transform = player.transform.position;
        
    }

    public void Ok()
    {
        text1 = input1.GetComponent<Text>().text;

        if (text1 == "638")
        {
            quest1.SetActive(false);
            audio.PlayOneShot(conserto, 0.3f);
            _quest1 = false;
            _quest2 = true;
        }
        else
        {
            audio.PlayOneShot(erro, 0.4f);
            popup.SetActive(true);
            onBoss = false;
        }
    }
    public void Ok2()
    {
        text2 = input2.GetComponent<Text>().text;

        if (text2 == "199.8")
        {
            quest2.SetActive(false);
            audio.PlayOneShot(conserto, 0.3f);
            _quest2 = false;
            _quest3 = true;
        }
        else
        {
            audio.PlayOneShot(erro, 0.4f);
            popup.SetActive(true);
            onBoss = false;
        }
    }
    public void Ok3()
    {
        text3 = input3.GetComponent<Text>().text;

        if (_quest4)
        {
            if (text3 == "str" || text3 == "Str")
            {
                quest4.SetActive(false);
                audio.PlayOneShot(conserto, 0.3f);
                BossOn = false;
                DeadEnd();
            }
            else
            {
                audio.PlayOneShot(erro, 0.4f);
                popup.SetActive(true);
                onBoss = false;
            }
        }
    }
    

    public void True()
    {
        popup.SetActive(true);
        audio.PlayOneShot(erro, 0.4f);
        onBoss = false;
    }
    public void False()
    {
        quest3.SetActive(false);
        audio.PlayOneShot(conserto, 0.3f);
        _quest3 = false;
        _quest4 = true;
    }

    IEnumerator tempo()
    {
        yield return new WaitForSeconds(7f);
        GameOver.SetActive(true);
    }

    void DeadEnd()
    {
        player.SetActive(false);
        Instantiate(player_bug, player_transform, Quaternion.identity);
        StartCoroutine(tempo());
    }
}
