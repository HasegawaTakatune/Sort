using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ベースクラス
/// </summary>
public class Base : MonoBehaviour
{

    [SerializeField] protected int[] Array;

    [SerializeField] protected const float wait = 3;

    public delegate void Delegate(ChangedData data);
    public Delegate Changed;

    protected void Start()
    {
        //Play();
    }    

    public Base(Delegate @delegate)
    {
        Changed = @delegate;
    }

    public void Play(int[] values)
    {
        Array = values;
        
    }
}
