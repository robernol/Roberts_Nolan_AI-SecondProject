using NodeCanvas.Tasks.Actions;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject pearl;
    public Vector3 vel, acc;
    bool colliding;
    public bool hasPearl;
    public float speed;

    Rigidbody player;

    void Start()
    {
        colliding = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() 
    {
        acc = Vector3.zero;

        //forward and backward
        if (Input.GetKey(KeyCode.W))
        {
            acc.z += 10;
        }
        if (Input.GetKey(KeyCode.S))
        {
            acc.z -= 10;
        }

        //left and right
        if (Input.GetKey(KeyCode.A))
        {
            acc.x -= 10;
        }
        if (Input.GetKey(KeyCode.D))
        {
            acc.x += 10;
        }

        //up and down
        if (Input.GetKey(KeyCode.Space))
        {
            acc.y += 5;
        }
        else if (!colliding)
        {
            acc.y -= 0.5f;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            acc.y -= 5;
        }

        vel += acc;

        if (vel.x > 50){
            vel.x = 50;
        }
        if (vel.x < -50)
        {
            vel.x = -50;
        }

        if (vel.z > 50)
        {
            vel.z = 50;
        }
        if (vel.z < -50)
        {
            vel.z = -50;
        }

        if (vel.y > 50)
        {
            vel.y = 50;
        }
        if (vel.y < -50)
        {
            vel.y = -50;
        }

        vel *= 0.9f;

        Vector3 vertical = Vector3.zero;
        vertical.y = vel.y;

        Vector3 horizontal = new Vector3(vel.x, 0, vel.z);

        //transform.Translate(vel * Time.deltaTime);
        player.AddForce(vertical * speed * 10 * Time.deltaTime);

        player.AddRelativeForce(horizontal * speed * 10 * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * 2;
        float mouseY = Input.GetAxis("Mouse Y") * 2;

        transform.RotateAround (transform.position, Vector3.up, mouseX);
        transform.RotateAround (transform.position, transform.right, -mouseY);



    }
    private void OnCollisionEnter(Collision collision)
    {
        if (hasPearl && collision.gameObject.layer != 12)
        {
            hasPearl = false;
            pearl.GetComponent<Pearl>().DropPearl();
        }
        colliding = true;
        vel.y = 0;
    }
    private void OnCollisionExit(Collision collision)
    {
        colliding = false;
    }
}
