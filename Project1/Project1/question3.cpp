#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;
// 这道题与上一道题解寻找最大宝藏题思路一致
// 这里只遍历一次数组时间复杂度为o(n)，
// 其中用的动态规划的思想，如果选择第 i 个箱子，则不能选择第 i-1 个箱子，这时的最大小球数量为 box[i] + dp[i-2]。
// 如果不选择第 i 个箱子，那么小球数量保持为 dp[i - 1]。

int maxBalls(vector<int> box, int n) {
	
	if (n == 0) return 0;
	if (n == 1) return box[0];
	vector<int> dp(n, 0);
	dp[0] = box[0];
	dp[1] = max(box[0], box[1]);
	for (int i = 2; i < n; i++) {
		dp[i] = max(dp[i - 1], dp[i - 2] + box[i]);
	}
	return dp[n - 1];
}

//int main() {
//	vector<int> box = { 2,7,9,3,1 };
//	int n = box.size();
//
//	int ans = maxBalls(box, n);
//	cout << ans << endl;
//	return 0;
//}