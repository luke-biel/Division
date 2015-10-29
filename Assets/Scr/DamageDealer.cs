using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Boss>() != null)
        {
            other.gameObject.GetComponent<Boss>().DealDamage();
            Destroy(gameObject);
        }
        if (other.gameObject.GetComponent<Rocket>() != null)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
