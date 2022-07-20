using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public float width;
    public bool filled = true;
    public GameObject heart;

    // Update is called once per frame
    void Update()
    {
        if (filled)
            heart.SetActive(true);
        else
            heart.SetActive(false);

    }
}
