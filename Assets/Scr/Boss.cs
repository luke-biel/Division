using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Boss : MonoBehaviour
{
    public int _hp;
    public Transform hpRef;
    public GameObject greet;

    public GameObject Rocket;

    private float _timer;
    
	void Start ()
	{
        if(hpRef == null) throw new Exception();
	    _hp = 100;
	    _timer = 0;
	}

    void Update()
    {
        _timer += Time.deltaTime;

        if (_hp <= 0)
        {
            Time.timeScale = 0;
            greet.gameObject.SetActive(true);
            hpRef.gameObject.SetActive(false);
        }

        if (_timer > 4)
        {
            _timer = 0;
            int rand = Random.Range(1, 6);
            switch (rand)
            {
                case 1:
                    SalveOne();
                    break;
                case 2:
                    SalveTwo();
                    break;
                case 3:
                    SalveThree();
                    break;
                case 4:
                    SalveFour();
                    break;
                case 5:
                    SalveFive();
                    break;
            }
        }
    }

    public void DealDamage()
    {
        _hp -= 1;
        hpRef.transform.localScale = (new Vector3(10f * (_hp / 100f), 0.2f, 1f));
    }

    public void SalveOne()
    {
        for (int i = -6; i < 7; i+=2)
        {
            Instantiate(Rocket, new Vector2(i, 4), Quaternion.identity);
        }
    }

    public void SalveTwo()
    {
        for (float i = -5; i < 6; i += 2)
        {
            Instantiate(Rocket, new Vector2(i, 4), Quaternion.identity);
        }
    }

    public void SalveThree()
    {
        for (float i = -7; i < 8; i += 1)
        {
            if(Math.Abs(i % 3) > 0)
                Instantiate(Rocket, new Vector2(i, 4), Quaternion.identity);
        }
    }

    public void SalveFour()
    {
        for (float i = -6; i < 7; i += 1f)
        {
            Instantiate(Rocket, new Vector2(i, Mathf.Sin(i) + 2), Quaternion.identity);
        }
    }

    public void SalveFive()
    {
        for (float i = -5; i < 6; i += 1f)
        {
            Instantiate(Rocket, new Vector2(i, 9 + Mathf.Abs(i)), Quaternion.identity);
        }
    }
}
