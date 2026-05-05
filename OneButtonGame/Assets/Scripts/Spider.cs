using UnityEngine;

public class Spider : MonoBehaviour
{
    Rigidbody2D rb;
    Web web;
    public bool attached = true;
    bool reAttaching = false;
    public GameObject ceiling;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        web = GetComponentInChildren<Web>();
    }

    void Update()
    {
        if (attached && Input.GetKey(KeyCode.Space) && transform.position.y > -3.75)
        {
            transform.position -= new Vector3(0, 0.005f, 0);
        }

        if (!attached)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                reattach();
            }
        }

        if (reAttaching)
        {
            transform.position += new Vector3(0, 0.02f, 0);
            if (transform.position.y > 3.999f)
            {
                reAttaching = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<FMODUnity.StudioEventEmitter>().Play();
        }
    }

    void reattach()
    {
        attached = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        web.spriteEnabled = true;
        reAttaching = true;
    }
}
