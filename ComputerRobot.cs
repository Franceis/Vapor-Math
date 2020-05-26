using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerRobot : MonoBehaviour
{
    public GameObject popup;
    public AudioClip error, click, conserto, porta;

    private AudioSource audio;
    
    public static bool onComputer;
    public GameObject computer;
    private string text;
    public GameObject inputField;
    public static Animator porta1;
    private Animator plataforma1;

    public static bool onRoboC1, onRoboC2, onRoboC3, onRoboC4; //Inicializado pelo collider
    private bool robo1on, robo2on, robo3on, robo4on; //AntBug
    public GameObject roboc1, roboc2, roboc3, roboc4; //Dialogo
    private string text1, text2; //Resposta do dialogo
    public GameObject input1, input2; //Index de busca para a resposta
    private Animator robo1, robo2, robo3, robo4; //Animaçoes dos robos

    public static int count;

    void Start()
    {
        #region Computer
        count = 0;
        porta1 = GameObject.FindWithTag("porta1").GetComponent<Animator>();
        plataforma1 = GameObject.FindWithTag("plataforma0").GetComponent<Animator>();
        #endregion
        audio = GetComponent<AudioSource>();

        robo1 = GameObject.FindGameObjectWithTag("roboc1").GetComponent<Animator>();
        robo2 = GameObject.FindGameObjectWithTag("roboc2").GetComponent<Animator>();
        robo3 = GameObject.FindGameObjectWithTag("roboc3").GetComponent<Animator>();
        robo4 = GameObject.FindGameObjectWithTag("roboc4").GetComponent<Animator>();

        robo1on = true;
        robo2on = true;
        robo3on = true;
        robo4on = true;
    }

    public void ComputerButton()
    {
        text = inputField.GetComponent<Text>().text;

        if (text == "6")
        {
            porta1.SetBool("porta", true);
            count++;
            audio.PlayOneShot(porta, 0.4f);
        }
        else
        {
            popup.SetActive(true);
            audio.PlayOneShot(error, 0.5f);
            plataforma1.SetBool("plataforma", true);
            computer.SetActive(false);
            count++;
        }
    }
    
    void Update()
    {
        #region Computador
        if (onComputer & count == 0)
        {
            computer.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ComputerButton();
            }
        }
        else
        {
            computer.SetActive(false);
        }
        #endregion

        #region Robos
        if (robo1on)
        {
            if (onRoboC1)
            {
                roboc1.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Ok();
                }
            }
            else
            {
                roboc1.SetActive(false);
            }
        }
        else
        {
            roboc1.SetActive(false);
        }
        if (robo2on)
        {
            if (onRoboC2)
            {
                roboc2.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Ok();
                }
            }
            else
            {
                roboc2.SetActive(false);
            }
        }
        else
        {
            roboc2.SetActive(false);
        }
        if (robo3on)
        {
            if (onRoboC3)
            {
                roboc3.SetActive(true);
            }
            else
            {
                roboc3.SetActive(false);
            }
        }
        else
        {
            roboc3.SetActive(false);
        }
        if (robo4on)
        {
            if (onRoboC4)
            {
                roboc4.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Ok();
                }
            }
            else
            {
                roboc4.SetActive(false);
            }
        }
        else
        {
            roboc4.SetActive(false);
        }
        #endregion
    }

    public void Ok()
    {
        text1 = input1.GetComponent<Text>().text;
        text2 = input2.GetComponent<Text>().text;

        if (onRoboC1)
        {
            if (text1 == "270.6")
            {
                robo1on = false;
                robo1.SetBool("consertado", true);
                audio.PlayOneShot(conserto, 0.3f);
                CountRobots.count++;
            }
            else
            {
                popup.SetActive(true);
                audio.PlayOneShot(error, 0.5f);
                roboc1.SetActive(false);
            }
        }
        if (onRoboC2)
        {
            if (text2 == "50")
            {
                robo2on = false;
                robo2.SetBool("consertado", true);
                audio.PlayOneShot(conserto, 0.3f);
                CountRobots.count++;
            }
            else
            {
                popup.SetActive(true);
                audio.PlayOneShot(error, 0.5f);
                roboc2.SetActive(false);
            }
        }
    }

    public void OnClickExit()
    {
        popup.gameObject.SetActive(false);
        audio.PlayOneShot(click, 0.6f);
    }

    public void True()
    {
        if (onRoboC3)
        {
            robo3on = false;
            robo3.SetBool("consertado", true);
            audio.PlayOneShot(conserto, 0.3f);
            CountRobots.count++;
        }

        if (onRoboC4)
        {
            popup.SetActive(true);
            audio.PlayOneShot(error, 0.5f);
            roboc4.SetActive(false);
        }
    }

    public void False()
    {
        if (onRoboC3)
        {
            onRoboC3 = false;
            popup.SetActive(true);
            audio.PlayOneShot(error, 0.5f);
            roboc3.SetActive(false);
        }

        if (onRoboC4)
        {
            robo4on = false;
            robo4.SetBool("consertado", true);
            audio.PlayOneShot(conserto, 0.3f);
            CountRobots.count++;
        }
    }
}
