using UnityEngine;

public class Bubble : MonoBehaviour
{
    Vector3 aim;
    public GameObject player;
    public float time, speed;
    float timer;

    void Start()
    {
        Vector3 offset = transform.position; //creates a random offset vector so that the starting position is varied
        offset.x += Random.Range(-1f, 1f);
        offset.y += Random.Range(-1f, 1f);
        transform.position = offset;

        float randScale = Random.Range(0.5f, 1.5f); //variance in scale
        transform.localScale += new Vector3(randScale, randScale, randScale);

        player = Camera.main.gameObject; //creates another random ofset vector based on player position, so the bubbles aren't in a straight line
        aim = player.transform.position;
        aim.x += Random.Range(-10f, 10f);
        aim.y += Random.Range(-10f, 10f);
        timer = Time.time + time;
    }

    void Update()
    {
        Vector3 temp = transform.position + (aim - transform.position).normalized * Time.deltaTime * speed; //moves at a constant speed towards the player's position with offset
        transform.position = temp;

        if (Time.time > timer) //after the time elapses, pops on its own
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().AddForce((collision.gameObject.transform.position - transform.position).normalized * 1000);
        Destroy(gameObject); //if it hits a rigidbody, adds a force and then "pops"
    }
}
