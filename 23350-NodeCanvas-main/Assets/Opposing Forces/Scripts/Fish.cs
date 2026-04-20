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

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == detectVolume)
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
        if (collision.gameObject == player)
        {
            playerCollision = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == detectVolume)
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
        if (collision.gameObject == player)
        {
            playerCollision = false;
        }
    }
}
