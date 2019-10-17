using UnityEngine;

/// <summary>
/// ベースクラス
/// </summary>
public abstract class Base : Interface
{
    /// <summary>
    /// 名前
    /// </summary>    
    public abstract string Name();

    /// <summary>
    /// 配列
    /// </summary>
    [SerializeField] protected int[] Array;

    protected int count = 0;

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
    /// デリゲート宣言
    /// </summary>
    public delegate void Delegate2();

    /// <summary>
    /// デリゲート（ソート終了通知）
    /// </summary>
    public Delegate2 SortEnd;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="delg">配列並び替え時にバインドする関数</param>
    /// <param name="delg2">ソート終了時にバインドする関数</param>
    public Base(Delegate delg, Delegate2 delg2) { Changed = delg; SortEnd = delg2; }

    /// <summary>
    /// インスタンス取得
    /// </summary>
    /// <param name="delg">配列並び替え時にバインドする関数</param>
    /// <param name="delg2">ソート終了時にバインドする関数</param>
    /// <returns>インスタンス</returns>
    public abstract Base GetInstance(Delegate delg, Delegate2 delg2);

    /// <summary>
    /// デストラクタ
    /// </summary>
    ~Base() { Changed = null; SortEnd = null; }

    /// <summary>
    /// ソート実行
    /// </summary>
    /// <param name="values">対象配列</param>
    public void Play(int[] values)
    {
        count = 0;
        Array = values;
        Sort();
    }

    /// <summary>
    /// ソート処理
    /// </summary>
    public abstract void Sort();

    /// <summary>
    /// 並び替え
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    protected void Swap(int from, int to)
    {        
        int tmp = Array[from];
        Array[from] = Array[to];
        Array[to] = tmp;
        count++;
        Changed?.Invoke(new ChangedData(from, Array[from], to, Array[to], count));
    }
}