#include"BaseState.h"
#include"StateContext.h"
#include<iostream>

using namespace std;

int main() {
	StateContext* sc = new StateContext();
	sc->Close();
	sc->Unlock();
	sc->Lock();
	sc->Unlock();
	sc->Close();
	sc->Open();
	delete sc;
	_CrtDumpMemoryLeaks;
	system("Pause");
	return 0;
}