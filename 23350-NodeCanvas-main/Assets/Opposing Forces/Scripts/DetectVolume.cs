using UnityEngine;

public class DetectVolume : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = player.transform.position; //sets the DetectVolume sphere to the player position to keep things clean(er)
    }
}
