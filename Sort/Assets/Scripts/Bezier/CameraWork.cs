using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// カメラワーク
/// </summary>
public class CameraWork : MonoBehaviour
{
    /// <summary>
    /// レーン
    /// </summary>
    [SerializeField] private List<Lane> lanes;

    /// <summary>
    /// カメラ
    /// </summary>
    [SerializeField] private Transform camera;

    /// <summary>
    /// ターゲット(カメラの向く方向)
    /// </summary>
    [SerializeField] private Transform target;

    /// <summary>
    /// インデックス
    /// </summary>
    private int index = 0;

    /// <summary>
    /// 速度
    /// </summary>
    private float speed = 0.1f;

    /// <summary>
    /// タイマー
    /// </summary>
    private float timer = 0;

    /// <summary>
    /// 待ち時間
    /// </summary>
    private const float waitTime = 3;

    /// <summary>
    /// トランスフォーム
    /// </summary>
    private Transform trns;

    /// <summary>
    /// 初期化
    /// </summary>
    private void Start()
    {
        camera.LookAt(target);
        trns = transform;
        StartCoroutine(Routine());
    }

    /// <summary>
    /// 日々のルーティン
    /// </summary>
    /// <returns></returns>
    private IEnumerator Routine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Time.deltaTime);

            // 日々レーンの上をなぞるように動く
            trns.position = lanes[index].GetBezier(timer);
            timer += Time.deltaTime * speed;

            // 日々被写体にカメラを向け
            camera.LookAt(target);

            // レーンが途切れると次のレーンに移動する
            if (timer >= 1)
            {
                yield return new WaitForSeconds(waitTime);
                index = (index + 1 >= lanes.Count ? 0 : index + 1);
                timer = 0;
            }

        }
    }

}
