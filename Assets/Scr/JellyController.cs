using System;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

[Serializable]
public class JellyController : MonoBehaviour
{

    private float _angle;
    private Vector2 _appliedForce;
    private float _timer;

    public GameObject JellyRocketto;

    private float _hp;
    public GameObject loss;

    public GameObject JellHP;

    void Start()
    {
        _hp = 100;
        if(loss == null || JellHP == null) throw new Exception();
    }

    void Update()
    {
        float x = this.transform.position.x, y = this.transform.position.y;
        Vector2 mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        float dx = mouse.x - x, dy = mouse.y - y;
        _angle = (Mathf.Rad2Deg * Mathf.Atan2(dy, dx)) - 90f;

        transform.rotation = Quaternion.Euler(0, 0, _angle);

        if (_hp <= 0)
        {
            Time.timeScale = 0;
            loss.gameObject.SetActive(true);
            JellHP.SetActive(false);
        }
    }

    public void FixedUpdate()
    {
        _timer += Time.fixedDeltaTime;
        if (_timer >= 1f)
        {
            _timer = 0;
            _appliedForce = Quaternion.Euler(0, 0, _angle) * Vector2.up;
            GetComponent<Rigidbody2D>().AddForce(_appliedForce * 3, ForceMode2D.Impulse);
        }
        else if (_timer > 0.3 && _timer < 0.5)
        {
            GetComponent<Rigidbody2D>().AddForce(-_appliedForce * 3, ForceMode2D.Force);
        }
        else if(_timer > 0.5)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    public void Consume()
    {
        DivideAndConquer();
    }

    private void DivideAndConquer()
    {
        Vector2 pos = transform.position;

        GameObject[] a =
        {
            (GameObject) Instantiate(JellyRocketto, pos + Vector2.up, Quaternion.identity),
            (GameObject) Instantiate(JellyRocketto, pos + Vector2.left, Quaternion.identity),
            (GameObject) Instantiate(JellyRocketto, pos + Vector2.right, Quaternion.identity),
            (GameObject) Instantiate(JellyRocketto, pos + Vector2.down, Quaternion.identity)
        };

        foreach (GameObject obj in a)
        {
            obj.GetComponent<SpriteRenderer>().color = new Color(
                Random.value, Random.value, Random.value
                );
            obj.AddComponent<DamageDealer>();
            obj.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 80);
        }
    }

    public void Hit()
    {
        _hp -= 13.5f;
        JellHP.transform.localScale = new Vector3((_hp / 100f) * 5f, 0.1f, 1);
    }
}
