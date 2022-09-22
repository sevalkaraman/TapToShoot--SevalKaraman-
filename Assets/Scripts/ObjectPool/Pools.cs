using System;
using UnityEngine;

public class Pools : MonoBehaviour
{
    public enum Types
    {
        Bullet = 5,
        Bomb = 10,
    }

    public static string GetTypeStr(Types poolType)
    {
        return Enum.GetName(typeof(Types), poolType);
    }
}
