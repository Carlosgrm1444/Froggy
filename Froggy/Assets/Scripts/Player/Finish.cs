using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public SceneGeneral transition;
    public string levelClear;

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
            GetComponent<Animator>().enabled = true;
            StartCoroutine(NivelCompletado());
            PlayerMove.play = 0;
            PlayerPrefs.SetInt(levelClear, 1);
            PlayerPrefs.DeleteKey("checkPointPositionY");
            PlayerPrefs.DeleteKey("checkPointPositionX");
        }
    }
    IEnumerator NivelCompletado()
    {
        yield return new WaitForSeconds(3f);
        transition.AnimTransition();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("SelectorNiveles");
    }
}
