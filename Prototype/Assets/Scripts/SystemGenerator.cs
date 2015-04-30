using UnityEngine;
using System.Collections;

public class SystemGenerator {

    public int randomSeed;
    PlanetGenerator[] planets;

    public void Generate(GameObject System)
    {
        Random.seed = randomSeed;

        int twinSun = 1;//Random.Range(0,1);

        planets = new PlanetGenerator[5];
        for(int i = 0; i < planets.Length; i++)
        {
            planets[i] = new PlanetGenerator();
            planets[i].randomSeed = (int)Random.Range(int.MinValue,int.MaxValue);
        }

        float minRange = 0.0f;
        float maxRange = 2.0f;

        PlanetGenerator sunGenerator = new PlanetGenerator();
        if(twinSun == 1)
        {
            minRange += sunGenerator.GenerateTwinSun(System);
            maxRange = minRange + 2.0f;
        }
        else
        {
            minRange += sunGenerator.GenerateSun(System);
            maxRange = minRange + 2.0f;
        }

        for (int i = 0; i < planets.Length; i++)
        {
            minRange += planets[i].Generate(System, minRange, maxRange);
            maxRange = minRange + 2.0f;
        }
    }
}
