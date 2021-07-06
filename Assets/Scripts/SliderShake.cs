using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SliderShake : MonoBehaviour
{
    public void Shake()
    {
        transform.DOComplete();
        transform.DOShakePosition(0.2f, 10f, 50, 0, false, false);
    }
}
