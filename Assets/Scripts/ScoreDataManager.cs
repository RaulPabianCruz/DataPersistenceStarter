using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDataManager : MonoBehaviour
{
    public static ScoreDataManager Instance;

    public string playerName = "Player1";
    public string highscoreName = "";
    public int highscore = 0;

    private void Awake()
    {
        //prolly won't implement switching back to menu
        //but just in case
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
