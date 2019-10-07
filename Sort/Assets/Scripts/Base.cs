using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ベースクラス
/// </summary>
public class Base : Interface
{
    /// <summary>
    /// 配列
    /// </summary>
    [SerializeField] protected int[] Array;

    /// <summary>
    /// 待ち時間
    /// </summary>
    [SerializeField] protected const int waitTime = 100;

    /// <summary>
    /// デリゲート宣言
    /// </summary>
    /// <param name="data"></param>
    public delegate void Delegate(ChangedData data);

    /// <summary>
    /// デリゲート（配列並び替え時のバインド用）
    /// </summary>
    public Delegate Changed;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="delegate">配列並び替え時にバインドする関数</param>
    public Base(Delegate @delegate)
    {
        Changed = @delegate;
    }

    /// <summary>
    /// ソート実行
    /// </summary>
    /// <param name="values">対象配列</param>
    public virtual void Play(int[] values)
    {
        Array = values;
    }

    public virtual void Sort()
    {
    }
}
