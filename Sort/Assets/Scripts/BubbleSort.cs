using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort : Base, Interface
{

    public BubbleSort(Delegate @delegate) : base(@delegate)
    {

    }

    public void Sort()
    {
        for (int i = 0; i < Global.Length - 1; i++)
        {
            for (int j = Global.Length - 1; j >= i + 1; j--)
            {
                if (Array[j] < Array[j - 1])
                {
                    int tmp = Array[j];
                    Array[j] = Array[j - 1];
                    Array[j - 1] = tmp;

                    Changed?.Invoke(new ChangedData(j, Array[j], j - 1, Array[j - 1]));
                }
            }
        }
    }
}
