using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLife : MonoBehaviour
{
    private Material material;
    public Color32 colorBlue;
    public Color32 colorPink;
    public Color32 colorYellow;
    // Start is called before the first frame update
    void Start()
    {
        material= GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TriggerBlue")
        {
            material.SetColor("_EmissionColor", colorBlue);
        }
        else if (other.tag == "TriggerPink")
        {
            material.SetColor("_EmissionColor", colorPink);
        }
        else if (other.tag == "TriggerYellow")
        {
            material.SetColor("_EmissionColor", colorYellow);
        }
    }
}
