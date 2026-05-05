using UnityEngine;

public class Coins : MonoBehaviour
{
    Score score;
    GameObject player;
    GameObject scoreObj;

    void Start()
    {
        player = GameObject.Find("Player");

        scoreObj = GameObject.Find("Score text");
        score = scoreObj.GetComponent<Score>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            score.score += 10;
            Destroy(gameObject);
        }
    }
}
