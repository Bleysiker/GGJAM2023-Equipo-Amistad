using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGroundDisappear : MonoBehaviour
{
    [SerializeField] CanvasGroup transparencia;
    [SerializeField] REvents changeBackground,screenW;
    [SerializeField] int lvls;
    [SerializeField] float aparicion;
    // Start is called before the first frame update
    void Start()
    {
        lvls = 0;
        transparencia.LeanAlpha(0, aparicion);
        changeBackground.GEvent += DestinoFinal;
        screenW.GEvent += ScreenW;
    }

    void DestinoFinal()
    {
        
        if (lvls > 2)
        {
            transparencia.LeanAlpha(1, aparicion);
            StartCoroutine(Complete());
            //aca deben desaparecer los obstaculos
        }
        else
        {
            lvls++;
        }
        
    }
    IEnumerator Complete()
    {
        yield return new WaitForSeconds(aparicion);
        SceneManager.LoadScene("Final");
    }
    void ScreenW()
    {
        
        transparencia.LeanAlpha(1, aparicion);
    }
    private void OnDestroy()
    {
        screenW.GEvent -= ScreenW;
        changeBackground.GEvent -= DestinoFinal;
    }
}
