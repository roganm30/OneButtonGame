using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TextMeshProUGUI text;
    public int score;
    float timer = 0.5f;
    float timeToNextScore = 0.5f;

    Spider spider;

    void Start()
    {
        score = 0;
        text = GetComponent<TextMeshProUGUI>();

        GameObject player = GameObject.Find("Player");
        spider = player.GetComponent<Spider>();
    }

    void Update()
    {
        if (spider.isDead)
            return;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            score++;
            if (timeToNextScore > 0.075f)
                timeToNextScore *= 0.99f;
            timer = timeToNextScore;
        }
        text.text = score.ToString();
    }
}
