using UnityEngine;

public class MonoBehaviourScript2 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform atisNoktasi; // namlu ucu gibi bir boþ nesne
    public float atesSikligi = 0.5f;
    private float atesZamani = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > atesZamani)
        {
            Instantiate(bulletPrefab, atisNoktasi.position, atisNoktasi.rotation);
            atesZamani = Time.time + atesSikligi;
        }
    }
}
