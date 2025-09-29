using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIManager : MonoBehaviour
{
    public GameObject inputGameObj;
    public TextMeshProUGUI highscoreText;
    private TMP_InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        inputField = inputGameObj.GetComponent<TMP_InputField>();
    }

    public void StartNew()
    {
        if (!string.IsNullOrEmpty(inputField.text))
        {
            ScoreDataManager.Instance.playerName = inputField.text;
        }
        SceneManager.LoadScene(1);
    }

    public void DisplayHighScoreText()
    {
        highscoreText.text = $"Best Score : {ScoreDataManager.Instance.highscoreName}" +
            $" : {ScoreDataManager.Instance.highscore}";
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
