using UnityEngine;

public class MonoBehaviourScript1: MonoBehaviour
{
    public float hiz = 10f;

    void Update()
    {
        transform.Translate(Vector2.right * hiz * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject); // ekran dýþýna çýkýnca yok olsun
    }

}
