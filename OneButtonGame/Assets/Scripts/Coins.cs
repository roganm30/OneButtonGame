using UnityEngine;

public class Coins : MonoBehaviour
{
    Score score;
    Spider spider;
    GameObject player;
    GameObject scoreObj;

    public bool isRed;

    void Start()
    {
        player = GameObject.Find("Player");
        spider = player.GetComponent<Spider>();

        scoreObj = GameObject.Find("Score text");
        score = scoreObj.GetComponent<Score>();
    }

    private void Update()
    {
        if (isRed && transform.position.x < -7f)
            spider.isDead = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            score.score += 10;
            GetComponent<FMODUnity.StudioEventEmitter>().Play();
            Destroy(gameObject);
        }
    }
}
