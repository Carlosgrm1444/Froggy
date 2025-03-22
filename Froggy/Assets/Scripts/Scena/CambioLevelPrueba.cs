using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioLevelPrueba : MonoBehaviour
{
    public SceneGeneral transition;

    public string level;

    void Start()
    {
        transition = GameObject.FindGameObjectWithTag("Camara").GetComponent<SceneGeneral>();
    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(NivelCompletado());
            PlayerMove.play = 0;
        }
    }
    IEnumerator NivelCompletado()
    {  
        transition.AnimTransition();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(level);
    }
}
