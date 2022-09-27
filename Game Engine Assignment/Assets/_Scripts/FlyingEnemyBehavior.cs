using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyingEnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //public Movement playerpos;
    private float playerx;
    private float playery;
    public Rigidbody FlyingBody;
    public FlyingEnemyBehavior flyingEnemy;
    public float speed = 1;
    public GameObject FlyingObject;

    public Vector2 mmovement;
    public PlayerController mplayer;

    public float rotationangle, x1 = 1, z1 = 1;
    public float fpi = Mathf.PI;

    //new shit
    float rise = 0;
    float run = 0;
    float slope = 0;
    float b = 0;
    float followx = 0;
    float followz = 0;
    float test = 0;
    public GameObject enemy;

    //sort of functional movement
    void flyingMovement() //change it so the zombie gameobject is being rotated. currently only the original is
    {

        x1 = (FlyingBody.position.x) - (mplayer.playerx);
        z1 = (mplayer.playerz) - (FlyingBody.position.z);
        rotationangle = (Mathf.Atan(z1 / x1)) * (180 / fpi);

        if (FlyingObject.transform.position.x > mplayer.playerx) //bottom left
        {
            FlyingBody.velocity = new Vector3(-speed, FlyingBody.velocity.y, FlyingBody.velocity.z);

        }
        else if (FlyingObject.transform.position.x < mplayer.playerx) //bottom right
        {
            FlyingBody.velocity = new Vector3(speed, FlyingBody.velocity.y, FlyingBody.velocity.z);
            // zombie.zombieBody.SetRotation(-rotationangle);
        }
        if (FlyingObject.transform.position.z > mplayer.playerz)
        {
            FlyingBody.velocity = new Vector3(FlyingBody.velocity.x, FlyingBody.velocity.y, -speed);
        }
        else if (FlyingObject.transform.position.z < mplayer.playerz)
        {
            FlyingBody.velocity = new Vector3(FlyingBody.velocity.x, FlyingBody.velocity.y, speed);
        }
        if (FlyingObject.transform.position.y > mplayer.playery)
        {
            FlyingBody.velocity = new Vector3(FlyingBody.velocity.x, -speed, FlyingBody.velocity.z);
        }
        else if (FlyingObject.transform.position.z < mplayer.playerz)
        {
            FlyingBody.velocity = new Vector3(FlyingBody.velocity.x, speed, FlyingBody.velocity.z);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            //Application.LoadLevel(Application.loadedLevel);
            SceneManager.LoadScene("Level1");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(enemy);
    }

    // Update is called once per frame
    void Update()
    {
        flyingMovement();
    }
}
