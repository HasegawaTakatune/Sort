using System.Threading.Tasks;
/// <summary>
/// 挿入ソート
/// </summary>
public class InsertionSort : Base
{
    /// <summary>
    /// 名前
    /// </summary>
    /// <returns></returns>
    public override string Name() { return "InsertionSort"; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="delg"></param>
    /// <param name="delg2"></param>
    public InsertionSort(Delegate delg, Delegate2 delg2) : base(delg, delg2) { }

    /// <summary>
    /// インスタンス取得
    /// </summary>
    /// <param name="delg"></param>
    /// <param name="delg2"></param>
    /// <returns></returns>
    public override Base GetInstance(Delegate delg, Delegate2 delg2) { return new InsertionSort(delg, delg2); }

    /// <summary>
    /// ソート
    /// </summary>
    public override async void Sort()
    {
        int j;

        for (int i = 0; i < Global.Length; i++)
        {
            j = i;
            while ((j > 0) && (Array[j - 1] < Array[j]))
            {
                await Task.Delay(Global.WaitTime);
                Swap(j - 1, j);
                j--;
            }
        }
        SortEnd?.Invoke();
    }
}
