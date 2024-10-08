using System;

public class TreasureHuntSystem
{
   // 用魔法钥匙等于将两个箱子合并后再计算最大收益。遍历找到最大值。
   public static int useKey(int[] treasures)
    {
        if (treasures == null || treasures.Length == 0)
        {
            return 0;
        }
        if (treasures.Length == 1)
        {
            return treasures[0];
        }

        int n = treasures.Length;
        
        int maxOrigin = MaxTreasureValue(treasures);

        int maxUseKey = maxOrigin;
        for (int i = 0; i < n - 1; i++)
        {
            int[] newTreasures = new int[n - 1];
            for (int j = 0, k = 0; j < n; j++)
            {
                if (j == i)
                {
                    newTreasures[k++] = treasures[i] + treasures[i + 1]; 
                    j++; 
                }
                else
                {
                    newTreasures[k++] = treasures[j];
                }
            }

            maxUseKey = Math.Max(maxUseKey, MaxTreasureValue(newTreasures));
        }

        return maxUseKey;
    }

    public static int MaxTreasureValue(int[] treasures)
    {
        // 边界条件处理
        if (treasures == null || treasures.Length == 0)
        {
            return 0;
        }
        if (treasures.Length == 1)
        {
            return treasures[0];
        }
        if (treasures.Length == 2)
        {
            return Math.Max(treasures[0], treasures[1]);
        }

        int n = treasures.Length;
        // 动态规划数组
        int[] dp = new int[n];

        // 初始条件
        dp[0] = treasures[0];
        dp[1] = Math.Max(treasures[0], treasures[1]);

        // 状态转移
        for (int i = 2; i < n; i++)
        {
            dp[i] = Math.Max(dp[i - 1], dp[i - 2] + Math.Max(0, treasures[i]));
        }

        // 返回最后一个元素的最大值
        return dp[n - 1];
    }
}
public class TreasureHuntSystemTests
{
    public static void TestMaxTreasureValue()
    {
        // 测试 1
        int[] treasures1 = { 2, 7, 9, 3, 1 };
        int ans1 = TreasureHuntSystem.MaxTreasureValue(treasures1);
        Console.WriteLine("测试1: " + ans1); // 期望输出：12

        // 测试 2：含负值的宝箱
        int[] treasures2 = { 5, -2, 3, -4, 8, 9};
        int ans2 = TreasureHuntSystem.useKey(treasures2);
        Console.WriteLine("测试2: " + ans2); // 期望输出：25
       
    }
}

// 测试运行
// class Program
// {
//     static void Main(string[] args)
//     {
//         TreasureHuntSystemTests.TestMaxTreasureValue();
//     }
// }
