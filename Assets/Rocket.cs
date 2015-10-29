using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void Shot()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.down * 15, ForceMode2D.Impulse);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        JellyController player = collision.gameObject.GetComponent<JellyController>();
        // ReSharper disable once UseNullPropagation
        if (player != null)
        {
            player.Hit();
        }
        Destroy(gameObject);
    }
}
