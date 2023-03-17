using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class BolaBolo : MonoBehaviour
{
    /*public Color32 colorBlue;
    public Color32 colorPink;
    public Color32 colorYellow;*/
    public Color32 colorGreen;
    public PlayableDirector limpiador;
    public PlayableDirector dispensador;
    public Rigidbody bolaRb;
    public float fuerza = 1;
    private bool moveEnable = false;
    public List<Rigidbody> bolos;
    private Material material;
    public GameObject inicioCamera;
    public GameObject ballCamera;
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
        if (Input.GetKeyDown(KeyCode.R)) //Inicia la animación del limpiador y reinicia la escena
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
        material.SetColor("_EmissionColor", colorGreen);
        foreach(Rigidbody rb in bolos)
        {
            rb.isKinematic = false;
        }
        inicioCamera.SetActive(false);
        ballCamera.SetActive(true);
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
