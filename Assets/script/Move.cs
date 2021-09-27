using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float movespeed;
    // Start is called before the first frame update

    private Vector3[] setPositions;

    public Transform parentPosition;

    public int currpoint;

    void Start()
    {
        setPositions = new Vector3[parentPosition.childCount];

        for (int i = 0; i < parentPosition.childCount; i++)
        {
            setPositions[i] = parentPosition.GetChild(i).position;
        }
        currpoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, setPositions[currpoint], Time.deltaTime * movespeed);
        if (transform.position == setPositions[currpoint])
        {
            Vector3 prePosition = setPositions[currpoint];
            currpoint++;
            if (currpoint >= setPositions.Length)
            {
                currpoint = 0;
            }
            Vector3 nowPosition = setPositions[currpoint];
            mosterDir(prePosition, nowPosition);
        }

    }
    private void mosterDir(Vector3 prePosition, Vector3 nowPosition)
    {
        float dirx = nowPosition.x - prePosition.x;
        float diry = nowPosition.y - prePosition.y;
        GetComponent<Animator>().SetFloat("DIRX", dirx);
        GetComponent<Animator>().SetFloat("DIRY", diry);
    }
}
