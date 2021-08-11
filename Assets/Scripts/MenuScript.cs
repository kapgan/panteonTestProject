using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI playOrPaintText;
    [SerializeField] GameObject panel;

    public bool Paint = false;

    private void Start()
    {
        Time.timeScale = 0;
    }


    public void PlayGameOrPaintLevel()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        playOrPaintText.text = "Paint GO";
        if (Paint)
            panel.SetActive(true);
    }

 

    public void ExitGame()
    {
        Application.Quit();
    }
}
