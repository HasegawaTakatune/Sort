using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// 基数ソート
/// </summary>
public class RadixSort : Base
{
    /// <summary>
    /// 名前
    /// </summary>
    /// <returns></returns>
    public override string Name() { return "RadixSort"; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="delg"></param>
    /// <param name="delg2"></param>
    public RadixSort(Delegate delg, Delegate2 delg2) : base(delg, delg2) { }

    /// <summary>
    /// インスタンス取得
    /// </summary>
    /// <param name="delg"></param>
    /// <param name="delg2"></param>
    /// <returns></returns>
    public override Base GetInstance(Delegate delg, Delegate2 delg2) { return new RadixSort(delg, delg2); }

    /// <summary>
    /// ソート
    /// </summary>
    public override async void Sort()
    {
        List<int>[] tmp = new List<int>[Global.Length];
        for (int i = 0; i < Global.Length; i++) tmp[i] = new List<int>();

        for (int i = 0; i < Global.Length; i++)
        {
            tmp[i].Add(Array[i]);
        }

        await Sort(tmp, 10);

        SortEnd?.Invoke();
    }

    /// <summary>
    /// ソート
    /// </summary>
    /// <param name="ary"></param>
    /// <param name="digit"></param>
    public async Task Sort(List<int>[] ary, int digit)
    {
        int index = 0;
        List<int>[] tmp = new List<int>[Global.Length];
        for (int i = 0; i < Global.Length; i++)
            tmp[i] = new List<int>();

        if (digit <= 1)
            for (int i = 0; i < Global.Length; i++)
                tmp[(Array[i] / digit)].Add(Array[i]);
        else
            for (int i = 0; i < Global.Length; i++)
                tmp[(Array[i] / digit) % digit].Add(Array[i]);


        index = 0;
        for (int i = 0; i < Global.Length; i++)
        {
            for (int j = 0; j < tmp[i].Count; j++)
            {
                await Task.Delay(Global.WaitTime);
                Change(index, tmp[i][j]);
                index++;
            }
        }

        if (digit <= 1) return;

        await Sort(tmp, digit / 10);
    }
}
