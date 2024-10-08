#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;
// ���������һ�����Ѱ����󱦲���˼·һ��
// ����ֻ����һ������ʱ�临�Ӷ�Ϊo(n)��
// �����õĶ�̬�滮��˼�룬���ѡ��� i �����ӣ�����ѡ��� i-1 �����ӣ���ʱ�����С������Ϊ box[i] + dp[i-2]��
// �����ѡ��� i �����ӣ���ôС����������Ϊ dp[i - 1]��

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