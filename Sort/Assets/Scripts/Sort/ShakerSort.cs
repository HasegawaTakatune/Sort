using System.Threading.Tasks;

public class ShakerSort : Base
{
    /// <summary>
    /// 名前
    /// </summary>
    /// <returns></returns>
    public override string Name() { return "ShakerSort"; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="delegate"></param>
    /// <param name="delegate2"></param>
    public ShakerSort(Delegate @delegate, Delegate2 @delegate2) : base(@delegate, @delegate2) { }

    /// <summary>
    /// インスタンス取得
    /// </summary>
    /// <param name="delg"></param>
    /// <param name="delg2"></param>
    /// <returns></returns>
    public override Base GetInstance(Delegate delg, Delegate2 delg2) { return new ShakerSort(delg, delg2); }

    /// <summary>
    /// ソート
    /// </summary>
    public override async void Sort()
    {
        int count = 0, next = 0;
        bool isEnd = false;

        while (!isEnd)
        {
            isEnd = true;
            for (int i = 0; i < Global.Length - 1; i++)
            {
                next = i + 1;
                if (Array[i] < Array[next])
                {
                    await Task.Delay(100);

                    count++;
                    Swap(i, next);
                    isEnd = false;
                }
                Changed?.Invoke(new ChangedData(i, Array[i], next, Array[next], count));
            }

            for (int i = Global.Length - 1; i < 0; i++)
            {
                next = i - 1;
                if (Array[i] < Array[next])
                {
                    await Task.Delay(100);

                    count++;
                    Swap(i, next);
                    isEnd = false;
                }
                Changed?.Invoke(new ChangedData(i, Array[i], next, Array[next], count));
            }
        }
        SortEnd?.Invoke();
    }
}
