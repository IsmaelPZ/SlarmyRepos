using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHP : MonoBehaviour
{

    /*************************BOSSHP**************************/
    [SerializeField]
    public int maxHealth = 10;
    [SerializeField]
    public int currentHealth = 10;
    private float SceneDelay = 3;

    public AudioClip winSound;

    public new Renderer renderer;
    private Color initialColor;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);
        UpdateColor();

    }

    private void Start()
    {
        currentHealth = maxHealth;
        renderer = GetComponent<Renderer>();
        initialColor = renderer.material.color;
    }
    // Update is called once per frame
    void Update()
    {

        if (currentHealth <= 0)
        {
            BossDeath();
        }
    }

    void BossDeath()
    {
        gameObject.SetActive(false);
        AudioSource.PlayClipAtPoint(winSound, transform.position, 1f);
        Invoke("LoadNextLevel", SceneDelay);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            TakeDamage(1);
        }
    }
    private void UpdateColor()
    {
        
        float colorFactor = (float)currentHealth / maxHealth;
        Color newColor = new Color(initialColor.r * colorFactor, initialColor.g * colorFactor, initialColor.b * colorFactor, initialColor.a);
        renderer.material.color = newColor;
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(3);
    }
}
