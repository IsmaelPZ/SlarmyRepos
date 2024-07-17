using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    public float _speed = 10f;
    private Rigidbody2D rb;
    private Animator myAnim;

    public ArrowSpawner arrowSpawner;

    public AudioClip LVLUP;

    private float fireRate = 0.80f; // Time in seconds between each arrow spawn
    private float nextFireTime = 0f;
    private float timeElapsed;


    private int lastTriggeredScore = 0;

     private new Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        camera = Camera.main;
    }


    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 dir = new Vector2(h, v);
        rb.velocity = dir.normalized * _speed;

        myAnim.SetFloat("Horizontal", h);
        myAnim.SetFloat("Horizontal", h);
        myAnim.SetFloat("Vertical", v);
        myAnim.SetFloat("Vertical", v);

        PreventPlayerGoingOffScreen();
    }

    private void PreventPlayerGoingOffScreen()
    {
        Vector2 screenPosition = camera.WorldToScreenPoint(transform.position);

        if ((screenPosition.x < 0 && rb.velocity.x < 0) ||
           (screenPosition.x > camera.pixelWidth && rb.velocity.x > 0))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if ((screenPosition.y < 0 && rb.velocity.y < 0) ||
           (screenPosition.y > camera.pixelHeight && rb.velocity.y > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }


    public void shootArrow()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            arrowSpawner.spawnArrows();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Update()
    {
        shootArrow();

        timeElapsed += Time.deltaTime;

        int currentScore = Timer.scoreNum;

        if (currentScore >= 75 && lastTriggeredScore < 75)
        {
            fireRate = 0.60f;
            PlayLevelUpAudio();
            lastTriggeredScore = 75;
        }
        else if (currentScore >= 150 && lastTriggeredScore < 150)
        {
            fireRate = 0.50f;
            PlayLevelUpAudio();
            lastTriggeredScore = 150;
        }
        else if (currentScore >= 225 && lastTriggeredScore < 225)
        {
            fireRate = 0.40f;
            PlayLevelUpAudio();
            lastTriggeredScore = 225;
        }
        else if (currentScore >= 300 && lastTriggeredScore < 300)
        {
            fireRate = 0.30f;
            PlayLevelUpAudio();
            lastTriggeredScore = 300;
        }
        else if (currentScore >= 375 && lastTriggeredScore < 375)
        {
            fireRate = 0.25f;
            PlayLevelUpAudio();
            lastTriggeredScore = 375;
        }
        else if (currentScore >= 450 && lastTriggeredScore < 450)
        {
            fireRate = 0.225f;
            PlayLevelUpAudio();
            lastTriggeredScore = 450;
        }
        else if (currentScore >= 525 && lastTriggeredScore < 525)
        {
            fireRate = 0.20f;
            PlayLevelUpAudio();
            lastTriggeredScore = 525;
        }
        else if (currentScore >= 600 && lastTriggeredScore < 600)
        {
            fireRate = 0.175f;
            PlayLevelUpAudio();
            lastTriggeredScore = 600;
        }
        else if (currentScore >= 675 && lastTriggeredScore < 675)
        {
            fireRate = 0.125f;
            PlayLevelUpAudio();
            lastTriggeredScore = 675;
        }
        else if (currentScore >= 750 && lastTriggeredScore < 750)
        {
            fireRate = 0.10f;
            PlayLevelUpAudio();
            lastTriggeredScore = 750;
        }
    }
    private void PlayLevelUpAudio()
    {
        AudioSource.PlayClipAtPoint(LVLUP, transform.position, 1f);
    }
}