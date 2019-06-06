using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGenerator : MonoBehaviour
{
    [Header("引力")]
    public float GravitationSpeed = 30f;

    [Header("マウス追尾")]
    public float ChaseBackPosition = 10f;
    public float ChaseSmoothTime = 0.1f;

    public static float Gravitation         { set; get; }
    public static float PlPlanetBackPos     { set; get; }
    public static float PlPlanetSmoothTime  { set; get; }

    // Start is called before the first frame update
    void Start()
    {
        Gravitation         = GravitationSpeed;
        PlPlanetBackPos     = ChaseBackPosition;
        PlPlanetSmoothTime  = ChaseSmoothTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
