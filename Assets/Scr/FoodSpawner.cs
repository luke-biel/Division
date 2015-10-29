using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class FoodSpawner : MonoBehaviour
{
    public GameObject food;
    private float _timer;

    void Awake()
    {
        Screen.fullScreen = false;
    }

	void Start ()
    {
	    if(food == null) throw new Exception();
	}
	
	void Update ()
	{
	    _timer += Time.deltaTime;
	    if (_timer > 3.5f)
	    {
	        Spawn();
	        _timer = 0;
	    }

        if(Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
	}

    private void Spawn()
    {
        Instantiate(food, new Vector2((Random.value*9) - 4.5f, (Random.value*-4.5f)), Quaternion.identity);
    }
}
