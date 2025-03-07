using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject startBtn;
    public Player birdBek;

    public Text gameOverTxt;
    public float timerBack = 5;

    [SerializeField] private AudioSource gameOverSFx;
    private bool gameOverSFxFlag = false;

    private void Start()
    {
        gameOverTxt.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (birdBek.isDead)
        {
            if (!gameOverSFxFlag)
            {
                gameOverSFxFlag = true;
                gameOverSFx.Play();
            }
            gameOverTxt.gameObject.SetActive(true);
            timerBack -= Time.unscaledDeltaTime;//start counting back
        }

        gameOverTxt.text = "Restarting in " + (timerBack).ToString("0");

        if (timerBack < 0)
        {
            gameOverSFxFlag = false;
            RestartGame();
        }
    }
    public void StartGame()
    {
        startBtn.SetActive(false);
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        Time.timeScale = 0;
    }
    public void RestartGame()
    {
        EditorSceneManager.LoadScene(0);//reload the scene initial state
    }
}
