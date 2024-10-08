#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

double findMidian(vector<int> &A, vector<int> &B) {
	int m = A.size();
	int n = B.size();
	vector<int> Merge;
	Merge.reserve(m + n);
	int i = 0, j = 0;
	while (i < m && j < n) {
		if (A[i] < B[j]) {
			Merge.push_back(A[i++]);
		}
		else
		{
			Merge.push_back(B[j++]);
		}
	}
	while (i < m)Merge.push_back(A[i++]);
	while (j < n)Merge.push_back(B[j++]);
	int len = Merge.size();
	if (len % 2 == 1) {
		return Merge[len / 2];
	}
	else
	{
		return (Merge[len / 2 - 1] + Merge[len / 2]) / 2.0;
	}
}

//int main() {
//	vector<int> A = { 1,2,3,5,6 };
//	vector<int>	B = { 3,5,7,8 };
//	double ans = findMidian(A, B);
//	cout << ans << endl;
//	//预期为5
//
//	vector<int> C = { 1,2,3,5,};
//	vector<int>	D = { 4,5,7,8 };
//	double ans2 = findMidian(C, D);
//	cout << ans2 << endl;
//	//预期为4.5
//}