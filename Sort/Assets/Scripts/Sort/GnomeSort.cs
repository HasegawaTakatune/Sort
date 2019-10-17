using System.Threading.Tasks;
/// <summary>
/// ノームソート
/// </summary>
public class GnomeSort : Base
{
    /// <summary>
    /// 名前
    /// </summary>
    /// <returns></returns>
    public override string Name() { return "GnomeSort"; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="delg"></param>
    /// <param name="delg2"></param>
    public GnomeSort(Delegate delg, Delegate2 delg2) : base(delg, delg2) { }

    /// <summary>
    /// インスタンス取得
    /// </summary>
    /// <param name="delg"></param>
    /// <param name="delg2"></param>
    /// <returns></returns>
    public override Base GetInstance(Delegate delg, Delegate2 delg2) { return new GnomeSort(delg, delg2); }

    /// <summary>
    /// ソート
    /// </summary>
    public override async void Sort()
    {
        int next = 0;

        for (int i = 0; i < Global.Length - 1; i++)
        {
            // 順に比較
            next = i + 1;
            if (Array[i] < Array[next])
            {
                await Task.Delay(Global.WaitTime);
                Swap(i, next);

                // 逆順で比較する
                for (int j = i; j > 0; j--)
                {
                    int back = j - 1;
                    if (Array[j] > Array[back])
                    {
                        await Task.Delay(Global.WaitTime);
                        Swap(j, back);
                    }
                    else break;
                }
            }
        }
        SortEnd?.Invoke();
    }
}
