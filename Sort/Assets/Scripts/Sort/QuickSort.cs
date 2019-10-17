using System.Threading.Tasks;
/// <summary>
/// クイックソート
/// </summary>
public class QuickSort : Base
{
    /// <summary>
    /// 名前
    /// </summary>
    /// <returns></returns>
    public override string Name() { return "QuickSort"; }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="delg"></param>
    /// <param name="delg2"></param>
    public QuickSort(Delegate delg, Delegate2 delg2) : base(delg, delg2) { }

    /// <summary>
    /// インスタンス取得
    /// </summary>
    /// <param name="delg"></param>
    /// <param name="delg2"></param>
    /// <returns></returns>
    public override Base GetInstance(Delegate delg, Delegate2 delg2) { return new QuickSort(delg, delg2); }

    /// <summary>
    /// ソート
    /// </summary>
    public override void Sort()
    {
        Sort(Array, 0, Array.Length - 1);
        SortEnd?.Invoke();
    }

    /// <summary>
    /// 要素軸の選択（2要素のうち大きい値を返す）
    /// </summary>
    /// <param name="array"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    int Pivot(int[] array, int from, int to)
    {
        int index = from + 1;
        while (index <= to && array[from] == array[index]) index++;
        if (index > to) return -1;
        if (array[from] >= array[index]) return from;
        return index;
    }

    /// <summary>
    /// 小さい値を前に大きい値を後ろに移動させる
    /// </summary>
    /// <param name="array"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="pivot"></param>
    /// <returns></returns>
    int Partition(int[] array, int from, int to, int pivot)
    {
        int left = from, right = to;

        // 検索が交差するまで繰り返します
        while (left <= right)
        {
            // 軸要素以上のデータを探します
            while (left <= to && array[left] < pivot) left++;

            // 軸要素未満のデータを探します
            while (right >= from && array[right] >= pivot) right--;

            if (left > right) break;
            Swap(left, right);
            left++; right--;
        }
        return left;
    }

    /// <summary>
    /// ソート
    /// </summary>
    /// <param name="array"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    public async void Sort(int[] array, int from, int to)
    {
        if (from == to) return;
        int pivot = Pivot(array, from, to);
        if (pivot != -1)
        {
            await Task.Delay(Global.WaitTime);
            int index = Partition(array, from, to, array[pivot]);
            Sort(array, from, index - 1);
            Sort(array, index, to);
        }
    }
}
