using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States : MonoBehaviour
{
    //animation tag
    public static string RunAnimation = "Run";
    public static string AttackAnimation = "Attack";
    public static string RunAttackAnimation = "RunAttack";
    public static string DeadAnimation = "Dead";
    //trigger animation
    public static string RunTrigger = "Run";
    public static string StopTrigger = "Stop";
    public static string AttackTrigger = "Attack";
    public static string JumpTrigger = "Jump";
    public static string DeadTrigger = "Dead";
    //collision tags
    public static string PlayerTag = "Player";
    public static string EnemyTag = "Enemy";
    public static string CoinTag = "Coin";
}
