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
        transform.position = clamPoint.position; //starts in the clam
    }

    void Update()
    {
        if (transform.position.y < 0) //in case it ever clips below the map gets put back at floor level
        {
            Vector3 temp = transform.position;
            temp.y = 1;
            transform.position = temp;
        }
        if (state == 0)
        {
            transform.position = clamPoint.position; //in the clam state, is set to inside the clam
        }
        if ( state == 1)
        {
            GetComponent<Rigidbody>().isKinematic = true; //in the player state, is set in the player's hands and stops colliding
            transform.position = playerPoint.position;
            if (Input.GetKeyDown(KeyCode.E)) //player can drop the pearl by pressing e again if they want to for some reason
            {
                DropPearl();
            }
        }
        else if (state == 2)
        {
            outline.SetActive(false);
            GetComponent<Rigidbody>().isKinematic = true; //in the player state, is set in the fish's mouth and stops colliding
            transform.position = fishPoint.position;
        }
        else if (Vector3.Distance(player.transform.position, transform.position) <= 3) //if it has either been dropped or inside the clam, and the player gets close enough, enables outline
        {
            outline.SetActive(true);
            outline.transform.LookAt(player.transform); //billboards towards the player cause idk a better way to do this
            if (Input.GetKeyDown(KeyCode.E)) //outline indicates that the player can now pick up the pearl when pressing E
            {
                player.GetComponent<PlayerController>().hasPearl = true; //when grabbing the pearl, sets it to the player state and shrinks it to look better in the player's hands
                GetComponent<Collider>().enabled = false;
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                state = 1;
                outline.SetActive(false); //disables the outline when holding it cause annoying
            }
        }
        else
        {
            outline.SetActive(false);
        }

    }

    public void DropPearl() //drops the pearl, resetting its size, putting it in the "free" state, and sets collision back on so it doesnt fall through the floor
    {
        state = 3;
        GetComponent<Collider>().enabled = true;
        transform.localScale = Vector3.one;
        GetComponent<Rigidbody>().isKinematic = false;
    }

    public int GetState() //for getting the state outside of this script
    {
        return state;
    }
    public void SetState(int newState) //for setting the state outside of this script
    {
        state = newState;
        if (state == 2) //fish state, stops colliding
        {
            GetComponent<Collider>().enabled = false;
        }
        if (state == 0) //clam state, resets position in clam
        {
            transform.position = clamPoint.position;
        }
        return;
    }
}
