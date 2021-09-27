using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterAi : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;

    private Vector3[] setPositions;

    public Transform parentPosition;

    public int currpoint;

    public int level;

    public float timer = 2.0f;

    void Start()
    {
        setPositions = new Vector3[parentPosition.childCount];

        for (int i = 0; i < parentPosition.childCount; i++)
        {
            setPositions[i] = parentPosition.GetChild(i).position;
        }
        currpoint = 0;
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, setPositions[currpoint], Time.deltaTime * moveSpeed);
        if (transform.position == setPositions[currpoint]) 
        {
            Vector3 prePosition = setPositions[currpoint];
            currpoint++;
            if (currpoint >= setPositions.Length) 
            {
                    currpoint = 0;
            }
            Vector3 nowPosition = setPositions[currpoint];
            if (currpoint >= setPositions.Length % 2) 
            {
                if (level == 1)
                {
                    mosterDir(prePosition, nowPosition);
                    level--;
                }
                else
                {
                    GetComponent<Animator>().SetFloat("M_change", 1);
                    level++;
                }
            }


        }
       
    }

    private void mosterDir(Vector3 prePosition,Vector3 nowPosition) 
    {
        float dirx = nowPosition.x - prePosition.x;
        float diry = nowPosition.y - prePosition.y;
        GetComponent<Animator>().SetFloat("DIRX", dirx); 
        GetComponent<Animator>().SetFloat("DIRY", diry);
    }
}
