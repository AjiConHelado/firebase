using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class points : MonoBehaviour
{
    [SerializeField] ScoreManager score;
    void OnMouseDown()
    {
        score.AddScore();
    }
}
