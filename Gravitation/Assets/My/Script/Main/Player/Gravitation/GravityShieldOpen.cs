using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityShieldOpen : MonoBehaviour
{
    public Image GravityGage;
    public GameObject GravityShield;

    // Update is called once per frame
    void Update()
    {
        if (GravityGage.fillAmount > 0)
        {
            if (Input.GetMouseButton(1)) GravityShield.SetActive(true);
        }
        if (GravityGage.fillAmount == 0) GravityShield.SetActive(false);

        if (Input.GetMouseButtonUp(1)) GravityShield.SetActive(false);
    }
}
