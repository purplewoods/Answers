#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

//�����õļ�������ƽ��ʱ�临�Ӷ�ΪO(n),�����ʱ�临�Ӷ�ΪO(n+k) ,������Ҫ��
// ���ݷ�Χk��Ӱ�죬���ݷ�ΧԽ��������޶�o(n)���Ӷ�ֱ��sort()���У�
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
