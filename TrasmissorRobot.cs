using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrasmissorRobot : MonoBehaviour
{
    public GameObject popup;
    public AudioClip error, click, conserto, _porta;
    private AudioSource audio;

    public static bool onRoboT1, onRoboT2, onRoboT3, onRoboT4; //Inicializado pelo collider
    private bool robo1on, robo2on, robo3on, robo4on; //AntBug
    public GameObject robot1, robot2, robot3, robot4; //Dialogo dos robos
    private string text1, text2, text3, text4; //Resposta do dialogo
    public GameObject input1, input2, input3, input4; //Index de busca para a resposta
    private Animator robo1, robo2, robo3, robo4; //Animaçoes dos robos

    private Animator plat1, plat2, plat3, porta;
    private int count;

    void Start()
    {
        count = 0;

        audio = GetComponent<AudioSource>();

        robo1 = GameObject.FindGameObjectWithTag("robot1").GetComponent<Animator>();
        robo2 = GameObject.FindGameObjectWithTag("robot2").GetComponent<Animator>();
        robo3 = GameObject.FindGameObjectWithTag("robot3").GetComponent<Animator>();
        robo4 = GameObject.FindGameObjectWithTag("robot4").GetComponent<Animator>();

        plat1 = GameObject.FindGameObjectWithTag("plataforma1").GetComponent<Animator>();
        plat2 = GameObject.FindGameObjectWithTag("plataforma2").GetComponent<Animator>();
        plat3 = GameObject.FindGameObjectWithTag("plataforma3").GetComponent<Animator>();
        porta = GameObject.FindGameObjectWithTag("porta4").GetComponent<Animator>();

        robo1on = true;
        robo2on = true;
        robo3on = true;
        robo4on = true;
    }
    
    void Update()
    {
        if(count == 3)
        {
            porta.SetBool("porta", true);
            count++;
            audio.PlayOneShot(_porta, 0.4f);
        }

        if (robo1on)
        {
            if (onRoboT1)
            {
                robot1.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Ok();
                }
            }
            else
            {
                robot1.SetActive(false);
            }
        }
        else
        {
            robot1.SetActive(false);
        }

        if (robo2on)
        {
            if (onRoboT2)
            {
                robot2.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Ok();
                }
            }
            else
            {
                robot2.SetActive(false);
            }
        }
        else
        {
            robot2.SetActive(false);
        }

        if (robo3on)
        {
            if (onRoboT3)
            {
                robot3.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Ok();
                }
            }
            else
            {
                robot3.SetActive(false);
            }
        }
        else
        {
            robot3.SetActive(false);
        }

        if (robo4on)
        {
            if (onRoboT4)
            {
                robot4.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Ok();
                }
            }
            else
            {
                robot4.SetActive(false);
            }
        }
        else
        {
            robot4.SetActive(false);
        }
    }

    public void Ok()
    {
        text1 = input1.GetComponent<Text>().text;
        text2 = input2.GetComponent<Text>().text;
        text3 = input3.GetComponent<Text>().text;
        text4 = input4.GetComponent<Text>().text;

        if (onRoboT1)
        {
            if(text1 == "43")
            {
                Platforms.ON = true;
                robo1on = false;
                robo1.SetBool("consertado", true);
                robot1.SetActive(false);
                audio.PlayOneShot(conserto, 0.3f);
            }
            else
            {
                popup.SetActive(true);
                audio.PlayOneShot(error, 0.5f);
                onRoboT1 = false;
            }
        }
        if (onRoboT2)
        {
            if (text2 == "str" || text2 == "Str")
            {
                plat1.SetBool("on", true);
                robo2on = false;
                robo2.SetBool("consertado", true);
                robot2.SetActive(false);
                audio.PlayOneShot(conserto, 0.3f);
                count++;
            }
            else
            {
                popup.SetActive(true);
                audio.PlayOneShot(error, 0.5f);
                onRoboT2 = false;
            }
        }
        if (onRoboT3)
        {
            if (text3 == "int" || text3 == "Int")
            {
                plat2.SetBool("on", true);
                robo3on = false;
                robo3.SetBool("consertado", true);
                robot3.SetActive(false);
                audio.PlayOneShot(conserto, 0.3f);
                count++;
            }
            else
            {
                popup.SetActive(true);
                audio.PlayOneShot(error, 0.5f);
                onRoboT3 = false;
            }
        }
        if (onRoboT4)
        {
            if (text4 == "str" || text4 == "Str")
            {
                plat3.SetBool("on", true);
                robo4on = false;
                robo4.SetBool("consertado", true);
                robot4.SetActive(false);
                audio.PlayOneShot(conserto, 0.3f);
                count++;
            }
            else
            {
                popup.SetActive(true);
                audio.PlayOneShot(error, 0.5f);
                onRoboT4 = false;
            }
        }
    }

    public void OnClickExit()
    {
        popup.gameObject.SetActive(false);
        audio.PlayOneShot(click, 0.6f);
    }
}
