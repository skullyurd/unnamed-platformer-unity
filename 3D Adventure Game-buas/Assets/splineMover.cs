 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splineMover : MonoBehaviour
{
    [SerializeField] private Spline splineScript;
    [SerializeField] private Transform followObj;

    [SerializeField] private Transform thisTranform;

    // Start is called before the first frame update
    void Start()
    {
        thisTranform = followObj;
    }

    // Update is called once per frame
    void Update()
    {
        thisTranform.position = splineScript.WhereOnSpline(followObj.position);
    }
}
