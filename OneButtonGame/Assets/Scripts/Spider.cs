using UnityEngine;

public class Spider : MonoBehaviour
{
    Rigidbody2D rb;
    Web web;

    [Header("Spider movement")]
    public float descendSpeed;
    public float reattachSpeed;
    float timeToAscend = 1f;

    [Header("DO NOT TOUCH")]
    public bool attached = true;
    bool reAttaching = false;
    public bool isDead = false;
    bool webCreated = false;
    float reattachTimer;
    bool hitCeiling = false;

    public GameObject floorCollider;
    public float previousY;
    public float currentY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        web = GetComponentInChildren<Web>();
    }

    void Update()
    {
        transform.eulerAngles = Vector3.zero;

        currentY = transform.position.y;

        if (transform.position.x < -5.3f)
            isDead = true;

        if (isDead)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            if (floorCollider != null)
                Destroy(floorCollider);
            return;
        }

        if (attached && Input.GetKey(KeyCode.Space) && transform.position.y > -3.75 && !reAttaching)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            transform.position -= new Vector3(0, descendSpeed * 2.5f * Time.deltaTime, 0);
            timeToAscend = 1f;
        }
        else if (attached && transform.position.y < 3.999f && !reAttaching)
        {
            timeToAscend -= Time.deltaTime;
            if (timeToAscend <= 0)
            {
                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.gravityScale = -0.5f;
                //transform.position += new Vector3(0, 0.5f * Time.deltaTime, 0);
            }
        }

        if (!attached)
        {
            webCreated = false;
            reAttaching = false;
            rb.gravityScale = 1;
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                reattach();
            }
        }

        if (reAttaching && currentY == previousY)
        {
            reattachTimer -= Time.deltaTime;
            if (reattachTimer <= 0)
            {
                Debug.Log("hit ceiling");
                hitCeiling = true;
            }
        }
        else
            reattachTimer = 0.05f;

        if (reAttaching)
        {
            //transform.position += new Vector3(0, reattachSpeed * 10 * Time.deltaTime, 0);
            rb.gravityScale = -1;
            if (transform.position.y > 3.999f || hitCeiling)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                reAttaching = false;
                webCreated = false;
                hitCeiling = false;
            }
        }

        previousY = transform.position.y;

        if (Input.GetKeyDown(KeyCode.Space) && !webCreated)
        {
            GetComponent<FMODUnity.StudioEventEmitter>().Play();
            webCreated = true;
        }
    }


    void reattach()
    {
        attached = true;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        web.spriteEnabled = true;
        reAttaching = true;
    }
}
