using UnityEngine;

public class Pearl : MonoBehaviour
{
    public GameObject outline, player;
    public Transform clamPoint, playerPoint, fishPoint;
    int state; //0 means in clam, 1 means on player, 2 means on fish, 3 means free floating
    void Start()
    {
        state = 0;
        outline.SetActive(false);
        transform.position = clamPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0)
        {
            Vector3 temp = transform.position;
            temp.y = 1;
            transform.position = temp;
        }
        if (state == 0)
        {
            transform.position = clamPoint.position;
        }
        if ( state == 1)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.position = playerPoint.position;
            if (Input.GetKeyDown(KeyCode.E))
            {
                DropPearl();
            }
        }
        else if (state == 2)
        {
            outline.SetActive(false);
            GetComponent<Rigidbody>().isKinematic = true;
            transform.position = fishPoint.position;
        }
        else if (Vector3.Distance(player.transform.position, transform.position) <= 3)
        {
            outline.SetActive(true);
            outline.transform.LookAt(player.transform);
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.GetComponent<PlayerController>().hasPearl = true;
                GetComponent<Collider>().enabled = false;
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                state = 1;
                outline.SetActive(false);
            }
        }
        else
        {
            outline.SetActive(false);
        }

    }

    public void DropPearl()
    {
        state = 3;
        GetComponent<Collider>().enabled = true;
        transform.localScale = Vector3.one;
        GetComponent<Rigidbody>().isKinematic = false;
    }

    public int GetState()
    {
        return state;
    }
    public void SetState(int newState)
    {
        state = newState;
        if (state == 2)
        {
            GetComponent<Collider>().enabled = false;
        }
        if (state == 0)
        {
            transform.position = clamPoint.position;
        }
        return;
    }
}
