using System;
using System.Collections.Generic;


//用最大堆和最小堆存储所有的能力值，并将所有输入的能力值插入堆中
//平衡堆后比较堆大小，相等就是偶数，则返回较小一半中的最大值和较大一半中的最小值的平均值。
public class TalentAssessmentSystem
{
    private PriorityQueue<int, int> maxHeap; // 左侧堆，最大堆
    private PriorityQueue<int, int> minHeap; // 右侧堆，最小堆

    public TalentAssessmentSystem()
    {
        maxHeap = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x))); // 最大堆
        minHeap = new PriorityQueue<int, int>(); // 最小堆
    }

    public void AddAbility(int ability)
    {
        if (maxHeap.Count == 0 || ability <= maxHeap.Peek())
        {
            maxHeap.Enqueue(ability, ability);
        }
        else
        {
            minHeap.Enqueue(ability, ability);
        }

        if (maxHeap.Count > minHeap.Count + 1)
        {
            minHeap.Enqueue(maxHeap.Dequeue(), maxHeap.Dequeue());
        }
        else if (minHeap.Count > maxHeap.Count)
        {
            maxHeap.Enqueue(minHeap.Dequeue(), minHeap.Dequeue());
        }
    }

    // 获取当前天赋的中位数
    public double FindMedianTalentIndex()
    {
        if (maxHeap.Count > minHeap.Count)//奇数
        {
            return maxHeap.Peek();
        }
        else                             //偶数
        {
            return (maxHeap.Peek() + minHeap.Peek()) / 2.0;
        }
    }
}

public class TalentAssessmentSystemTests
{
    public static void TestFindMedianTalentIndex()
    {
        TalentAssessmentSystem talentSystem = new TalentAssessmentSystem();

        int[] fireAbility = { 1, 3, 3, 5 };
        int[] iceAbility = { 4, 5, 6, 8 };

        // 插入火系能力值
        foreach (var ability in fireAbility)
        {
            talentSystem.AddAbility(ability);
        }

        // 插入冰系能力值
        foreach (var ability in iceAbility)
        {
            talentSystem.AddAbility(ability);
        }

        double median = talentSystem.FindMedianTalentIndex();
        Console.WriteLine("中位数: " + median);  // 期望输出：4.5
    }
}

// 测试运行
class Program
{
    static void Main(string[] args)
    {
        TalentAssessmentSystemTests.TestFindMedianTalentIndex();
    }
}
