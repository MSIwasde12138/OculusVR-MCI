using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class SquareCollect : MonoBehaviour
{

    public float collectrightScore = 0;

    public AudioClip rightClip1;
    public AudioClip wrongClip1;
    public AudioSource rightSource1;
    public AudioSource wrongSource1;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag.Equals("book"))
        {
            collectrightScore += 1;
            rightSource1.PlayOneShot(rightClip1, 1F);
        }
        if (other.gameObject.tag.Equals("torch"))
        {
            wrongSource1.PlayOneShot(wrongClip1, 1F);
        }
        if (other.gameObject.tag.Equals("recorder"))
        {
            collectrightScore += 1;
            rightSource1.PlayOneShot(rightClip1, 1F);
        }
        if (other.gameObject.tag.Equals("cup"))
        {
            wrongSource1.PlayOneShot(wrongClip1, 1F);
        }
        if (other.gameObject.tag.Equals("marker"))
        {
            collectrightScore += 1;
            rightSource1.PlayOneShot(rightClip1, 1F);
        }
        if (other.gameObject.tag.Equals("chopsticks"))
        {
            wrongSource1.PlayOneShot(wrongClip1, 1F);
        }
        if (other.gameObject.tag.Equals("tree"))
        {
            collectrightScore += 1;
            rightSource1.PlayOneShot(rightClip1, 1F);
        }
        if (other.gameObject.tag.Equals("ricecooker"))
        {
            wrongSource1.PlayOneShot(wrongClip1, 1F);
        }
        if (other.gameObject.tag.Equals("pingpong"))
        {
            collectrightScore += 1;
            rightSource1.PlayOneShot(rightClip1, 1F);
        }
        if (other.gameObject.tag.Equals("toothpaste"))
        {
            wrongSource1.PlayOneShot(wrongClip1, 1F);
        }

    }

}
