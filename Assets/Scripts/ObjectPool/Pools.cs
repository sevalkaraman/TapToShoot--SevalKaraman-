using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pools : MonoBehaviour
{
    public enum Types
    {
        Projectile = 5,
    }

    public static string GetTypeStr(Types poolType)
    {
        return Enum.GetName(typeof(Types), poolType);
    }
}
