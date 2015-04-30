using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {

    private float orbitRate;
    private float orbitRadius;
    private Vector3 orbitAxis;

    private float rotationRate;
    private Vector3 rotationAxis;

    private Color planetColor;

    private GameObject SystemCenter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(SystemCenter.transform.position, orbitAxis, orbitRate * Time.deltaTime);
        transform.Rotate(rotationAxis, rotationRate * Time.deltaTime);
	}

    public void SetPer(float ORT,float ORD, Vector3 OAX, float RRT, Vector3 RAX, Color PC, GameObject SC)
    {
        orbitAxis = OAX;
        orbitRadius = ORD;
        orbitRate = ORT;

        rotationRate = RRT;
        rotationAxis = RAX;

        planetColor = PC;
        SystemCenter = SC;

        Vector3 initPos;
        if(orbitAxis.normalized != Vector3.up)
        {
            initPos = Vector3.Cross(Vector3.up, orbitAxis);
            initPos = initPos.normalized * orbitRadius;
        }
        else
        {
            initPos = Vector3.right * orbitRadius;
        }
        transform.position = initPos;

        transform.RotateAround(SystemCenter.transform.position, orbitAxis, orbitRate * Time.time);
        transform.Rotate(rotationAxis, rotationRate * Time.deltaTime * Time.time);
    }
}
