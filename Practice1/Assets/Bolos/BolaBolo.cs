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

    private void Awake()
    {
        limpiador.stopped += Restart;
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
    }

    private void Restart(PlayableDirector p)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
