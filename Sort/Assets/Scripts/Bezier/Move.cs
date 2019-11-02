using System.Collections;
using UnityEngine;

/// <summary>
/// 移動
/// </summary>
public class Move : MonoBehaviour
{
    /// <summary>
    /// 速度
    /// </summary>
    private float speed = 0.0f;

    /// <summary>
    /// トランスフォーム格納
    /// </summary>
    private Transform trns;

    /// <summary>
    /// ターゲット(起点)
    /// </summary>
    private Vector3 target;

    /// <summary>
    /// タイプ
    /// </summary>
    enum Type { MOVE, RETURN }

    /// <summary>
    /// タイプ
    /// </summary>
    Type type = Type.MOVE;

    /// <summary>
    /// 初期化
    /// </summary>
    private void Start()
    {
        trns = gameObject.transform;
        target = trns.position;

        StartCoroutine(GoMovie());
        StartCoroutine(Controller());
    }

    /// <summary>
    /// 適当な方向に移動する
    /// </summary>
    /// <returns></returns>
    private IEnumerator GoMovie()
    {
        Vector3 velocity = trns.position;
        float angle = Random.Range(0.0f, 360.0f);
        speed = Random.Range(3.0f, 10.0f);

        while (type == Type.MOVE)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            velocity.x += Mathf.Cos(angle) * speed * Time.deltaTime;
            velocity.y += Mathf.Sin(angle) * speed * Time.deltaTime;
            trns.position = velocity;
        }
        StartCoroutine(GoBack());
    }

    /// <summary>
    /// 起点に戻る
    /// </summary>
    /// <returns></returns>
    private IEnumerator GoBack()
    {
        while (type == Type.RETURN)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            trns.position = Vector3.MoveTowards(trns.position, target, speed * Time.deltaTime);
        }
        StartCoroutine(GoMovie());
    }

    /// <summary>
    /// コントローラー
    /// </summary>
    /// <returns></returns>
    private IEnumerator Controller()
    {
        float timer = Random.Range(2.0f, 5.0f);
        while (true)
        {
            // 移動する/起点に戻るを切り替える
            yield return new WaitForSeconds(timer);
            type = (type == Type.MOVE ? Type.RETURN : Type.MOVE);
            if (type == Type.MOVE) timer = Random.Range(2.0f, 5.0f);
        }
    }
}
