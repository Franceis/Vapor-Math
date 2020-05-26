using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estatuas : MonoBehaviour
{
    public GameObject Hello_txt, Var_txt, button1;

    public static bool _info1, _info2, _info3, _info4, _info5, _info6;
    public GameObject info1, info2, info3, info4, info5, info6;

    private Animator statua1, statua2, statua3, statua4, statua5, statua6;

    void Start()
    {
        statua1 = GameObject.FindWithTag("estatua1").GetComponent<Animator>();
        statua2 = GameObject.FindWithTag("estatua2").GetComponent<Animator>();
        statua3 = GameObject.FindWithTag("estatua3").GetComponent<Animator>();
        statua4 = GameObject.FindWithTag("estatua4").GetComponent<Animator>();
        statua5 = GameObject.FindWithTag("estatua5").GetComponent<Animator>();
        statua6 = GameObject.FindWithTag("estatua6").GetComponent<Animator>();

        statua1.SetBool("new_info", true);
        statua2.SetBool("new_info", true);
        statua3.SetBool("new_info", true);
        statua4.SetBool("new_info", true);
        statua5.SetBool("new_info", true);
        statua6.SetBool("new_info", true);
    }
    void Update()
    {
        if (_info1)
        {
            info1.SetActive(true);
            statua1.SetBool("new_info", false);
            ComputerRobot.count = 0;
        }
        else
        {
            info1.SetActive(false);
        }

        if (_info2)
        {
            info2.SetActive(true);
            statua2.SetBool("new_info", false);
        }
        else
        {
            info2.SetActive(false);
        }

        if (_info3)
        {
            info3.SetActive(true);
            statua3.SetBool("new_info", false);
        }
        else
        {
            info3.SetActive(false);
        }

        if (_info4)
        {
            info4.SetActive(true);
            statua4.SetBool("new_info", false);
        }
        else
        {
            info4.SetActive(false);
        }

        if (_info5)
        {
            info5.SetActive(true);
            statua5.SetBool("new_info", false);
        }
        else
        {
            info5.SetActive(false);
        }

        if (_info6)
        {
            info6.SetActive(true);
            statua6.SetBool("new_info", false);
        }
        else
        {
            info6.SetActive(false);
        }
    }

    public void OnClickBtn1()
    {
        Hello_txt.SetActive(false);
        Var_txt.SetActive(true);
        button1.SetActive(false);
    }
}
