#include <stdio.h>
#include<iostream>
using namespace std;

void Swap1(int& a, int& b) {
	int temp = a;
	a = b;
	b = temp;
}
void Swap2(int* a, int* b) {
	int temp = *a;
	*a = *b;
	*b = temp;
}

int main() {
	int a = 5;
	int b = 10;
	Swap1(a, b);
	cout << a << " " << b << endl;
	Swap2(&a, &b);
	cout << a << " " << b << endl;
}