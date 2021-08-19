//#include<iostream>
//#include"BaseState.h"
//#include"StateContext.h"
//#include"UnlockState.h"
//#include"LockState.h"
//
//using namespace std;
//
//void Open(StateContext* sc) {
//	cout << "Unlock To Open" << endl;
//}
//
//void Close(StateContext* sc) {
//	cout << "Can't Unlock while CLOSED!!" << endl;
//}
//
//void Lock(StateContext* sc) {
//	cout << "Locking the Door!!" << endl;
//}
//
//void Unlock(StateContext* sc) {
//	cout << "Can't Unlock while UNLOCKED!!" << endl;
//	sc->SetState(new UnlockState());
//}