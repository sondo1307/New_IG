#include<iostream>
#include"BaseState.h"
#include"StateContext.h"
#include"LockedState.h"

using namespace std;

void LockedState::Open(StateContext* sc) {
	cout << "Can't open while LOCKED!!" << endl;
}

void LockedState::Close(StateContext* sc) {
	cout << "Can't close while LOCKED!!" << endl;
}

void LockedState::Lock(StateContext* sc) {
	cout << "Can't Lock while LOCKED!!" << endl;
}

void LockedState::Unlock(StateContext* sc) {
	cout << "Unlocking the Door" << endl;
	sc->SetState(new ClosedState());
}