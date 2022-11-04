using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class MainManager : MonoBehaviour
{
public static MainManager Instance; /*реализован паттерн Singleton, позволяющий создать всего один экземпляр указанного типа для всего приложения.*/

    // Переменные, сохраняемые для текущей сессии публичные, чтобы другие скрипты могли их прочитать.
    public string playerName;
    public int currentScore;

    //Переменные, сохраняемые между сессиями публичные, чтобы другие скрипты могли их прочитать.
    public string highScoreName;
    public int highScore;

    private void Awake()
    {
        //если в сцене 2 MainManager, уничтожьте этот MainManager
        //Происходит, когда другая сцена, на которую вы переместились, пытается создать свой собственный MainManager.
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        //Но если это единственное, не уничтожаем
        Instance = this;
        DontDestroyOnLoad(gameObject);
        //Загрузим высокий балл.
            LoadHighScore();
    }

    //Метод заргузки основной игровой сцены
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    //Класс для сохранения данных на каждой сцене
    [System.Serializable]
    public class SaveData
    {
        public int highScore;
        public string highScoreName;
    }

    //Метод созранения счёта и имени.
    public void SaveHighScore(int currentScore, string playerName)
    {
        //Создаём новый экземпляр данных сохранения
        SaveData data = new SaveData();

        //Указываем, что будем сохранять
        data.highScore = currentScore;
        data.highScoreName = playerName;

        //Затем преобразуйте этот экземпляр в JSON с помощью JsonUtility.ToJson: 
        string json = JsonUtility.ToJson(data);

        //Наконец, используйте специальный метод File.WriteAllText для записи строки в файл.
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }


    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScoreName = data.highScoreName;
        }
    }

}