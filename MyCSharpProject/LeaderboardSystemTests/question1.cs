using System;
using System.Collections.Generic;

public class LeaderboardSystem
{
    public static List<int> GetTopScores(int[] scores, int m)
    {
        
        if (scores == null || scores.Length == 0 || m <= 0)
        {
            return new List<int>();
        }
        // 一开始的想法直接排序，这样处理小数据还行大数据量不行太慢复杂度太高
        // Array.Sort(scores, (a, b) => b.CompareTo(a));

        // m = Math.Min(m, scores.Length);

        // List<int> topScores = new List<int>();
        // for (int i = 0; i < m; i++)
        // {
        //     topScores.Add(scores[i]);
        // }

        // return topScores;
        

        // 这里直接使用优先队列实现最小堆排序
        // 如果堆的大小小于 m，直接添加分数
        // 如果当前分数比堆顶大，替换堆顶元素
        SortedSet<int> minHeap = new SortedSet<int>();

        foreach (int score in scores)
        {
            if (minHeap.Count < m)
            {
                minHeap.Add(score);
            }
            else if (score > minHeap.Min)
            {
                minHeap.Remove(minHeap.Min); 
                minHeap.Add(score);          
            }
        }

        // 最终堆中的元素是前 m 个最高分，但顺序是从小到大
        List<int> topScores = new List<int>(minHeap);
        topScores.Sort((a, b) => b.CompareTo(a)); // 从大到小排序

        return topScores;
    }
    
}

// 单元测试
public class LeaderboardSystemTests
{
    public static void TestGetTopScores()
    {
        // 测试 1
        int[] scores1 = { 100, 50, 75, 80, 65 };
        int m1 = 3;
        List<int> result1 = LeaderboardSystem.GetTopScores(scores1, m1);
        Console.WriteLine("测试 1: " + string.Join(", ", result1)); // 期望输出：100, 80, 75

        // 测试 2：大量玩家
        int[] scores2 = new int[1000000];
        Random rand = new Random();
        for (int i = 0; i < 1000000; i++) scores2[i] = rand.Next(1, 1000000);
        int m2 = 10;
        List<int> result2 = LeaderboardSystem.GetTopScores(scores2, m2);
        Console.WriteLine("测试 2: " + string.Join(", ", result2)); 
       
    }
}

// class Program
// {
//     static void Main(string[] args)
//     {
//         LeaderboardSystemTests.TestGetTopScores();
//     }
// }
