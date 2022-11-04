using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonExit : MonoBehaviour
{
    private Button buttonExit;


    void Start()
    {
        buttonExit = GetComponent<Button>();
    }

    public void ReturnMenuScene()
    {
        SceneManager.LoadScene(0);

    }

}
