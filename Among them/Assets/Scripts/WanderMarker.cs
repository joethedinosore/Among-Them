using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderMarker : MonoBehaviour
{
    public Vector2 xRange, zRange;
    public LayerMask layerMask;
    public GameObject parentObject;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == parentObject)
        {
            transform.position = checkGround();
            parentObject.GetComponent<WanderAI>().updateTarget();
        }
    }

    private Vector3 checkGround()
    {
        float x = Random.Range(xRange.x, xRange.y);
        float y = Random.Range(zRange.x, zRange.y);

        Vector3 newPoz = new Vector3(x, 1, y);

        RaycastHit hit;

        if (Physics.Raycast(newPoz, Vector3.down, out hit, Mathf.Infinity, layerMask))
        {
            return (newPoz);
        }
        else
        {
            return (checkGround());
        }
    }
}
