using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Dying()
    {
        isDead = true;
    }
    public void Revive()
    {
        isDead = false;
    }
    //create a gameObject called SettingsGO
    //public GameObject SettingsGO;
    #region Singleton

    public static GameManager Instance = null;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public int score = 0; // ScoreKeeping
    //create a bool called gameended
    public bool gameEnded = false;

    /*/public void AddScore(int scoretoAdd)
    {
        // Increase Score Value by incoming score
        score += scoretoAdd;
        // Update UI Here
        UIManager.Instance.UpdateScore(score);
    }
    /*/
    //create a function that ends the game
    public void GameOver()
    {
        gameEnded = true;
    }

    //Reloads the Current Level
    //create a function to restart a scene by loading the activeScene
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //
    //create a function to move to next scene by loading the activeScene +1
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    //create a function to move to previous scene by loading the activeScene - 1
    public void PrevLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    //create a function to load a scene by loading the activeScene of the levelID int
    public void SwitchLevel(int levelID)
    {
        SceneManager.LoadScene(levelID);
    }
    //create a function to quite the game by unityEditor isPlaying false and calling a inbuilt function to make the application quit
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
    
}
