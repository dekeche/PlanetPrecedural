using UnityEngine;
using System.Collections;

public class MainGenerator : MonoBehaviour {

    SystemGenerator[] systems;

    private int randomSeed = 50;
    public int currentSystem = 0;
    GameObject System;
	// Use this for initialization
	void Start () {
        Generate();
	}
	
	// Update is called once per frame
	void Update () {
	
        if(Input.GetKeyDown("space"))
        {
            currentSystem++;
            if(currentSystem >= systems.Length)
            {
                currentSystem = 0;
            }
            Destroy(System);
            System = new GameObject("Test GameObject");
            systems[currentSystem].Generate(System);
        }
	}


    void Generate()
    {
        Random.seed = randomSeed;
        System = new GameObject("Test GameObject");
        systems = new SystemGenerator[5];
        for(int i = 0; i < systems.Length; i++)
        {
            systems[i] = new SystemGenerator();
            systems[i].randomSeed = (int)Random.Range(int.MinValue, int.MaxValue);
        }
        systems[0].Generate(System);
    }
}
