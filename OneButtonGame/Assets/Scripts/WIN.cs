using UnityEngine;

public class WIN : MonoBehaviour
{
    public Deathscreen deathscreen;
    Spider spider;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        spider = player.GetComponent<Spider>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        deathscreen.winScreen = true;
        spider.isDead = true;
    }
}
