using UnityEngine;
using System.Collections;

public class SequencedRock : MonoBehaviour {

    public Transform firstPoint;
    public Transform secondPoint;

    public float moveSpeed;
    public PlayerController player; // reference player

    private Vector3 currentTarget;


    // Use this for initialization
    void Start()
    {
        currentTarget = firstPoint.position; 
        player = FindObjectOfType<PlayerController>(); // reference player
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.endLevel)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime);

            if (transform.position == firstPoint.position)
            {
                currentTarget = secondPoint.position;
            }
        }

    }
}
