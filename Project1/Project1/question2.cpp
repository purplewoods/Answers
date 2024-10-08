#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;
//����ֻ����һ������ʱ�临�Ӷ�Ϊo(n)��
// �����õĶ�̬�滮��˼�룬���ѡ��� i �����䣬����ѡ��� i-1 �����䣬��ʱ�������Ϊ treasure[i] + dp[i-2]��
// �����ѡ��� i �����䣬��ô�����������Ϊ dp[i - 1]��

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