using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimStartTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Animation>()["NOT READ ONLY"].time < 2.5f)
        {
            GetComponent<Animation>()["NOT READ ONLY"].time = 2.5f;
        }
    }
}
