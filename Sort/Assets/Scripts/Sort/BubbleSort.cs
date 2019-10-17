using System.Threading.Tasks;

/// <summary>
/// バブルソート
/// </summary>
public class BubbleSort : Base
{
    /// <summary>
    /// 名前
    /// </summary>
    /// <returns></returns>
    public override string Name() { return "BubbleSort"; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="delegate">登録するイベント</param>
    public BubbleSort(Delegate @delegate, Delegate2 @delegate2) : base(@delegate, @delegate2) { }

    /// <summary>
    /// インスタンス取得
    /// </summary>
    /// <param name="delg"></param>
    /// <param name="delg2"></param>
    /// <returns></returns>
    public override Base GetInstance(Delegate delg, Delegate2 delg2) { return new BubbleSort(delg, delg2); }

    /// <summary>
    /// ソート
    /// </summary>
    public override async void Sort()
    {
        int next = 0;
        bool isEnd = false;

        while (!isEnd)
        {
            isEnd = true;
            for (int i = 0; i < Global.Length - 1; i++)
            {
                next = i + 1;
                if (Array[i] < Array[next])
                {
                    await Task.Delay(Global.WaitTime);
                    Swap(i, next);
                    isEnd = false;
                }
            }
        }
        SortEnd?.Invoke();
    }
}
