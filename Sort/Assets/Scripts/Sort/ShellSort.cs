using System.Threading.Tasks;
/// <summary>
/// シェルソート
/// </summary>
public class ShellSort : Base
{
    /// <summary>
    /// 名前
    /// </summary>
    /// <returns></returns>
    public override string Name() { return "ShellSort"; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="delg"></param>
    /// <param name="delg2"></param>
    public ShellSort(Delegate delg, Delegate2 delg2) : base(delg, delg2) { }

    /// <summary>
    /// インスタンス取得
    /// </summary>
    /// <param name="delg"></param>
    /// <param name="delg2"></param>
    /// <returns></returns>
    public override Base GetInstance(Delegate delg, Delegate2 delg2) { return new ShellSort(delg, delg2); }

    /// <summary>
    /// ソート
    /// </summary>
    public override async void Sort()
    {
        int j;
        int interval = Global.Length;

        while (true)
        {
            // 適当な感覚で挿入ソートを行う
            interval /= 2;
            interval = (interval <= 1 ? 1 : interval);

            for (int i = 0; i < Global.Length; i += interval)
            {
                j = i;
                while ((j > 0) && (Array[j - 1] < Array[j]))
                {
                    await Task.Delay(Global.WaitTime);
                    Swap(j - 1, j);
                    j--;
                }
            }
            if (interval == 1) break;
        }
        SortEnd?.Invoke();
    }
}
