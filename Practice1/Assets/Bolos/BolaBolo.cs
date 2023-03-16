using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class BolaBolo : MonoBehaviour
{
    private Material material;
    /*public Color32 colorBlue;
    public Color32 colorPink;
    public Color32 colorYellow;*/
    public PlayableDirector limpiador;
    public PlayableDirector dispensador;
    public Rigidbody bolaRb;
    public float fuerza = 1;
    private bool moveEnable = false;

    private void Awake()
    {
        limpiador.stopped += Restart;
        dispensador.stopped += MovementEnable;
    }
    void Start()
    {
        material= GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) //Inicia la animaci�n del limpiador y reinicia la escena
        {
            limpiador.Play();
        }
        if (Input.GetKeyDown(KeyCode.Space) && moveEnable)
        {
            bolaRb.AddForce((new Vector3(0,0,1))*fuerza, ForceMode.Impulse);
        }
    }

    private void Restart(PlayableDirector p)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void MovementEnable(PlayableDirector p)
    {
        moveEnable = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.tag == "TriggerBlue")
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
        }*/
    }
}