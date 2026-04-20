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

    void Update() 
    {
        acc = Vector3.zero;

        //forward and backward inputs
        if (Input.GetKey(KeyCode.W))
        {
            acc.z += 10;
        }
        if (Input.GetKey(KeyCode.S))
        {
            acc.z -= 10;
        }

        //left and right inputs
        if (Input.GetKey(KeyCode.A))
        {
            acc.x -= 10;
        }
        if (Input.GetKey(KeyCode.D))
        {
            acc.x += 10;
        }

        //up and down inputs
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

        if (vel.x > 50){ //capping all the different velocities so you don't go at warp speed
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

        vel *= 0.9f; //decays the velocity quickly over time

        Vector3 vertical = Vector3.zero; //doing vertical movement and horizontal movement separately or else you could move in all sorts of directions with space/shift
        vertical.y = vel.y;

        Vector3 horizontal = new Vector3(vel.x, 0, vel.z);

        player.AddForce(vertical * speed * 10 * Time.deltaTime); //vertical is objective

        player.AddRelativeForce(horizontal * speed * 10 * Time.deltaTime); //horizontal is relative

        float mouseX = Input.GetAxis("Mouse X") * 2;  //gets the axises (axes?) of the mouse and rotates the camera accordingly to move camera in first person
        float mouseY = Input.GetAxis("Mouse Y") * 2;

        transform.RotateAround (transform.position, Vector3.up, mouseX);
        transform.RotateAround (transform.position, transform.right, -mouseY);



    }
    private void OnCollisionEnter(Collision collision)
    {
        if (hasPearl && collision.gameObject.layer != 12) //the player will drop the pearl if it collides with anything, the exception being objects marked as "standable" (floor, clam bottom half)
        {
            hasPearl = false;
            pearl.GetComponent<Pearl>().DropPearl(); //drops the pearl if collides with anything else
        }
        colliding = true;
        vel.y = 0;
    }
    private void OnCollisionExit(Collision collision)
    {
        colliding = false;
    }
}
