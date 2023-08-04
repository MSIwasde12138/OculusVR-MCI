using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singsongs : MonoBehaviour
{

    public AudioSource aS;
    public AudioSource aC;
    public AudioSource aA;
    public AudioSource aJ;
    public AudioSource aH;
    public AudioSource aZ;
    public AudioSource aD;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zhoujielun")
        {
            aS.Play();
            other.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ChineseMusic")
        {
            aC.Play();
            other.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AmericanBlues")
        {
            aA.Play();
            other.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "JingJu")
        {
            aJ.Play();
            other.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HuangMei")
        {
            aH.Play();
            other.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "XueYou")
        {
            aZ.Play();
            other.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DengLijun")
        {
            aD.Play();
            other.gameObject.SetActive(false);
        }
    }
}
