using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGeneral : MonoBehaviour
{
    public Animator uiBay;
    public Animator botones;
    void Start()
    {
        animTransitionPlay();
        GameObject.FindGameObjectWithTag("Player").gameObject.SetActive(true);
        uiBay = GameObject.FindGameObjectWithTag("Interfaz").GetComponent<Animator>();
        botones = GameObject.FindGameObjectWithTag("Botones").GetComponent<Animator>();
    }

    void Update()
    {

    }
    public void AnimTransition()
    {
        uiBay.SetBool("Finish", true);
        botones.SetBool("Finish", true);
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void animTransitionPlay()
    {
        gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.SetActive(true);
        StartCoroutine(TransitionPlay());
    }
    IEnumerator TransitionPlay()
    {
        yield return new WaitForSeconds(3f);
    }
}
