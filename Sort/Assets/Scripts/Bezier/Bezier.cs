using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ベジェ曲線
/// 3点で１曲線を形成する
/// </summary>
public class Bezier : MonoBehaviour
{
    /// <summary>
    /// ベジェ曲線の軌道を形成する個数
    /// </summary>
    private const int MAX = 50;

    /// <summary>
    /// 点の格納
    /// </summary>
    [SerializeField] private List<Transform> trans = new List<Transform>();

    /// <summary>
    /// 軌道上に置くオブジェクト
    /// </summary>
    [SerializeField] private GameObject obj;

    /// <summary>
    /// 親オブジェクト
    /// </summary>
    [SerializeField] private Transform parent;

    /// <summary>
    /// 生成したオブジェクトを格納する
    /// </summary>
    [SerializeField] private List<GameObject> objs;

    /// <summary>
    /// グラデーションの始めの色
    /// </summary>
    [SerializeField] private Color strColor;

    /// <summary>
    /// グラデーションの終わりの色
    /// </summary>
    [SerializeField] private Color endColor;

    /// <summary>
    /// カウント
    /// </summary>
    private int count = 0;

    /// <summary>
    /// 初期化
    /// </summary>
    private void Start()
    {
        count = (trans.Count / 2) * MAX;

        CreateObjects(count);
        SetColor();
    }

    /// <summary>
    /// メインループ
    /// </summary>
    private void Update()
    {
        SetBezier(count);
    }

    /// <summary>
    /// 軌道上に置くオブジェクトを生成する
    /// </summary>
    /// <param name="value"></param>
    private void CreateObjects(int value)
    {
        // すでに指定個数生成されていたら処理を抜ける
        if (objs.Count > value - 1) return;

        // 生成
        GameObject o;
        for (int i = 0; i < value; i++)
        {
            o = Instantiate(obj);
            objs.Add(o);
            o.transform.parent = parent;
        }
    }

    /// <summary>
    /// ベジェ曲線上にオブジェクトを設置していく
    /// </summary>
    /// <param name="value"></param>
    private void SetBezier(int value)
    {
        // 範囲
        int range = 3;

        // ループの始まりと終わり
        int from = 0, to = MAX;

        // ベジェ曲線の開始点・中間点・終点
        int front, middle, back;

        // スライス値
        float slice;

        // 曲線形成の各店が上限に達するまでループ  
        while (trans.Count >= range)
        {
            front = range - 3;
            middle = range - 2;
            back = range - 1;
            slice = 0;

            // 始点から終点までオブジェクトを配置
            // objs[from]～objs[to]までのオブジェクトを配置する
            for (int index = from; index < to; index++, slice++)
                objs[index].transform.position = GetBezier(trans[front].position, trans[middle].position, trans[back].position, slice / MAX);

            // 始点・終点の更新、次の範囲に移動
            from += MAX;
            to += MAX;
            range += 2;
        }
    }

    /// <summary>
    /// 配置したオブジェクトをグラデーション塗装する
    /// </summary>
    private void SetColor()
    {
        Color color;
        for (int i = 0; i < objs.Count; i++)
        {
            color = Color.Lerp(strColor, endColor, ((float)i / objs.Count));
            objs[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", color);
            objs[i].GetComponent<Renderer>().material.color = color;
        }
    }

    /// <summary>
    /// 曲線の軌道を生成
    /// </summary>
    /// <param name="front"></param>
    /// <param name="middle"></param>
    /// <param name="back"></param>
    /// <param name="time"></param>
    /// <returns></returns>
    private Vector3 GetBezier(Vector3 front, Vector3 middle, Vector3 back, float time)
    {
        Vector3 left = Vector3.Lerp(front, middle, time);
        Vector3 right = Vector3.Lerp(middle, back, time);
        return Vector3.Lerp(left, right, time);
    }
}
