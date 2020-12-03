using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Pathfinding;


public class customAIMoveScript : MonoBehaviour
{
    Seeker seeker;

    Path pathToFollow;

    snakeGenerator snakeGen;

    List<positionRecord> pastPositions;

    int positionorder = 0;

    int snakeLength = 4;

    bool firstrun = true;

    public Transform target;

    GameObject breadcrumbBox, pathParent;

    int pastpositionslimit = 100;

    // Start is called before the first frame update
    void Start()
    {
        pathParent = new GameObject();

        pathParent.transform.position = new Vector3(0f, 0f);

        pathParent.name = "Path Parent";

        seeker = GetComponent<Seeker>();

        seeker.StartPath(transform.position, target.position, OnPathComplete);

        pastPositions = new List<positionRecord>();

        breadcrumbBox = Resources.Load<GameObject>("Prefabs/Square");

    }

    void OnPathComplete(Path p)
    {

        Debug.Log(this.name);

        seeker = GetComponent<Seeker>();

        seeker.StartPath(transform.position, target.position, ReadyToMove);
    }

    //when the path is generated this method is called.
    void ReadyToMove(Path p)
    {
        Debug.Log("Path complete " + p.error);
        pathToFollow = p;
        StartCoroutine(moveTowardsPath());
    }

    IEnumerator moveTowardsPath()
    {
        foreach (Vector3 position in pathToFollow.vectorPath)
        {
            while (Vector3.Distance(this.transform.position, position) > 0.5f)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, position, 1f);

                savePosition();
                drawTail(snakeLength);

                Debug.Log(position);

                yield return new WaitForSeconds(0.1f);
            }
        }
        yield return null;
    }


    //can we give the robot a tail, just like in snake?

    public bool boxExists(Vector3 positionToCheck)
    {
        //foreach position in the list

        foreach (positionRecord p in pastPositions)
        {

            if (p.Position == positionToCheck)
            {
                Debug.Log(p.Position + "Actually was a past position");
                if (p.BreadcrumbBox != null)
                {
                    Debug.Log(p.Position + "Actually has a red box already");
                    //this breaks the foreach so I don't need to keep checking
                    return true;
                }
            }
        }

        return false;
    }



    public void savePosition()
    {
        positionRecord currentBoxPos = new positionRecord();

        currentBoxPos.Position = this.transform.position;
        positionorder++;
        currentBoxPos.PositionOrder = positionorder;

        if (!boxExists(this.gameObject.transform.position))
        {
            currentBoxPos.BreadcrumbBox = Instantiate(breadcrumbBox, this.gameObject.transform.position, Quaternion.identity);

            currentBoxPos.BreadcrumbBox.transform.SetParent(pathParent.transform);

            currentBoxPos.BreadcrumbBox.name = positionorder.ToString();

            currentBoxPos.BreadcrumbBox.GetComponent<SpriteRenderer>().color = Color.red;

            currentBoxPos.BreadcrumbBox.GetComponent<SpriteRenderer>().sortingOrder = -1;
        }

        pastPositions.Add(currentBoxPos);
        Debug.Log("Have made this many moves: " + pastPositions.Count);

    }

    public void cleanList()
    {
        for (int counter = pastPositions.Count - 1; counter > pastPositions.Count; counter--)
        {
            pastPositions[counter] = null;
        }
    }

    public void clearTail()
    {
        cleanList();
        foreach (positionRecord p in pastPositions)
        {
            // Debug.Log("Destroy tail" + pastPositions.Count);
            Destroy(p.BreadcrumbBox);
        }
    }

    public void drawTail(int length)
    {
        clearTail();

        if (pastPositions.Count > length)
        {
            //nope
            //I do have enough positions in the past positions list
            //the first block behind the player
            int tailStartIndex = pastPositions.Count - 1;
            int tailEndIndex = tailStartIndex - length;


            //if length = 4, this should give me the last 4 blocks
            for (int snakeblocks = tailStartIndex; snakeblocks > tailEndIndex; snakeblocks--)
            {
                //prints the past position and its order in the list
                //Debug.Log(pastPositions[snakeblocks].Position + " " + pastPositions[snakeblocks].PositionOrder);

                Debug.Log(snakeblocks);

                pastPositions[snakeblocks].BreadcrumbBox = Instantiate(breadcrumbBox, pastPositions[snakeblocks].Position, Quaternion.identity);
                pastPositions[snakeblocks].BreadcrumbBox.GetComponent<SpriteRenderer>().color = Color.red;

            }

        }

        if (firstrun)
        {

            //I don't have enough positions in the past positions list
            for (int count = length; count > 0; count--)
            {
                positionRecord fakeBoxPos = new positionRecord();
                float ycoord = count * -1;
                fakeBoxPos.Position = this.transform.position + new Vector3(0f, ycoord);
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

    public bool hitTail(Vector3 headPosition, int length)
    {
        int tailStartIndex = pastPositions.Count - 1;
        int tailEndIndex = tailStartIndex - length;

        //I am checking all the positions in the tail of the snake
        for (int snakeblocks = tailStartIndex; snakeblocks > tailEndIndex; snakeblocks--)
        {
            if ((headPosition == pastPositions[snakeblocks].Position) && (pastPositions[snakeblocks].BreadcrumbBox != null))
            {
                //  Debug.Log("Hit Tail");
                return true;
            }
        }


        return false;

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}



