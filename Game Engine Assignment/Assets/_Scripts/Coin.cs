using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float speed = 1;
    float rotation = 0;
    private void OnCollisionEnter(Collision other)
    {
      if(other.collider.tag == "Player")
        {
            ScoreManager.instance.ChangeScore(1);
            Destroy(gameObject);

        }
    }
    void Update()
    {
        rotation = rotation + speed;
        transform.SetPositionAndRotation(transform.position, Quaternion.Euler(rotation, rotation, 0));
    }
}
