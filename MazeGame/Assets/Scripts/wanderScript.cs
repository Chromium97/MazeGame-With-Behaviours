using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wanderScript : MonoBehaviour
{
    public GameObject wanderTarget;

    [SerializeField]
    public int wanderX1;
    public int wanderX2;

    public int wanderY1;
    public int wanderY2;


    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("NextWaypoint", 1.0f, 5f);

    }

    private void NextWaypoint()
    {

        Vector3 wan = new Vector3(Random.Range(wanderX1, wanderX2), 1, Random.Range(wanderY1, wanderY2));
        wanderTarget.transform.position = wan;

    }


    // Update is called once per frame
    void Update()
    {

    }

}
