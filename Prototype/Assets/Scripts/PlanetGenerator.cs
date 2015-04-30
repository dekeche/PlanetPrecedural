using UnityEngine;
using System.Collections;

public class PlanetGenerator {

    public int randomSeed;

    public float Generate(GameObject System, float orbitMin = 1.0f, float orbitMax = 20.0f)
    {
        Random.seed = randomSeed;
        GameObject BasePlanet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Planet Script = BasePlanet.AddComponent<Planet>();
        Vector3 temp = new Vector3();

        float radius = Random.Range(0.25f, .75f);
        Vector3 scale = BasePlanet.transform.localScale;
        scale *= radius;
        BasePlanet.transform.localScale = scale;

        float orbitRadius = Random.Range(orbitMin+radius,orbitMax);
        float orbitRate = Random.Range(0.1f,20.0f);
        float rotationRate = Random.Range(0.1f, 20.0f);
        int neg = Random.Range(0, 1);
        int yVal = (neg == 0) ? 1 : -1;
        temp.x = Random.Range(-0.5f, 0.5f);
        temp.y = yVal;
        temp.z = Random.Range(-0.5f, 0.5f);
        Vector3 orbitAxis = temp.normalized;
        temp.x = Random.Range(-0.5f, 0.5f);
        temp.y = yVal;
        temp.z = Random.Range(-0.5f, 0.5f);
        Vector3 rotationAxis = temp.normalized;

        Color planetColor = Color.white;

        BasePlanet.transform.parent = System.transform;
        Script.SetPer(orbitRate, orbitRadius, orbitAxis, rotationRate, rotationAxis, planetColor, System);

        return orbitRadius+radius;
    }
    public float GenerateSun(GameObject System)
    {
        Random.seed = randomSeed;
        GameObject BasePlanet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        BasePlanet.AddComponent<Light>().range = 50;
        Planet Script = BasePlanet.AddComponent<Planet>();
        Vector3 temp = new Vector3();

        float radius = Random.Range(1, 2);
        Vector3 scale = BasePlanet.transform.localScale;
        scale *= radius;
        BasePlanet.transform.localScale = scale;

        float orbitRadius = 0;
        float orbitRate = 0.0f;
        float rotationRate = Random.Range(0.1f, 20.0f);
        int neg = Random.Range(0, 1);
        int yVal = (neg == 0) ? 1 : -1;
        temp.x = Random.Range(-0.5f, 0.5f);
        temp.y = yVal;
        temp.z = Random.Range(-0.5f, 0.5f);
        Vector3 rotationAxis = temp.normalized;
        Vector3 orbitAxis = Vector3.up;

        Color planetColor = Color.white;

        BasePlanet.transform.parent = System.transform;
        Script.SetPer(orbitRate, orbitRadius, orbitAxis, rotationRate, rotationAxis, planetColor, System);

        return radius;
    }

    public float GenerateTwinSun(GameObject System)
    {
        Random.seed = randomSeed;
        GameObject BasePlanet1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        GameObject BasePlanet2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        BasePlanet1.AddComponent<Light>().range = 50;
        BasePlanet2.AddComponent<Light>().range = 50;
        Planet Script1 = BasePlanet1.AddComponent<Planet>();
        Planet Script2 = BasePlanet2.AddComponent<Planet>();
        Vector3 temp = new Vector3();

        float radius = Random.Range(1, 2);
        Vector3 scale = BasePlanet1.transform.localScale;
        scale *= radius;
        BasePlanet1.transform.localScale = scale;
        BasePlanet2.transform.localScale = scale;

        float orbitRadius = Random.Range(radius, 1+radius);
        float orbitRate = Random.Range(0.1f, 20.0f);
        float rotationRate = Random.Range(0.1f, 20.0f);
        int neg = Random.Range(0, 1);
        int yVal = (neg == 0) ? 1 : -1;
        temp.x = Random.Range(-0.5f, 0.5f);
        temp.y = yVal;
        temp.z = Random.Range(-0.5f, 0.5f);
        Vector3 rotationAxis = temp.normalized;
        Vector3 orbitAxis = Vector3.up;

        Color planetColor = Color.white;

        BasePlanet1.transform.parent = System.transform;
        Script1.SetPer(orbitRate, orbitRadius, orbitAxis, rotationRate, rotationAxis, planetColor, System);

        BasePlanet2.transform.parent = System.transform;
        Script2.SetPer(orbitRate, -orbitRadius, orbitAxis, rotationRate, rotationAxis, planetColor, System);
        return orbitRadius;
    }
}
