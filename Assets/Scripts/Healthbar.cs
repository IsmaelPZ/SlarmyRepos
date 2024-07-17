using UnityEngine;
using UnityEngine.UI;


public class Healthbar : MonoBehaviour
{

    public Slider healthSlider;


    public void SetMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    public void SetHealth(int health)
    {
    healthSlider.value = health;
    }
}
