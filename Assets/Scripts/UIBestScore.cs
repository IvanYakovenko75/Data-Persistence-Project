using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBestScore : MonoBehaviour
{
    //Я создал этот скрипт только для обработки отображения рекордов
    // Он прикреплен к экранному интерфейсу
    public Text bestScoreText;
    // Перетащите нужный текстовый пользовательский интерфейс в это в Инспекторе
    // Я использую устаревший компонент Text (поскольку проект использует его), который использует Text как класс
    // Не стесняйтесь использовать TextMeshPro

    void Start()
    {
        // ЗАГРУЗИТЬ РЕЗУЛЬТАТЫ
        // если вы не загружаетесь при запуске, этот пользовательский интерфейс не будет знать, какой у вас высокий балл
        MainManager.Instance.LoadHighScore();

        Debug.Log("High Score is " + MainManager.Instance.highScore);
        //по желанию. Это здесь, чтобы позволить мне проверить, как все работает

        //ОТОБРАЖЕНИЕ РЕЗУЛЬТАТОВ И ИГРОКА
        if (MainManager.Instance != null)
        {
            if (MainManager.Instance.highScore != 0)
            {
                DisplayHighScore();
            }
            else
            {
                DisplayName();
            }
        }
        else
        {
            bestScoreText.text = "Hello, set a high score!";
        }

        //Это оставшийся код, когда я все настраивал
        //Оставляем это здесь, чтобы вы могли видеть
        /*if (MainManager.Instance != null)
        {
            
            //DisplayName(MainManager.Instance.playerName);
        }
        else
        {
            DisplayName("Ash Ketchum");
        }
        */
    }

    void DisplayHighScore()
    {
        bestScoreText.text = MainManager.Instance.playerName + ", can you beat the High Score " + MainManager.Instance.highScore + " by " + MainManager.Instance.highScoreName + "?";
    }

    void DisplayName()
    {
        bestScoreText.text = MainManager.Instance.playerName + ", set a High Score!";
    }
}