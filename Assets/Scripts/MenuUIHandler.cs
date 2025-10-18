using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField playerName;

    public TextMeshProUGUI bestScore;

    // Start is called before the first frame update
    void Start()
    {
        bestScore.text = "Best Score : " + SaveManager.instance.playerBestName + " : " + SaveManager.instance.m_bestScore;
        playerName.text = SaveManager.instance.playerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        SaveManager.instance.SaveBestScore(SaveManager.instance.m_bestScore, playerName.text.ToString());
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        SaveManager.instance.SaveBestScore(SaveManager.instance.m_bestScore, playerName.text.ToString());
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}

