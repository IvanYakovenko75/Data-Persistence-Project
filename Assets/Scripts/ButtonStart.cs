using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonStart : MonoBehaviour
{
    private Button buttonStart;

    void Start()
    {
        buttonStart = GetComponent<Button>();
    }

    public void LoadGame()
    {

        SceneManager.LoadScene(1);

    }

}
