﻿using UnityEngine;
using System.Collections;

public class BackAndForth : MonoBehaviour
{
    public Vector3 pointB;
    public float pause;
    public float speed;

    IEnumerator Start()
    {
        var pointA = transform.position;
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
        }
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        var i = 0.0f;
        var rate = speed / time;
        while (i < pause)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }
}