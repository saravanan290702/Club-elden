using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreComp<T> where T : CoreComponent
{
    private Core core;
    private T comp;

    public T Comp => comp ? comp : core.GetCoreComponent(ref comp);

    public CoreComp(Core core)
    {
        if (core == null)
        {
            Debug.LogWarning($"Core is null for component {typeof(T)}");
        }

        this.core = core;
    }
}
