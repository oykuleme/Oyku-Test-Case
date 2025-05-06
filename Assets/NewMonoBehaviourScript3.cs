using UnityEngine;
using UnityEngine.UI;

public class MonoBehaviourScript3 : MonoBehaviour
{
    public Slider healthBar;
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        healthBar.value = currentHealth;

        if (currentHealth <= 0f)
        {
            Destroy(gameObject); // düþmaný sil
        }
    }


}
