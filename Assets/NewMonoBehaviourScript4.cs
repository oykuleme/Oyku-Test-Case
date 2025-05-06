using UnityEngine;

public class MonoBehaviourScript4 : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        StartCoroutine(FlashRed());

        if (currentHealth <= 0)
        {
            Destroy(gameObject); // düþman ölür
        }
    }

    private System.Collections.IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);  // 0.1 saniye kýrmýzý kal
        spriteRenderer.color = Color.white;
    }
}
