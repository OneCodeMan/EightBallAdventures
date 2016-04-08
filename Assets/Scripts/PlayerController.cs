using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Vector3 screenPoint;
    private Vector3 offset;

    private bool _isDragging;

    private Vector3 startPosition;

    public bool endLevel;
    public bool onTrigger;

    public RockObstacle rock;

    public GameObject gameOverScreen;

    public GameObject BlockPopup;
    public GameObject BlockRemove;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
        gameOverScreen.SetActive(false);
        endLevel = false;
        onTrigger = false;
        BlockPopup.SetActive(false);
        rock = FindObjectOfType<RockObstacle>();
    }
	
	// Update is called once per frame
	void Update () {

        if (!endLevel)
        {
            if (_isDragging)
            {
                Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
                Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
                transform.position = curPosition;
            }
        }

    }

    void OnMouseDown()
    {
        if (!_isDragging)
        {
            screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            _isDragging = true;
        }
        else
        {
            _isDragging = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Block")
        {
            Destroy(gameObject);
            Application.LoadLevel(Application.loadedLevel); //restart
        }

        if (other.tag == "Checkpoint")
        {
            endLevel = true;
            gameOverScreen.SetActive(true);

            rock.moveSpeed = 0f;

        }

        if (other.tag == "Trigger")
        {
            onTrigger = true;
            DestroyObject(other.gameObject);
            BlockPopup.SetActive(true);
        }

        if (other.tag == "GoodTrigger")
        {
            onTrigger = true;
            DestroyObject(other.gameObject);
            BlockRemove.SetActive(false);
        }
    }


}
