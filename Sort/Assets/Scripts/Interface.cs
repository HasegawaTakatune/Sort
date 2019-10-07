/// <summary>
/// インターフェイス
/// </summary>
public interface Interface
{
    void Sort();
}

/// <summary>
/// 配列を並び替えた時のデータを格納する構造体
/// </summary>
public struct ChangedData
{
    public int fromIndex;
    public float fromValue;
    public int toIndex;
    public float toValue;

    public ChangedData(int fromIndex, int fromValue, int toIndex, int toValue) : this()
    {
        this.fromIndex = fromIndex;
        this.fromValue = fromValue;
        this.toIndex = toIndex;
        this.toValue = toValue;
    }
}

/// <summary>
/// UIアイテムの列挙
/// </summary>
public enum UI_BUTTON
{
    /// <summary>
    /// 実行
    /// </summary>
    Play = 0,

    /// <summary>
    /// バブルソート
    /// </summary>
    BubbleSort,

    /// <summary>
    /// 長さ
    /// </summary>
    LENGTH
}

/// <summary>
/// 共通変数
/// </summary>
public static class Global
{

    /// <summary>
    /// 配列の長さ
    /// </summary>
    public const int Length = 20;

}
