using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityShieldOpen : MonoBehaviour
{
    public GameObject GravityShield;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)) GravityShield.SetActive(true);
        if (Input.GetMouseButtonUp(1)) GravityShield.SetActive(false);
    }
}
