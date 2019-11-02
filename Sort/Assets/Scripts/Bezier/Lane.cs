using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// レーン
/// </summary>
public class Lane : MonoBehaviour
{
    /// <summary>
    /// 始点
    /// </summary>
    [SerializeField] private Transform front;

    /// <summary>
    /// 中間点
    /// </summary>
    [SerializeField] private Transform middle;

    /// <summary>
    /// 終点
    /// </summary>
    [SerializeField] private Transform back;

    /// <summary>
    /// 曲線の軌道を取得
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    public Vector3 GetBezier(float time)
    {
        Vector3 left = Vector3.Lerp(front.position, middle.position, time);
        Vector3 right = Vector3.Lerp(middle.position, back.position, time);
        return Vector3.Lerp(left, right, time);
    }
}
