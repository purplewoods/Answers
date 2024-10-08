using System;

public class EnergyFieldSystem
{

    //提高某个塔的高度为height，将其加入heights中再遍历每一个位置，得到最大位置再和不加高度最大面积相比
    public static float BoostHeight(int[] heights, int height)
    {
        if (heights == null || heights.Length < 2)
        {
            return 0;
        }

        int n = heights.Length;
        float maxOrigin = MaxEnergyField(heights); 

        // 遍历每个塔的位置，假设提升该塔的高度
        float maxS = 0;
        for (int i = 0; i < n; i++)
        {
            int originalHeight = heights[i]; 
            heights[i] += height; 
            float areaWithBoost = MaxEnergyField(heights); 
            maxS = Math.Max(maxS, areaWithBoost); 
            heights[i] = originalHeight; 
        }

        return Math.Max(maxOrigin, maxS);
    }

    //运用双指针来完成最大面积的选择
    public static float MaxEnergyField(int[] heights)
    {
        if (heights == null || heights.Length < 2)
        {
            return 0; 
        }

        int left = 0; 
        int right = heights.Length - 1; 
        float maxArea = 0; 

        while (left < right)
        {
             // 如果某个地点有高度限制则每次跳过高度为0的塔
            if (heights[left] == 0)
            {
                left++;
                continue;
            }
            if (heights[right] == 0)
            {
                right--;
                continue;
            }

            int height1 = heights[left];
            int height2 = heights[right];
            int width = right - left;
            float area = (float)(height1 + height2) * width / 2;

            if (area > maxArea)
            {
                maxArea = area;
            }

            if (height1 < height2)
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return maxArea;
    }
}

// 单元测试
public class EnergyFieldSystemTests
{
    public static void TestMaxEnergyField()
    {
        // 测试 1
        int[] heights1 = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
        float ans1 = EnergyFieldSystem.MaxEnergyField(heights1);
        Console.WriteLine("测试用例 1 结果: " + ans1); // 期望输出：52.5

        // 测试 2：某一塔加高度
        int[] heights2 = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
        float ans2 = EnergyFieldSystem.BoostHeight(heights2, 4);
        Console.WriteLine("测试用例 2 结果: " + ans2); // 期望输出：66.5

        //测试 3： 某一塔加高度
        int[] heights3 = { 1, 0, 6, 2, 5, 4, 8, 3, 7 };
        float ans3 = EnergyFieldSystem.BoostHeight(heights3, 4);
        Console.WriteLine("测试用例 2 结果: " + ans3); //期望输出： 51
    }
}
//思考：
//这个能量场机制通过改变建立两座塔的位置来影响玩家的决策，还有玩家道具和高度限制区域也会影响。
//这个可以是放置类游戏的放置位置的逻辑让玩家在放置位置上能够一些思考也可以是如自走棋一样，棋子放置在某个高亮位置才能效果最大化

//测试运行
// class Program
// {
//     static void Main(string[] args)
//     {
//         EnergyFieldSystemTests.TestMaxEnergyField();
//     }
// }
