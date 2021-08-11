#include <stdio.h>
#include <iostream>
#include <stdlib.h>
#include <ctype.h>
using namespace std;

int GiaiThua(int n)
{
	if (n == 1)
		return 1;
	return n * GiaiThua(n - 1);
}

void Input(int& a) {
	bool check = false;
	do {
		cout << "Enter a positive integer number: ";
		cin >> a;
		if (cin.fail())
		{
			check = true;
			cin.clear(); 
			cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n'); 
		}
		else
		{
			check = false;
		}
	} while (a<=0 || check);
}

int main() {
	int a;
	Input(a);
	cout << GiaiThua(a);
}