using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private static int uid = -1;
    private static int aid = -1;
    private static string username = null;
    private static short level = -1;
    private static int exp = -1;
    private static short energy = -1;
    private static int gem = -1;
    private static int gold = -1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }
    }

    private void Start()
    {

    }

    public static void updateUserInfo(int uid_, int aid_, string username_, short level_, int exp_, short energy_, int gem_, int gold_)
    {
        uid = uid_;
        aid = aid_;
        username = username_;
        level = level_;
        exp = exp_;
        energy = energy_;
        gem = gem_;
        gold = gold_;
    }

    public static int getUid()
    {
        return uid;
    }
    public static int getAid()
    {
        return aid;
    }
    public static string getUsername()
    {
        return username;
    }
    public static short getLevel()
    {
        return level;
    }
    public static int getExp()
    {
        return exp;
    }
    public static short getEnergy()
    {
        return energy;
    }
    public static int getGem()
    {
        return gem;
    }
    public static int getGold()
    {
        return gold;
    }
}