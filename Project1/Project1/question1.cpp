#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

//这里用的计数排序，平均时间复杂度为O(n),其中最坏时间复杂度为O(n+k) ,性能主要受
// 数据范围k的影响，数据范围越大。如果不限定o(n)复杂度直接sort()就行；
vector<int> countSort(vector<int>& coins, int m) {
    int n = coins.size();
    int maxV = *max_element(coins.begin(), coins.end());
    int minV = *min_element(coins.begin(), coins.end());

    int range = maxV - minV + 1;
    vector<int> cnt(range, 0);

    for (int coin : coins) {
        cnt[coin - minV]++;
    }

    vector<int> ans;
    for (int i = maxV - minV; i >= 0 && ans.size() < m; i--) {
        while (cnt[i] > 0 && ans.size() < m) {
            ans.emplace_back(i + minV);
            cnt[i]--;
        }
    }
    return ans;
}

//int main() {
//    vector<int> coins = { 10, 5, 8, 12, 3, 7 };
//    int m = 3;
//    vector<int> result = countSort(coins, m);
//    for (int coin : result) {
//        cout << coin << " ";
//    }
//    cout << endl;
//
//    return 0;
//}
