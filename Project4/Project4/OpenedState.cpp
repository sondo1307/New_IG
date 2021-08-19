#include"OpenedState.h"
#include<iostream>
#include "ClosedState.h"
#include "StateContext.h"

using namespace std;

void OpenedState::Open(StateContext* sc) {
	cout << "Already Opened" << endl;
}

void OpenedState::Close(StateContext* sc) {
	cout << "Closing the door" << endl;
	sc->SetState(new ClosedState());
}

void OpenedState::Lock(StateContext* sc) {
	cout << "Can't Lock while OPEN!!" << endl;
}

void OpenedState::Unlock(StateContext* sc) {
	cout << "Can't Unlock while OPEN!!" << endl;
}
