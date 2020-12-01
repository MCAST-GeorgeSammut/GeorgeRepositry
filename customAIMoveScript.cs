using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pathfinding;


public class customAIMoveScript : MonoBehaviour
{
    Seeker seeker;

    Path pathToFollow;


    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        seeker = GetComponent<Seeker>();

        seeker.StartPath(transform.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
=======
        Debug.Log(this.name);

        seeker = GetComponent<Seeker>();

        seeker.StartPath(transform.position, target.position, ReadyToMove);
    }
    //when the path is generated this method is called.
    void ReadyToMove(Path p)
>>>>>>> e8c81d31174a76131539fe79ce6ff9a6ae3cf5bd
    {
        Debug.Log("Path complete " + p.error);
        pathToFollow = p;
        StartCoroutine(moveTowardsPath());
    }

    IEnumerator moveTowardsPath()
    {
        foreach(Vector3 position in pathToFollow.vectorPath)
        {
            while(Vector3.Distance(this.transform.position,position)>0.5f)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, position, 1f);
<<<<<<< HEAD
                Debug.Log(position);
=======
                Debug.Log(position);/**/
>>>>>>> e8c81d31174a76131539fe79ce6ff9a6ae3cf5bd
                yield return new WaitForSeconds(0.1f);
            }
        }
        yield return null;
    }

<<<<<<< HEAD
    //can we give the robot a tail, just like in snake?
    /*
     public void drawTail(int length)
    {
        clearTail();

        if (pastPositions.Count>length)
        {
            //nope
            //I do have enough positions in the past positions list
            //the first block behind the player
            int tailStartIndex = pastPositions.Count - 1;
            int tailEndIndex = tailStartIndex - length;
          

            //if length = 4, this should give me the last 4 blocks
            for (int snakeblocks = tailStartIndex;snakeblocks>tailEndIndex;snakeblocks--)
            {
                //prints the past position and its order in the list
                //Debug.Log(pastPositions[snakeblocks].Position + " " + pastPositions[snakeblocks].PositionOrder);

                Debug.Log(snakeblocks);

                pastPositions[snakeblocks].BreadcrumbBox = Instantiate(breadcrumbBox, pastPositions[snakeblocks].Position, Quaternion.identity);

                pastPositions[snakeblocks].BreadcrumbBox.GetComponent<SpriteRenderer>().color = Random.ColorHSV();

                pastPositions[snakeblocks].BreadcrumbBox.GetComponent<SpriteRenderer>().color = snakeColor;
            }

        } 

        if (firstrun)
        {
            
            //I don't have enough positions in the past positions list
            for(int count =length;count>0;count--)
            {
                positionRecord fakeBoxPos = new positionRecord();
                float ycoord = count * -1;
                fakeBoxPos.Position = new Vector3(0f, ycoord);
               // Debug.Log(new Vector3(0f, ycoord));
                //fakeBoxPos.BreadcrumbBox = Instantiate(breadcrumbBox, fakeBoxPos.Position, Quaternion.identity);
                //fakeBoxPos.BreadcrumbBox.GetComponent<SpriteRenderer>().color = Color.yellow;
                pastPositions.Add(fakeBoxPos);

                 


            }
            firstrun = false;
            drawTail(length);
            //Debug.Log("Not long enough yet");
        }

    }
     
     */

    // Update is called once per frame
    void Update()
    {
        
    }
=======
    //Task: can we give the robot a tail, just like we did with snake?



/*
 *  void drawTail(int length)
{
    clearTail();

    if (pastPositions.Count>length)
    {
        //nope
        //I do have enough positions in the past positions list
        //the first block behind the player
        int tailStartIndex = pastPositions.Count - 1;
        int tailEndIndex = tailStartIndex - length;


        //if length = 4, this should give me the last 4 blocks
        for (int snakeblocks = tailStartIndex;snakeblocks>tailEndIndex;snakeblocks--)
        {
            //prints the past position and its order in the list
            //Debug.Log(pastPositions[snakeblocks].Position + " " + pastPositions[snakeblocks].PositionOrder);

            Debug.Log(snakeblocks);

            pastPositions[snakeblocks].BreadcrumbBox = Instantiate(breadcrumbBox, pastPositions[snakeblocks].Position, Quaternion.identity);
            pastPositions[snakeblocks].BreadcrumbBox.GetComponent<SpriteRenderer>().color = snakeColor;

        }

    } 

    if (firstrun)
    {

        //I don't have enough positions in the past positions list
        for(int count =length;count>0;count--)
        {
            positionRecord fakeBoxPos = new positionRecord();
            float ycoord = count * -1;
            fakeBoxPos.Position = new Vector3(0f, ycoord);
           // Debug.Log(new Vector3(0f, ycoord));
            //fakeBoxPos.BreadcrumbBox = Instantiate(breadcrumbBox, fakeBoxPos.Position, Quaternion.identity);
            //fakeBoxPos.BreadcrumbBox.GetComponent<SpriteRenderer>().color = Color.yellow;
            pastPositions.Add(fakeBoxPos);




        }
        firstrun = false;
        drawTail(length);
        //Debug.Log("Not long enough yet");
    }

}


*/

// Update is called once per frame
void Update()
{

}
>>>>>>> e8c81d31174a76131539fe79ce6ff9a6ae3cf5bd
}


