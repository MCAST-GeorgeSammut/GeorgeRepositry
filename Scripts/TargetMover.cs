using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour
{

    IEnumerator MoveTarget()
    {
        for(int steps=0; steps<9;steps++)
        {
            this.gameObject.transform.position += new Vector3(0f, 1f);

            yield return new WaitForSeconds(1f);
            
            
        }

        for (int stepsX = 0; stepsX <14; stepsX++)
        {
            this.gameObject.transform.position -= new Vector3(1f, 0f);

            yield return new WaitForSeconds(1f);


        }

        yield return null;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(MoveTarget());
        } 
    }



}
