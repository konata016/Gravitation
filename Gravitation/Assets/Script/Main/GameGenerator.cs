using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour
{
    [Header("引力")]
    public float GravitationSpeed = 30f;

    public static float Gravitation { set; get; }

    // Start is called before the first frame update
    void Start()
    {
        Gravitation = GravitationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
