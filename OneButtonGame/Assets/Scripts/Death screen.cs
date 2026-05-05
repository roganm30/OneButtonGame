using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Deathscreen : MonoBehaviour
{
    TextMeshProUGUI finalScore;
    public Score scoreScript;
    public GameObject deathScreen;

    Spider spider;
    public bool winScreen = false;

    void Start()
    {
        finalScore = GetComponentInChildren<TextMeshProUGUI>();
        deathScreen.SetActive(false);

        GameObject player = GameObject.Find("Player");
        spider = player.GetComponent<Spider>();
    }

    void Update()
    {
        if (!spider.isDead)
            return;

        deathScreen.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (!winScreen)
            finalScore.text = "Final Score:\n" + scoreScript.score.ToString() + "\n \nPress SPACE to restart or ESC to quit.";
        else
            finalScore.text = "You win! Final Score:\n" + scoreScript.score.ToString() + "\n \nPress SPACE to restart or ESC to quit.";
    }
}
