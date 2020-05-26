using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    private Animator porta;

    private fogo fogo;

    public GameObject fogo1, fogo2, fogo3, fogo4;

    AudioSource audio;
    public AudioClip _porta;
    bool porta_;

    void Start()
    {
        porta = GameObject.FindWithTag("porta2").GetComponent<Animator>();

        audio = GetComponent<AudioSource>();
    }
    

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("computador"))
        {
            ComputerRobot.onComputer = true;
        }

        if (col.gameObject.CompareTag("abreporta"))
        {
            if (!porta_)
            {
                audio.PlayOneShot(_porta, 0.4f);
                porta.SetBool("porta", true);
                porta_ = true;
            }
        }
        #region fogo
        if (col.gameObject.CompareTag("fogo1"))
        {
            StartCoroutine(Desbug());
            StartCoroutine(Tempo());
            fogo1.SetActive(false);
        }
        if (col.gameObject.CompareTag("fogo2"))
        {
            StartCoroutine(Desbug());
            StartCoroutine(Tempo());
            fogo2.SetActive(false);
        }
        if (col.gameObject.CompareTag("fogo3"))
        {
            StartCoroutine(Desbug());
            StartCoroutine(Tempo());
            fogo3.SetActive(false);
        }
        if (col.gameObject.CompareTag("fogo4"))
        {
            StartCoroutine(Desbug());
            StartCoroutine(Tempo());
            fogo4.SetActive(false);
        }
        #endregion

        #region Estatuas
        if (col.gameObject.CompareTag("estatua1"))
        {
            Estatuas._info1 = true;
        }
        if (col.gameObject.CompareTag("estatua2"))
        {
            Estatuas._info2 = true;
        }
        if (col.gameObject.CompareTag("estatua3"))
        {
            Estatuas._info3 = true;
        }
        if (col.gameObject.CompareTag("estatua4"))
        {
            Estatuas._info4 = true;
        }
        if (col.gameObject.CompareTag("estatua5"))
        {
            Estatuas._info5 = true;
        }
        if (col.gameObject.CompareTag("estatua6"))
        {
            Estatuas._info6 = true;
        }
        #endregion

        #region RoboC
        if (col.gameObject.CompareTag("roboc1"))
        {
            ComputerRobot.onRoboC1 = true;
        }
        if (col.gameObject.CompareTag("roboc2"))
        {
            ComputerRobot.onRoboC2 = true;
        }
        if (col.gameObject.CompareTag("roboc3"))
        {
            ComputerRobot.onRoboC3 = true;
        }
        if (col.gameObject.CompareTag("roboc4"))
        {
            ComputerRobot.onRoboC4 = true;
        }
        #endregion

        #region RoboT
        if (col.gameObject.CompareTag("robot1"))
        {
            TrasmissorRobot.onRoboT1 = true;
        }
        if (col.gameObject.CompareTag("robot2"))
        {
            TrasmissorRobot.onRoboT2 = true;
        }
        if (col.gameObject.CompareTag("robot3"))
        {
            TrasmissorRobot.onRoboT3 = true;
        }
        if (col.gameObject.CompareTag("robot4"))
        {
            TrasmissorRobot.onRoboT4 = true;
        }
        #endregion

        if (col.gameObject.CompareTag("boss"))
        {
            Boss.onBoss = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("computador"))
        {
            ComputerRobot.onComputer = false;
            ComputerRobot.count = 0;
        }

        #region Estatuas
        if (col.gameObject.CompareTag("estatua1"))
        {
            Estatuas._info1 = false;
        }
        if (col.gameObject.CompareTag("estatua2"))
        {
            Estatuas._info2 = false;
        }
        if (col.gameObject.CompareTag("estatua3"))
        {
            Estatuas._info3 = false;
            CountRobots.onScript = true;
        }
        if (col.gameObject.CompareTag("estatua4"))
        {
            Estatuas._info4 = false;
        }
        if (col.gameObject.CompareTag("estatua5"))
        {
            Estatuas._info5 = false;
        }
        if (col.gameObject.CompareTag("estatua6"))
        {
            Estatuas._info6 = false;
        }
        #endregion

        #region RoboC
        if (col.gameObject.CompareTag("roboc1"))
        {
            ComputerRobot.onRoboC1 = false;
        }
        if (col.gameObject.CompareTag("roboc2"))
        {
            ComputerRobot.onRoboC2 = false;
        }
        if (col.gameObject.CompareTag("roboc3"))
        {
            ComputerRobot.onRoboC3 = false;
        }
        if (col.gameObject.CompareTag("roboc4"))
        {
            ComputerRobot.onRoboC4 = false;
        }
        #endregion

        #region RoboT
        if (col.gameObject.CompareTag("robot1"))
        {
            TrasmissorRobot.onRoboT1 = false;
        }
        if (col.gameObject.CompareTag("robot2"))
        {
            TrasmissorRobot.onRoboT2 = false;
        }
        if (col.gameObject.CompareTag("robot3"))
        {
            TrasmissorRobot.onRoboT3 = false;
        }
        if (col.gameObject.CompareTag("robot4"))
        {
            TrasmissorRobot.onRoboT4 = false;
        }
        #endregion

        if (col.gameObject.CompareTag("boss"))
        {
            Boss.onBoss = false;
        }
    }

    IEnumerator Tempo()
    {
        yield return new WaitForSeconds(5.0f);
        fogo1.SetActive(true);
        fogo2.SetActive(true);
        fogo3.SetActive(true);
        fogo4.SetActive(true);
    }

    IEnumerator Desbug()
    {
        yield return new WaitForSeconds(0.2f);
        Platformer.Mechanics.PlayerController.jumpTakeOffSpeed = 10;
    }
}
