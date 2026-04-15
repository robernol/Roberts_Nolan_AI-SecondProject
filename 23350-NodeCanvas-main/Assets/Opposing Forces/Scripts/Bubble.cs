using UnityEngine;

public class Bubble : MonoBehaviour
{
    Vector3 aim;
    public GameObject player;
    public float time, speed;
    float timer;

    void Start()
    {
        Vector3 offset = transform.position;
        offset.x += Random.Range(-1f, 1f);
        offset.y += Random.Range(-1f, 1f);
        transform.position = offset;

        float randScale = Random.Range(0.5f, 1.5f);
        transform.localScale += new Vector3(randScale, randScale, randScale);

        player = Camera.main.gameObject;
        aim = player.transform.position;
        aim.x += Random.Range(-10f, 10f);
        aim.y += Random.Range(-10f, 10f);
        timer = Time.time + time;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position + (aim - transform.position).normalized * Time.deltaTime * speed;
        transform.position = temp;
        //transform.position = Vector3.Lerp(pos, aim, 0.1f * Time.deltaTime);

        if (Time.time > timer)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<Rigidbody>().AddForce((collision.gameObject.transform.position - transform.position).normalized * 1000);
        Destroy(gameObject);
    }
}
