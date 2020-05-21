using System.Collections.Generic;

public class EnemyHandler
{
    public static EnemyHandler Instance;

    public static void SetInstance(EnemyHandler enemyHandler)
    {
        Instance = enemyHandler;
    }

    private int maxEnemyId;
}
