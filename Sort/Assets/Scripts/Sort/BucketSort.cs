using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// バケットソート
/// </summary>
public class BucketSort : Base
{
    /// <summary>
    /// 名前
    /// </summary>
    /// <returns></returns>
    public override string Name() { return "BucketSort"; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="delg"></param>
    /// <param name="delg2"></param>
    public BucketSort(Delegate delg, Delegate2 delg2) : base(delg, delg2) { }

    /// <summary>
    /// インスタンス取得
    /// </summary>
    /// <param name="delg"></param>
    /// <param name="delg2"></param>
    /// <returns></returns>
    public override Base GetInstance(Delegate delg, Delegate2 delg2) { return new BucketSort(delg, delg2); }

    /// <summary>
    /// ソート
    /// </summary>
    public override async void Sort()
    {
        List<int>[] tmp = new List<int>[Global.Length];
        for (int i = 0; i < Global.Length; i++) tmp[i] = new List<int>();

        for (int i = 0; i < Global.Length; i++)
        {
            tmp[Array[i]].Add(Array[i]);
        }

        int index = 0;
        for (int i = 0; i < Global.Length; i++)
        {
            for (int j = 0; j < tmp[i].Count; j++)
            {
                await Task.Delay(Global.WaitTime);
                Change(index, tmp[i][j]);
                index++;
            }
        }
        SortEnd?.Invoke();
    }
}
