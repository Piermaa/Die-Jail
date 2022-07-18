using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRecoil : MonoBehaviour
{
    public Vector3 upRecoil = new Vector3(-10f, 0f, 0f);
    Vector3 originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            AddRecoil();
        else if (Input.GetButtonUp("Fire1"))
            StopRecoil();
    }

    private void AddRecoil() {
        transform.localEulerAngles += upRecoil;
    }

    private void StopRecoil() {
        transform.localEulerAngles = originalRotation;
    }
}
