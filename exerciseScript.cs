using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exerciseScript : MonoBehaviour
{
    public List<Transform> waypoints;

    public Transform objectToMove;


    IEnumerator moveMe()
    {
        //for(int counter=0;counter<waypoints.size;counter++)
        foreach(Transform mytransform in waypoints)
        {
            while(Vector3.Distance(objectToMove.position,mytransform.position)>0.1f)
            {
                //1 unit towards the first one
                objectToMove.position = Vector3.MoveTowards(objectToMove.position,
                mytransform.position,1f);

                yield return new WaitForSeconds(0.1f);        
            }
            
            yield return null;
        }
        
        yield return null;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(moveMe());
        }
    }
}
