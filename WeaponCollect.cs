using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;
using System;

public class WeaponCollect : MonoBehaviour
{

    public float collectleftScore = 0;

    public AudioClip rightClip2;
    public AudioClip wrongClip2;
    public AudioSource rightSource1;
    public AudioSource wrongSource1;

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag.Equals("torch"))
        {
            collectleftScore += 1;
            rightSource1.PlayOneShot(rightClip2, 1F);
            
        }
        if (other.gameObject.tag.Equals("book"))
        {
            wrongSource1.PlayOneShot(wrongClip2, 1F);
        }
        if (other.gameObject.tag.Equals("cup"))
        {
            collectleftScore += 1;
            rightSource1.PlayOneShot(rightClip2, 1F);
        }
        if (other.gameObject.tag.Equals("recorder"))
        {
            wrongSource1.PlayOneShot(wrongClip2, 1F);
        }
        if (other.gameObject.tag.Equals("chopsticks"))
        {
            collectleftScore += 1;
            rightSource1.PlayOneShot(rightClip2, 1F);
        }
        if (other.gameObject.tag.Equals("marker"))
        {
            wrongSource1.PlayOneShot(wrongClip2, 1F);
        }
        if (other.gameObject.tag.Equals("ricecooker"))
        {
            collectleftScore += 1;
            rightSource1.PlayOneShot(rightClip2, 1F);
        }
        if (other.gameObject.tag.Equals("tree"))
        {
            wrongSource1.PlayOneShot(wrongClip2, 1F);
        }
        if (other.gameObject.tag.Equals("toothpaste"))
        {
            collectleftScore += 1;
            rightSource1.PlayOneShot(rightClip2, 1F);
        }
        if (other.gameObject.tag.Equals("pingpong"))
        {
            wrongSource1.PlayOneShot(wrongClip2, 1F);
        }

    }

}
