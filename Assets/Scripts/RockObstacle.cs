using UnityEngine;
using System.Collections;

public class RockObstacle : MonoBehaviour {

    public Transform startPoint;
    public Transform endPoint;

    public float moveSpeed;
    public PlayerController player;

    private Vector3 currentTarget;


	// Use this for initialization
	void Start () {
        currentTarget = endPoint.position;
        player = FindObjectOfType<PlayerController>();
	}

    // Update is called once per frame
    void Update()
    {
        if (!player.endLevel)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, moveSpeed * Time.deltaTime);

            if (transform.position == endPoint.position)
            {
                currentTarget = startPoint.position;
            }

            if (transform.position == startPoint.position)
            {
                currentTarget = endPoint.position;
            }
        }

    }
}
