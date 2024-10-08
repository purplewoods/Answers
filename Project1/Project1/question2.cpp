#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;
//这里只遍历一次数组时间复杂度为o(n)，
// 其中用的动态规划的思想，如果选择第 i 个宝箱，则不能选择第 i-1 个宝箱，这时的最大金币为 treasure[i] + dp[i-2]。
// 如果不选择第 i 个宝箱，那么金币数量保持为 dp[i - 1]。

int maxTreasure(vector<int> treasure) {
	int n = treasure.size();
	if (n == 0) return 0;
	if (n == 1) return treasure[0];
	vector<int> dp(n, 0);
	dp[0] = treasure[0];
	dp[1] = max(treasure[0], treasure[1]);
	for (int i = 2; i < n; i++) {
		dp[i] = max(dp[i - 1], dp[i - 2] + treasure[i]);
	}
	return dp[n - 1];
}

//int main() {
//	vector<int> treasure = { 2,7,9,3,1 };
//	int ans = maxTreasure(treasure);
//	cout << ans << endl;
//	return 0;
//}