#include"BaseState.h"
#include<iostream>
#include"OpenedState.h"
#include"LockedState.h"
#include"StateContext.h"
#include"ClosedState.h"
using namespace std;

void ClosedState::Open(StateContext* sc) {
	cout << "Opening the Door" << endl;
	sc->SetState(new OpenedState());
}

void ClosedState::Close(StateContext* sc) {
	cout << "Can't Close while CLOSED!!" << endl;
}

void ClosedState::Lock(StateContext* sc) {
	cout << "Locking the Door" << endl;
	sc->SetState(new LockedState());
}

void ClosedState::Unlock(StateContext* sc) {
	cout << "Can't unlock while close!!" << endl;
}
