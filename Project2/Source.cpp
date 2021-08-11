#include <stdio.h>
#include <iostream>

using namespace std;

int GiaiThua(int n)
{
	if (n == 1)
		return 1;
	return n * GiaiThua(n - 1);
}

void Input(int& a) {
	while (a<=0)
	{
		cout << "Enter a positive integer number: ";
		cin >> a;
	}
}
int main() {
	int a;
	Input(a);
	cout << GiaiThua(a) << endl;
}