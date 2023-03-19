using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class BolaBolo : MonoBehaviour
{
    public Color32 colorGreen;
    public PlayableDirector limpiador;
    public PlayableDirector dispensador;
    public Rigidbody bolaRb;
    public float fuerza = 1;
    public bool moveEnable = false;
    public List<Rigidbody> bolos;
    private Material material;
    public GameObject inicioCamera;
    public GameObject ballCamera;
    public AudioSource musicManager;
    private bool chocado;
    private void Awake()
    {
        limpiador.stopped += Restart;
        dispensador.stopped += MovementEnable;
    }
    void Start()
    {
        material= GetComponent<MeshRenderer>().material;
        chocado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && moveEnable) //Inicia la animación del limpiador y reinicia la escena
        {
            IniciarLimpieza();
        }
        if (Input.GetKeyDown(KeyCode.Space) && moveEnable)
        {
            bolaRb.AddForce((new Vector3(0,0,1))*fuerza, ForceMode.Impulse);
        }
    }

    public void IniciarLimpieza()
    {
        //this.gameObject.GetComponent<AudioSource>().Stop();
        musicManager.Stop();
        moveEnable = false;
        limpiador.Play();
    }

    private void Restart(PlayableDirector p)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void MovementEnable(PlayableDirector p)
    {
        moveEnable = true;
        musicManager.Play();
        material.SetColor("_EmissionColor", colorGreen);
        foreach(Rigidbody rb in bolos)
        {
            rb.isKinematic = false;
        }
        inicioCamera.SetActive(false);
        ballCamera.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bolo" && !chocado)
        {
            this.gameObject.GetComponent<AudioSource>().Play();
            chocado= true;
        }
    }
}
