using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class EmergencyRestarter : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayableDirector limpiador;
    public BolaBolo bola;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Ball" && bola.moveEnable)
            bola.IniciarLimpieza();
    }
}
