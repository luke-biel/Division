using UnityEngine;

public class FoodEffect : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        JellyController ogo = other.gameObject.GetComponent<JellyController>();
        if (ogo == null) return;

        ogo.Consume();
        Destroy(gameObject);
    }
}
