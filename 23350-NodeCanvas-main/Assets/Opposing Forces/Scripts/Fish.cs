using UnityEngine;

public class Fish : MonoBehaviour
{
    public GameObject detectVolume, ramVolume, player;
    public bool tracking, ramRange, playerCollision;
    void Start()
    {
        tracking = false;
        ramRange = false;
        playerCollision = false;
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == detectVolume) //tracks if the fish has entered the detection range, and/or ram range
        {
            tracking = true;
        }
        if (other.gameObject == ramVolume)
        {
            ramRange = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player) //tracks if fish is making contact with player
        {
            playerCollision = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == detectVolume) //tracks if the fish has exited the detection range, and/or ram range
        {
            tracking = false;
        }
        if (other.gameObject == ramVolume)
        {
            ramRange = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == player) //tracks if fish is no longer making contact with player
        {
            playerCollision = false;
        }
    }
}
