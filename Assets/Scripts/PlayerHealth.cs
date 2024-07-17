using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    public int maxHealth = 5;
    [SerializeField]
    public int currentHealth = 5;
    [SerializeField]
    private bool isBlinking = false;

    public Collider2D playerCollider;
    private bool isImmune = false;
    private float ImmunityDuration = 2f;
    private float immunityTimeLeft = 0f;
    private Healthbar healthbar;
    public SpriteRenderer playerSprite;

    public AudioClip ouch;

    private void Start()
    {
        healthbar = GetComponent<Healthbar>();
        healthbar.SetMaxHealth(maxHealth);
        healthbar.SetHealth(currentHealth);
    }
    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            PlayerDeath();
        }

        if (isImmune)
        {
           

            immunityTimeLeft -= Time.deltaTime;
            if (immunityTimeLeft <= 0f)
            {
                isImmune = false;
                Blinking(false);
                isBlinking = false;
            }
        }
        if (isBlinking)
        {
            Blinking(Mathf.Sin(10 * Time.time) > 0);
            playerCollider.enabled = false;
        }
        if (!isBlinking)
        {
            playerSprite.enabled = true;
            playerCollider.enabled = true;
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isImmune)
        {
            currentHealth -= damage;
            currentHealth = Mathf.Max(currentHealth, 0);
            isBlinking = true;
            isImmune = true;
            immunityTimeLeft = ImmunityDuration;
            healthbar.SetHealth(currentHealth);
            AudioSource.PlayClipAtPoint(ouch, transform.position);
        }
    }

    public void AddHealth(int amountToAdd)
    {
        if(currentHealth == maxHealth)
        {
            return;
        }

        currentHealth -= amountToAdd;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    void PlayerDeath()
    {
            Object.Destroy(gameObject, 2);
            Timer.scoreNum = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   public void Blinking(bool on)
    {
        playerSprite.enabled = on;
    }
}
